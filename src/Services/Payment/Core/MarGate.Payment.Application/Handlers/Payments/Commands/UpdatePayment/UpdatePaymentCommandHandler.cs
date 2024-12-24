using MarGate.Core.CQRS.Command;
using MarGate.Core.UnitOfWork.Repository;
using MarGate.Core.UnitOfWork.UnitOfWork;

namespace MarGate.Payment.Application.Handlers.Payment.Commands.UpdatePayment;

public class UpdatePaymentCommandHandler(IUnitOfWork unitOfWork) : CommandHandler<UpdatePaymentCommandRequest, UpdatePaymentCommandResponse>
{
    private readonly IWriteRepository<Domain.Entities.Payment> _paymentWriteRepository = unitOfWork.GetWriteRepository<Domain.Entities.Payment>();

    public async override Task<UpdatePaymentCommandResponse> Handle(UpdatePaymentCommandRequest request,
        CancellationToken cancellationToken)
    {
        var payment = await _paymentWriteRepository.FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken);

        payment.UpdateStatus(request.Status);

        var isSuccess = _paymentWriteRepository.Update(payment);

        await unitOfWork.SaveChangesAsync(cancellationToken);

        return new UpdatePaymentCommandResponse()
        {
            IsSuccess = isSuccess
        };
    }
}
