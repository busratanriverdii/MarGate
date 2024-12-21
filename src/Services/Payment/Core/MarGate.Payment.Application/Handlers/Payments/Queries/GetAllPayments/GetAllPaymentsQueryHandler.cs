using MarGate.Core.CQRS.Query;
using MarGate.Core.Persistence.Repository;
using MarGate.Core.Persistence.UnitOfWork;

namespace MarGate.Payment.Application.Handlers.Payment.Queries.GetAllPayments;

public class GetAllPaymentsQueryHandler(IUnitOfWork unitOfWork) : QueryHandler<GetAllPaymentsQueryRequest, List<GetAllPaymentsQueryResponse>>
{
    private readonly IReadRepository<Domain.Entities.Payment> _paymentReadRepository = unitOfWork.GetReadRepository<Domain.Entities.Payment>();

    public async override Task<List<GetAllPaymentsQueryResponse>> Handle(GetAllPaymentsQueryRequest request,
        CancellationToken cancellationToken)
    {
        var payments = await _paymentReadRepository.GetListAsync(cancellationToken: cancellationToken);

        return payments.Select(p => new GetAllPaymentsQueryResponse()
        {
            Id = p.Id,
            Amount = p.Amount,
            PaymentDate = p.PaymentDate,
            Status = p.Status,
            TransactionId = p.TransactionId,
            PaymentMethodType = p.PaymentMethodType
        }).ToList();
    }
}
