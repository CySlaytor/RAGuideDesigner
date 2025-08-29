using System;

namespace RaGuideDesigner.Commands
{
    // A general-purpose command that executes provided actions for 'Execute' and 'Unexecute'.
    // This is useful for wrapping simple UI updates or custom logic into the undo/redo system.
    public class ActionCommand : ICommand
    {
        private readonly Action _executeAction;
        private readonly Action _unexecuteAction;

        public ActionCommand(Action executeAction, Action unexecuteAction)
        {
            _executeAction = executeAction;
            _unexecuteAction = unexecuteAction;
        }

        public void Execute()
        {
            _executeAction?.Invoke();
        }

        public void Unexecute()
        {
            _unexecuteAction?.Invoke();
        }
    }
}