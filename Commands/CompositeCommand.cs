using System.Collections.Generic;
using System.Linq;

namespace RaGuideDesigner.Commands
{
    // A command that groups multiple ICommand objects together, allowing them to be
    // executed and undone as a single transaction.
    public class CompositeCommand : ICommand
    {
        private readonly List<ICommand> _commands = new List<ICommand>();

        public IReadOnlyList<ICommand> Commands => _commands;
        public bool IsMajorChange { get; private set; }

        public CompositeCommand(IEnumerable<ICommand> commands)
        {
            _commands.AddRange(commands);
            // If any of the sub-commands are considered "major", the whole group is.
            IsMajorChange = _commands.OfType<EditPropertyCommand>().Any(c => c.IsMajorChange) ||
                            _commands.OfType<CompositeCommand>().Any(c => c.IsMajorChange) ||
                            _commands.Any(c => !(c is EditPropertyCommand || c is CompositeCommand));
        }

        public void Execute()
        {
            foreach (var command in _commands)
            {
                command.Execute();
            }
        }

        public void Unexecute()
        {
            // Un-execute in reverse order to maintain correctness.
            for (int i = _commands.Count - 1; i >= 0; i--)
            {
                _commands[i].Unexecute();
            }
        }
    }
}