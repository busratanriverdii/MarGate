using MarGate.Core.CQRS.Query;

namespace MarGate.Payment.Application.Handlers.Payment.Queries.GetPaymentById;

public class GetPaymentByIdQueryRequest : Query<GetPaymentByIdQueryResponse>
{
    public long Id { get; set; }
}
