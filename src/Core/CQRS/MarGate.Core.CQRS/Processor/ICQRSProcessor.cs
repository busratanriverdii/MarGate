using MarGate.Core.CQRS.Command;
using MarGate.Core.CQRS.Query;

namespace MarGate.Core.CQRS.Processor;

public interface ICQRSProcessor
{
    Task<TResult> ProcessAsync<TResult>(IQuery<TResult> query, CancellationToken cancellationToken) where TResult : class;
    Task<TResult> ProcessAsync<TResult>(ICommand<TResult> command, CancellationToken cancellationToken) where TResult : class;
}
