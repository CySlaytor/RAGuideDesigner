using System.ComponentModel;
using System.Collections.Generic;

namespace RaGuideDesigner.Commands
{
    // An undoable command for removing an item from a BindingList.
    public partial class RemoveListItemCommand<T> : ICommand
    {
        private readonly BindingList<T> _list;
        public T Item { get; }
        public int OriginalIndex { get; private set; } = -1;

        public RemoveListItemCommand(BindingList<T> list, T item)
        {
            _list = list;
            Item = item;
        }

        public void Execute()
        {
            OriginalIndex = _list.IndexOf(Item);
            if (OriginalIndex != -1)
            {
                _list.RemoveAt(OriginalIndex);
            }
        }

        public void Unexecute()
        {
            if (OriginalIndex != -1 && OriginalIndex <= _list.Count)
            {
                _list.Insert(OriginalIndex, Item);
            }
        }

        public ICollection<T> GetList() => _list;
    }
}