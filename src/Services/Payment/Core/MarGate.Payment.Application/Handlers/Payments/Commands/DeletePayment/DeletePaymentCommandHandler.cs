using MarGate.Core.CQRS.Command;
using MarGate.Core.Persistence.Repository;
using MarGate.Core.Persistence.UnitOfWork;

namespace MarGate.Payment.Application.Handlers.Payment.Commands.DeletePayment;

public class DeletePaymentCommandHandler(IUnitOfWork unitOfWork) : CommandHandler<DeletePaymentCommandRequest, DeletePaymentCommandResponse>
{
    private readonly IWriteRepository<Domain.Entities.Payment> _paymentWriteRepository = unitOfWork.GetWriteRepository<Domain.Entities.Payment>();

    public async override Task<DeletePaymentCommandResponse> Handle(DeletePaymentCommandRequest request,
        CancellationToken cancellationToken)
    {
        var payment = await _paymentWriteRepository.FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken);
        payment.MarkAsDeleted();

        var isSuccess = _paymentWriteRepository.Update(payment);

        await unitOfWork.SaveChangesAsync(cancellationToken);

        return new DeletePaymentCommandResponse()
        {
            IsSuccess = isSuccess
        };
    }
}
