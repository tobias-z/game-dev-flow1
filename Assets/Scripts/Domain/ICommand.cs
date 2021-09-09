namespace Domain
{
    public interface ICommand
    {
        void Execute();
    }

    public interface IEventCommand : ICommand
    {
        bool IsFinished();
    }
}