using Bonsai.CustomPicker.Core.Pickers;
using Umbraco.Cms.Core.Composing;

namespace Bonsai.CustomPicker.Core {
    public class CustomPickerCollection : BuilderCollectionBase<ICustomPicker> {
        public CustomPickerCollection(Func<IEnumerable<ICustomPicker>> items) : base(items) {
        }
    }
}