using CustomPicker.Core.Models;
using CustomPicker.Core.Pickers;
using Umbraco.Cms.Core.Services;
using Umbraco.Extensions;

namespace Seed.Components.Search.Core {
    public class PropertyPicker : BasePicker {
        private readonly IContentTypeService _contentTypeService;

        public override Guid Key => new Guid("9b9d0d1b-6c15-4719-b327-c28b756f489d");

        public override string Name => "Properties";

        public PropertyPicker(IContentTypeService contentTypeService) {
            _contentTypeService = contentTypeService;
        }

        public override IEnumerable<PickerOption> Children(string id, string culture) {
            var propertyTypes = _contentTypeService.GetAllPropertyTypeAliases().ToList();
            propertyTypes.Insert(0, "@nodeName");
            return propertyTypes.Select(x => new PickerOption {
                Name = x,
                Id = x,
                Icon = "icon-wrench"
            });
        }

        public override IEnumerable<PickerOption> GetInfo(IEnumerable<string> ids, string culture) {
            return ids.Select(id => {
                return new PickerOption {
                    Name = id,
                    Id = id,
                    Icon = "icon-wrench"
                };
            });
        }

        public override IEnumerable<PickerOption> Search(string searchTerm, string culture) {
            var propertyTypes = _contentTypeService.GetAllPropertyTypeAliases().ToList();
            propertyTypes.Insert(0, "@nodeName");
            return propertyTypes.Where(x => x.InvariantContains(searchTerm)).Select(x => new PickerOption {
                Name = x,
                Id = x,
                Icon = "icon-wrench"
            });
        }
    }
}
