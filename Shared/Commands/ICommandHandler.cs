namespace Shared.Commands
{
    public interface ICommandHandler<T> where  T : ICommand
    {
        IcommandResult Handle(T command);
    }
}