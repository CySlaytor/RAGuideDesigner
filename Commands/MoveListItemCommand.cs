using System.ComponentModel;

namespace RaGuideDesigner.Commands
{
    // An undoable command for moving an item between or within BindingLists.
    public class MoveListItemCommand<T> : ICommand
    {
        public BindingList<T> SourceList { get; }
        public BindingList<T> DestinationList { get; }
        public T Item { get; }
        public int NewIndex { get; }
        private readonly int _originalIndex;

        public MoveListItemCommand(BindingList<T> sourceList, BindingList<T> destinationList, T item, int newIndex, int originalIndex)
        {
            SourceList = sourceList;
            DestinationList = destinationList;
            Item = item;
            NewIndex = newIndex;
            _originalIndex = originalIndex;
        }

        public void Execute()
        {
            if (SourceList.Contains(Item))
            {
                SourceList.Remove(Item);
            }
            DestinationList.Insert(NewIndex, Item);
        }

        public void Unexecute()
        {
            DestinationList.Remove(Item);
            SourceList.Insert(_originalIndex, Item);
        }
    }
}