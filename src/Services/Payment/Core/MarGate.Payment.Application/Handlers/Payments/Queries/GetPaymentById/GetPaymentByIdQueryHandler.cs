using MarGate.Core.CQRS.Query;

namespace MarGate.Payment.Application.Handlers.Payment.Queries.GetPaymentById;

public class GetPaymentByIdQueryHandler : QueryHandler<GetPaymentByIdQueryRequest, GetPaymentByIdQueryResponse>
{
    public override Task<GetPaymentByIdQueryResponse> Handle(GetPaymentByIdQueryRequest request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
