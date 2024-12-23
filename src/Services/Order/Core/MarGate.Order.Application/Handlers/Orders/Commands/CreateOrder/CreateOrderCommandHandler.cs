using MarGate.Core.CQRS.Command;
using MarGate.Core.Persistence.Repository;
using MarGate.Core.Persistence.UnitOfWork;
using MarGate.Order.Application.Messaging.OrderCreated;
using MarGate.Order.Application.RemoteCall;
using MassTransit;
using Microsoft.Extensions.DependencyInjection;

namespace MarGate.Order.Application.Handlers.Order.Commands.CreateOrder;

public class CreateOrderCommandHandler : CommandHandler<CreateOrderCommandRequest, CreateOrderCommandResponse>
{
    private readonly IWriteRepository<Domain.Entities.Order> _orderWriteRepository;
    private readonly IPublishEndpoint _publishEndpoint;
    private readonly IIdentityRemoteCall _identityRemoteCall;
    private readonly IUnitOfWork _unitOfWork;

    public CreateOrderCommandHandler(IUnitOfWork unitOfWork, IPublishEndpoint publishEndpoint, IIdentityRemoteCall identityRemoteCall)
    {
        _orderWriteRepository = unitOfWork.GetWriteRepository<Domain.Entities.Order>();
        _publishEndpoint = publishEndpoint;
        _identityRemoteCall = identityRemoteCall;
        _unitOfWork = unitOfWork;
    }

    public async override Task<CreateOrderCommandResponse> Handle(CreateOrderCommandRequest request,
        CancellationToken cancellationToken)
    {
        var user = _identityRemoteCall.GetUserById(request.UserId);

        var order = new Domain.Entities.Order(user.Id, request.Address, request.Description);

        foreach (var item in request.Items)
        {
            order.OrderItems.Add(new Domain.Entities.OrderItem(
                item.ProductId,
                item.Quantity,
                item.UnitPrice));
        }


        var orderId = _orderWriteRepository.Create(order);

        await _unitOfWork.SaveChangesAsync(cancellationToken);

        await _publishEndpoint.Publish(new OrderCreatedMessage
        {
            OrderId = orderId
        }, cancellationToken);

        return new CreateOrderCommandResponse()
        {
            IsSuccess = true
        };
    }
}
