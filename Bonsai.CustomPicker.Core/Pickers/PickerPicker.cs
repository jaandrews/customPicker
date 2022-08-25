using Bonsai.CustomPicker.Core.Models;
using Umbraco.Extensions;


namespace Bonsai.CustomPicker.Core.Pickers {
    public class PickerPicker : BasePicker {
        private readonly Lazy<CustomPickerCollection> _customPickers;

        public override Guid Key => new Guid(CustomPickerConstants.Pickers.Picker);
        public override string Name => "Pickers";

        public PickerPicker(Lazy<CustomPickerCollection> customPickers) {
            _customPickers = customPickers;
        }

        public override IEnumerable<PickerOption> Children(string id, string culture) {
            if (id == "-1") {
                return _customPickers.Value.Select(x => new PickerOption {
                    Icon = "icon-autofill",
                    Name = x.Name,
                    Id = x.Key.ToString()
                });
            }
            return Enumerable.Empty<PickerOption>();
        }

        public override IEnumerable<PickerOption> GetInfo(IEnumerable<string> ids, string culture) {
            var keys = ids.Select(x => new Guid(x));
            return _customPickers.Value.Where(x => keys.Contains(x.Key)).Select(x => new PickerOption {
                Icon = "icon-autofill",
                Name = x.Name,
                Id = x.Key.ToString()
            });
        }

        public override IEnumerable<PickerOption> Search(string searchTerm, string culture) {
            var options = _customPickers.Value.Select(x => new PickerOption {
                Icon = "icon-autofill",
                Name = x.Name,
                Id = x.Key.ToString()
            });
            return options.Where(x => x.Name.InvariantContains(searchTerm));
        }
    }
}