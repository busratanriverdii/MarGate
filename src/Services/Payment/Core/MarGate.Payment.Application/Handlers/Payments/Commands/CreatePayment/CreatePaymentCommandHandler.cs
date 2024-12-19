using MarGate.Core.CQRS.Command;

namespace MarGate.Payment.Application.Handlers.Payment.Commands.CreatePayment;

public class CreatePaymentCommandHandler : CommandHandler<CreatePaymentCommandRequest, CreatePaymentCommandResponse>
{
    private readonly IPaymentWriteRepository _paymentWriteRepository;

    public CreatePaymentCommandHandler(IPaymentWriteRepository paymentWriteRepository)
    {
        _paymentWriteRepository = paymentWriteRepository;
    }

    public override Task<CreatePaymentCommandResponse> Handle(CreatePaymentCommandRequest request,
        CancellationToken cancellationToken)
    {
        var payment = new Payment(request.Amount, request.PaymentMethod, request.Status, request.TransactionId);

        var isSuccess = await _paymentWriteRepository.CreateAsync(payment);
        await _paymentWriteRepository.SaveAsync();

        return new CreatePaymentCommandResponse
        {
            IsSuccess = isSuccess
        };
    }
}
