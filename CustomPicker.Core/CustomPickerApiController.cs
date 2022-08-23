using Microsoft.AspNetCore.Mvc;
using CustomPicker.Core.Models;
using Umbraco.Cms.Web.BackOffice.Controllers;
using Umbraco.Cms.Web.BackOffice.Filters;
using Umbraco.Cms.Web.Common.Attributes;

namespace CustomPicker.Core {
    [PluginController("CustomPicker")]
    [JsonCamelCaseFormatter]
    public class CustomPickerApiController : UmbracoAuthorizedApiController {
        private Lazy<CustomPickerCollection> _customPickers;
        public CustomPickerApiController(Lazy<CustomPickerCollection> customPickers) {
            _customPickers = customPickers;
        }
        [HttpGet]
        public async Task<IEnumerable<PickerOption>> GetInfo([FromQuery]IEnumerable<string> ids, Guid key, string culture = null) {
            var picker = _customPickers.Value.First(x => x.Key == key);
            return picker.IsAsync ? await picker.GetInfoAsync(ids, culture) : picker.GetInfo(ids, culture);
        }

        [HttpGet]
        public async Task<IEnumerable<PickerOption>> Children(string id, Guid key, string culture = null) {
            var picker = _customPickers.Value.First(x => x.Key == key);
            return picker.IsAsync ? await picker.ChildrenAsync(id, culture) : picker.Children(id, culture);
        }

        [HttpGet]
        public async Task<IEnumerable<PickerOption>> Search(string searchTerm, Guid key, string culture = null) {
            var picker = _customPickers.Value.First(x => x.Key == key);
            return picker.IsAsync ? await picker.SearchAsync(searchTerm, culture) : picker.Search(searchTerm, culture);
        }
    }
}