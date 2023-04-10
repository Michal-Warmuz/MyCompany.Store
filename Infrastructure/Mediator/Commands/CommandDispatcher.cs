using Microsoft.Extensions.DependencyInjection;

namespace Mediator.Commands
{
    internal class CommandDispatcher : ICommandDispatcher
    {
        private readonly IServiceProvider _serviceProvider;

        public CommandDispatcher(IServiceProvider serviceProvider) => _serviceProvider = serviceProvider;

        public Task Dispatch<TCommand>(TCommand command, CancellationToken cancellation) where TCommand : ICommand
        {
            var handler = _serviceProvider.GetRequiredService<ICommandHandler<TCommand>>();
            return handler.Handle(command, cancellation);
        }
    }
}
