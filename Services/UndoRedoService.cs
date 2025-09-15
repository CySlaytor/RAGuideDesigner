using RaGuideDesigner.Commands;
using System;
using System.Collections.Generic;

namespace RaGuideDesigner.Services
{
    // Manages the undo and redo functionality using two stacks of commands.
    public class UndoRedoService
    {
        private readonly Stack<ICommand> _undoStack = new Stack<ICommand>();
        private readonly Stack<ICommand> _redoStack = new Stack<ICommand>();

        public event Action<ICommand?>? CommandHistoryChanged;
        public event Action<ICommand>? CommandUndone;
        public event Action<ICommand>? CommandRedone;


        public bool CanUndo => _undoStack.Count > 0;
        public bool CanRedo => _redoStack.Count > 0;

        // Executes a command, adds it to the undo stack, and clears the redo stack.
        // This is the standard way to perform an action that should be undoable.
        public void Execute(ICommand command)
        {
            command.Execute();
            _undoStack.Push(command);
            _redoStack.Clear();
            CommandHistoryChanged?.Invoke(command);
        }

        // Takes the last command from the undo stack, reverses its action,
        // and moves it to the redo stack.
        public void Undo()
        {
            if (CanUndo)
            {
                var command = _undoStack.Pop();
                command.Unexecute();
                _redoStack.Push(command);
                CommandUndone?.Invoke(command); // Notify subscribers that a command was undone
                CommandHistoryChanged?.Invoke(command);
            }
        }

        // Takes the last command from the redo stack, executes it again,
        // and moves it back to the undo stack.
        public void Redo()
        {
            if (CanRedo)
            {
                var command = _redoStack.Pop();
                command.Execute();
                _undoStack.Push(command);
                CommandRedone?.Invoke(command); // Notify subscribers that a command was redone
                CommandHistoryChanged?.Invoke(command);
            }
        }

        public void Clear()
        {
            _undoStack.Clear();
            _redoStack.Clear();
            CommandHistoryChanged?.Invoke(null);
        }

        // Call this after a direct model change that is not part of an ICommand.
        // It clears the redo stack and marks the project as dirty.
        public void CommitUnmanagedChange()
        {
            _redoStack.Clear();
            CommandHistoryChanged?.Invoke(null);
        }
    }
}