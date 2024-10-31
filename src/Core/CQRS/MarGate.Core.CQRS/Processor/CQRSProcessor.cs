using MarGate.Core.CQRS.Command;
using MarGate.Core.CQRS.Query;
using MediatR;

namespace MarGate.Core.CQRS.Processor
{
    public class CQRSProcessor : ICQRSProcessor
    {
        private readonly IMediator _mediatr;

        public CQRSProcessor(IMediator mediatr)
        {
            _mediatr = mediatr;
        }

        public Task<TResult> ProcessAsync<TResult>(IQuery<TResult> query, CancellationToken cancellationToken) where TResult : class
        {
            return _mediatr.Send(query, cancellationToken);
        }

        public Task<TResult> ProcessAsync<TResult>(ICommand<TResult> command, CancellationToken cancellationToken) where TResult : class
        {
            return _mediatr.Send(command, cancellationToken);
        }
    }
}
