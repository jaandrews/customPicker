using Umbraco.Cms.Core.Models.PublishedContent;
using Umbraco.Cms.Core.PropertyEditors;

namespace Bonsai.CustomPicker.Core {
    public class CustomPickerValueConverter : PropertyValueConverterBase {

        public override bool IsConverter(IPublishedPropertyType propertyType)
            => propertyType.EditorAlias.Equals("Bonsai.CustomPicker");

        public override Type GetPropertyValueType(IPublishedPropertyType propertyType) {
            var config = propertyType.DataType.ConfigurationAs<Dictionary<string, object>>();
            return (string)config["allowMultiple"] == "1" ? typeof(IEnumerable<string>) : typeof(string);
        }

        public override object ConvertSourceToIntermediate(IPublishedElement owner, IPublishedPropertyType propertyType, object source, bool preview) {
            if (source == null) {
                return null;
            }
            return source.ToString();
        }

        public override object ConvertIntermediateToObject(IPublishedElement owner, IPublishedPropertyType propertyType, PropertyCacheLevel referenceCacheLevel, object inter, bool preview) {
            var config = propertyType.DataType.ConfigurationAs<Dictionary<string, object>>();
            if (string.IsNullOrEmpty((string)inter)) {
                return null;
            }
            var value = (string)inter;
            if ((string)config["allowMultiple"] == "1") {
                return value.Split(',');
            }
            else {
                return value;
            }
        }
    }
}