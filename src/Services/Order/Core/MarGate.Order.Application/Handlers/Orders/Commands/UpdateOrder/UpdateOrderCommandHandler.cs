﻿using MarGate.Core.CQRS.Command;
using MarGate.Core.UnitOfWork.Repository;
using MarGate.Core.UnitOfWork.UnitOfWork;

namespace MarGate.Order.Application.Handlers.Order.Commands.UpdateOrder;

public class UpdateOrderCommandHandler(IUnitOfWork unitOfWork) : CommandHandler<UpdateOrderCommandRequest, UpdateOrderCommandResponse>
{
    private readonly IWriteRepository<Domain.Entities.Order> _orderWriteRepository = unitOfWork.GetWriteRepository<Domain.Entities.Order>();

    public async override Task<UpdateOrderCommandResponse> Handle(UpdateOrderCommandRequest request,
        CancellationToken cancellationToken)
    {
        var order = await _orderWriteRepository.FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken);
        order.SetDescription(request.Description);
        order.SetAddress(request.Address);

        var isSuccess = _orderWriteRepository.Update(order);

        return new UpdateOrderCommandResponse()
        {
            IsSuccess = isSuccess
        };
    }
}
