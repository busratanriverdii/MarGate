using MarGate.Core.CQRS.Command;
using MarGate.Core.Persistence.Repository;
using MarGate.Core.Persistence.UnitOfWork;
using MarGate.Order.Application.Messaging.OrderCreated;
using MarGate.Order.Application.RemoteCall;                                                                                                          
using MassTransit;
                      
namespace MarGate.Order.Application.Handlers.Order.Commands.CreateOrder;

public class CreateOrderCommandHandler(IUnitOfWork unitOfWork, IPublishEndpoint publishEndpoint, IIdentityRemoteCall identityRemoteCall) : CommandHandler<CreateOrderCommandRequest, CreateOrderCommandResponse>
{
    private readonly IWriteRepository<Domain.Entities.Order> _orderWriteRepository = unitOfWork.GetWriteRepository<Domain.Entities.Order>();

    public async override Task<CreateOrderCommandResponse> Handle(CreateOrderCommandRequest request,
        CancellationToken cancellationToken)
    {
        var user = identityRemoteCall.GetUserById(request.UserId);

        var order = new Domain.Entities.Order(user.Id, request.Address, request.Description);

        foreach (var item in request.Items)
        {
            order.OrderItems.Add(new Domain.Entities.OrderItem(
                item.ProductId,
                item.Quantity,
                item.UnitPrice));
        }


        var orderId = _orderWriteRepository.Create(order);

        await unitOfWork.SaveChangesAsync(cancellationToken);

        await publishEndpoint.Publish(new OrderCreatedMessage
        {
            OrderId = orderId
        }, cancellationToken);

        return new CreateOrderCommandResponse()
        {
            IsSuccess = true
        };
    }
}
