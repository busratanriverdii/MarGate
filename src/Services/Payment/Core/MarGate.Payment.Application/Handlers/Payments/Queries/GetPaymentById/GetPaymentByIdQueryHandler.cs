using MarGate.Core.CQRS.Query;
using MarGate.Core.Persistence.Repository;
using MarGate.Core.Persistence.UnitOfWork;

namespace MarGate.Payment.Application.Handlers.Payment.Queries.GetPaymentById;

public class GetPaymentByIdQueryHandler(IUnitOfWork unitOfWork) : QueryHandler<GetPaymentByIdQueryRequest, GetPaymentByIdQueryResponse>
{
    private readonly IReadRepository<Domain.Entities.Payment> _paymentReadRepository = unitOfWork.GetReadRepository<Domain.Entities.Payment>();

    public async override Task<GetPaymentByIdQueryResponse> Handle(GetPaymentByIdQueryRequest request, CancellationToken cancellationToken)
    {
        var payment = await _paymentReadRepository.FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken);

        return new GetPaymentByIdQueryResponse()
        {
            Id = payment.Id,
            Amount = payment.Amount,
            PaymentDate = payment.PaymentDate,
            Status = payment.Status,
            TransactionId = payment.TransactionId,
            PaymentMethodType = payment.PaymentMethodType
        };
    }
}
