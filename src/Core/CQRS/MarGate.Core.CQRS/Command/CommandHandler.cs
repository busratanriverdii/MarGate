namespace MarGate.Core.CQRS.Command
{
    public abstract class CommandHandler<TCommand, TResult> : ICommandHandler<TCommand, TResult> where TCommand : ICommand<TResult> where TResult : class
    {
        public abstract Task<TResult> Handle(TCommand request, CancellationToken cancellationToken);
    }
}
