using CustomPicker.Pickers;
using Umbraco.Cms.Core.Composing;

namespace CustomPicker.Core {
    public class CustomPickerCollectionBuilder : LazyCollectionBuilderBase<CustomPickerCollectionBuilder, CustomPickerCollection, ICustomPicker> {
        protected override CustomPickerCollectionBuilder This => this;
    }
}
