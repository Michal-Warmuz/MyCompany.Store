namespace Mediator.Commands
{
    public interface ICommandDispatcher
    {
        Task Dispatch<TCommand>(TCommand command, CancellationToken cancellation) where TCommand : ICommand;
    }
}
