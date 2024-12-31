using MarGate.Core.CQRS.Command;
using MarGate.Order.Application.Messaging.OrderCreated;
using MarGate.Order.Application.RemoteCall;
using MassTransit;
using MarGate.Core.UnitOfWork.Repository;
using MarGate.Core.UnitOfWork.UnitOfWork;

namespace MarGate.Order.Application.Handlers.Order.Commands.CreateOrder;

public class CreateOrderCommandHandler(IUnitOfWork unitOfWork, IPublishEndpoint publishEndpoint, IIdentityRemoteCall identityRemoteCall) : CommandHandler<CreateOrderCommandRequest, CreateOrderCommandResponse>
{
    private readonly IWriteRepository<Domain.Entities.Order> _orderWriteRepository = unitOfWork.GetWriteRepository<Domain.Entities.Order>();

    public async override Task<CreateOrderCommandResponse> Handle(CreateOrderCommandRequest request,
        CancellationToken cancellationToken)
    {
        var user = await identityRemoteCall.GetUserById(request.UserId);

        var order = new Domain.Entities.Order(user.Data.Id, request.Address, request.Description);

        foreach (var item in request.Items)
        {
            order.OrderItems.Add(new Domain.Entities.OrderItem(
                item.ProductId,
                item.Quantity,
                item.UnitPrice));
        }

        _orderWriteRepository.Create(order);

        await publishEndpoint.Publish(new OrderCreatedMessage
        {
            OrderId = order.Id
        }, cancellationToken);

        return new CreateOrderCommandResponse()
        {
            IsSuccess = true
        };
    }
}
