using Umbraco.Cms.Core.DependencyInjection;

namespace Bonsai.CustomPicker.Core {
    public static class WebCompositionExtensions {
        public static CustomPickerCollectionBuilder CustomPickers(this IUmbracoBuilder builder) => builder.WithCollectionBuilder<CustomPickerCollectionBuilder>();
    }
}
