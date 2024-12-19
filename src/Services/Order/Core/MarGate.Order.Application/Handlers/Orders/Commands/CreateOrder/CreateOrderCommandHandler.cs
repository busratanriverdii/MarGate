using MarGate.Core.CQRS.Command;
using Microsoft.Extensions.DependencyInjection;

namespace MarGate.Order.Application.Handlers.Order.Commands.CreateOrder;

public class CreateOrderCommandHandler : CommandHandler<CreateOrderCommandRequest, CreateOrderCommandResponse>
{

    private readonly IServiceProvider _serviceProvider; 

    public CreateOrderCommandHandler(IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }

    public override Task<CreateOrderCommandResponse> Handle(CreateOrderCommandRequest request, 
        CancellationToken cancellationToken)
    {
        var orderWriteRepository = _serviceProvider.GetService<IOrderWriteRepository>();
        var basketItemWriteRepository = _serviceProvider.GetService<IBasketItemWriteRepository>();
        var orderItemWriteRepository = _serviceProvider.GetService<IOrderItemWriteRepository>();
        var userReadRepository = _serviceProvider.GetService<IUserReadRepository>();
        var capPublisher = _serviceProvider.GetService<ICapPublisher>();

        var user = await userReadRepository.SingleGetAsync(x => x.Id == request.UserId);

        var order = new Order()
        {
            Description = request.Description,
            Address = request.Address,
            UserId = user.Id
        };

        var isSuccess = await orderWriteRepository.CreateAsync(order);
        await orderWriteRepository.SaveAsync();

        var basketItems =
            await basketItemWriteRepository.Table.Where(x => x.BasketId == user.Basket.Id)
                .ToListAsync(cancellationToken: cancellationToken);

        foreach (var basketItem in basketItems)
        {
            var orderItem = new OrderItem
            {
                OrderId = order.Id,
                ProductId = basketItem.ProductId
            };

            await orderItemWriteRepository.CreateAsync(orderItem);

            basketItem.IsDeleted = true;
        }

        await basketItemWriteRepository.SaveAsync();
        await orderItemWriteRepository.SaveAsync();

        await capPublisher.PublishAsync("order.created", new OrderCreatedEvent()
        {
            OrderId = order.Id
        }, cancellationToken: cancellationToken);

        return new CreateOrderCommandResponse()
        {
            IsSuccess = isSuccess
        };
    }
}
