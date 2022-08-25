using Bonsai.CustomPicker.Core.Pickers;
using Umbraco.Cms.Core.Composing;

namespace Bonsai.CustomPicker.Core {
    public class CustomPickerCollectionBuilder : LazyCollectionBuilderBase<CustomPickerCollectionBuilder, CustomPickerCollection, ICustomPicker> {
        protected override CustomPickerCollectionBuilder This => this;
    }
}
