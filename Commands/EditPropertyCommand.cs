using System;
using System.Reflection;

namespace RaGuideDesigner.Commands
{
    // An undoable command for changing a single property on an object using reflection.
    public class EditPropertyCommand : ICommand
    {
        private readonly object _targetObject;
        private readonly string _propertyName;
        private readonly object _oldValue;
        private readonly object _newValue;
        private readonly PropertyInfo? _propertyInfo;

        public object TargetObject => _targetObject;
        public bool IsMajorChange { get; private set; }

        public EditPropertyCommand(object target, string propertyName, object oldValue, object newValue)
        {
            _targetObject = target;
            _propertyName = propertyName;
            _oldValue = oldValue;
            _newValue = newValue;
            _propertyInfo = _targetObject.GetType().GetProperty(propertyName);
            if (_propertyInfo == null)
            {
                throw new ArgumentException($"Property '{propertyName}' not found on object of type '{_targetObject.GetType().Name}'.");
            }

            // "Major" changes are ones that should cause the tree view node to update its text.
            IsMajorChange = propertyName is "Title" or "Icon" or "Username";
        }

        public void Execute() => _propertyInfo?.SetValue(_targetObject, _newValue);
        public void Unexecute() => _propertyInfo?.SetValue(_targetObject, _oldValue);
    }
}