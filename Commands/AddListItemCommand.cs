using System.Collections.Generic;
using System.ComponentModel;

namespace RaGuideDesigner.Commands
{
    // An undoable command for adding an item to a BindingList.
    public partial class AddListItemCommand<T> : ICommand
    {
        private readonly BindingList<T> _list;
        public T Item { get; }
        private readonly int _index = -1;

        public AddListItemCommand(BindingList<T> list, T item, int index = -1)
        {
            _list = list;
            Item = item;
            _index = index;
        }

        public void Execute()
        {
            if (!_list.Contains(Item))
            {
                if (_index >= 0 && _index <= _list.Count)
                {
                    _list.Insert(_index, Item);
                }
                else
                {
                    _list.Add(Item);
                }
            }
        }

        public void Unexecute()
        {
            _list.Remove(Item);
        }

        public ICollection<T> GetList() => _list;
    }
}