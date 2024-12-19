using MarGate.Core.CQRS.Query;

namespace MarGate.Payment.Application.Handlers.Payment.Queries.GetAllPayments;

public class GetAllPaymentsQueryHandler : QueryHandler<GetAllPaymentsQueryRequest, GetAllPaymentsQueryResponse>
{
    public override Task<GetAllPaymentsQueryResponse> Handle(GetAllPaymentsQueryRequest request,
        CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
