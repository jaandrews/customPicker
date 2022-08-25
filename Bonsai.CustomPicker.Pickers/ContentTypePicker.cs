using Bonsai.CustomPicker.Core.Pickers;
using Bonsai.CustomPicker.Core.Models;
using Umbraco.Cms.Core.Services;

namespace Bonsai.CustomPicker.Pickers {
    public class ContentTypePicker : BasePicker {
        private readonly IContentTypeService _contentTypeService;

        public override Guid Key => new Guid("149a3e0d-6663-41af-8638-523ab0cddabf");

        public override string Name => "Content Types";

        public ContentTypePicker(IContentTypeService contentTypeService) {
            _contentTypeService = contentTypeService;
        }

        public override IEnumerable<PickerOption> Children(string id, string culture) {

            if (id == "-1") {
                var containers = _contentTypeService.GetContainers(new int[] { });

                return containers.Select(x => new PickerOption {
                    Name = x.Name,
                    Id = x.Id.ToString(),
                    Icon = "icon-folder",
                    HasChildren = true,
                    Disabled = true
                });
            }
            else {
                var type = int.TryParse(id, out int result) ? _contentTypeService.GetContainer(result) : _contentTypeService.GetContainer(Guid.Parse(id));
                return _contentTypeService.GetChildren(type.Id).Select(x => new PickerOption {
                    Name = x.Name,
                    Id = x.Alias,
                    Icon = x.Icon,
                    HasChildren = false
                });
            }
        }

        public override IEnumerable<PickerOption> GetInfo(IEnumerable<string> ids, string culture) {
            return ids.Select(id => {
                var contentType = _contentTypeService.Get(id);
                return new PickerOption {
                    Name = contentType.Name,
                    Id = contentType.Alias,
                    Icon = contentType.Icon
                };
            });
        }

        public override IEnumerable<PickerOption> Search(string searchTerm, string culture) {
            var types = _contentTypeService.GetAll();
            var term = searchTerm.ToLower();
            return types.Where(x => x.Alias.ToLower().Contains(term)).Select(x => new PickerOption {
                Name = x.Name,
                Id = x.Alias,
                Icon = x.Icon
            });
        }
    }
}
