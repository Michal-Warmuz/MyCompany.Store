namespace Mediator.Commands
{
    public interface ICommandHandler<in TCommand, TCommandResul> where TCommand : ICommand
    {
        Task<TCommandResul> Handle(TCommand command, CancellationToken cancellation);
    }
}
