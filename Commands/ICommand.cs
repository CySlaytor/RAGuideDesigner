namespace RaGuideDesigner.Commands
{
    public interface ICommand
    {
        void Execute();
        void Unexecute();
    }
}