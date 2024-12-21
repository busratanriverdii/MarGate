using MarGate.Core.CQRS.Query;

namespace MarGate.Payment.Application.Handlers.Payment.Queries.GetAllPayments;

public class GetAllPaymentsQueryRequest : Query<List<GetAllPaymentsQueryResponse>>
{
}
