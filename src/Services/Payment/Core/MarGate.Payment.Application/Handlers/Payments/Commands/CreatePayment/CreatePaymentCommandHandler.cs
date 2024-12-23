using MarGate.Core.CQRS.Command;
using MarGate.Core.UnitOfWork.Repository;
using MarGate.Core.UnitOfWork.UnitOfWork;

namespace MarGate.Payment.Application.Handlers.Payment.Commands.CreatePayment;

public class CreatePaymentCommandHandler(IUnitOfWork unitOfWork) : CommandHandler<CreatePaymentCommandRequest, CreatePaymentCommandResponse>
{
    private readonly IWriteRepository<Domain.Entities.Payment> _paymentWriteRepository = unitOfWork.GetWriteRepository<Domain.Entities.Payment>();

    public async override Task<CreatePaymentCommandResponse> Handle(CreatePaymentCommandRequest request,
        CancellationToken cancellationToken)
    {
        var payment = new Domain.Entities.Payment(
            request.Amount, 
            request.PaymentMethodType, 
            request.Status, 
            request.TransactionId);

        _paymentWriteRepository.Create(payment);

        await unitOfWork.SaveChangesAsync(cancellationToken);

        return new CreatePaymentCommandResponse
        {
            IsSuccess = true,
            PaymentId = payment.Id,
        };
    }
}
