using CustomPicker.Core.Pickers;
using Umbraco.Cms.Core.Composing;

namespace CustomPicker.Core {
    public class CustomPickerCollection : BuilderCollectionBase<ICustomPicker> {
        public CustomPickerCollection(Func<IEnumerable<ICustomPicker>> items) : base(items) {
        }
    }
}