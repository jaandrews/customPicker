using CustomPicker.Core.Models;

namespace CustomPicker.Core.Pickers {
    public abstract class BasePicker : ICustomPicker {
        public abstract Guid Key { get; }
        public abstract string Name { get; }
        public bool IsAsync => false;

        public abstract IEnumerable<PickerOption> GetInfo(IEnumerable<string> ids, string culture);

        public async Task<IEnumerable<PickerOption>> GetInfoAsync(IEnumerable<string> ids, string culture) {
            throw new NotImplementedException();
        }

        public abstract IEnumerable<PickerOption> Children(string id, string culture);

        public async Task<IEnumerable<PickerOption>> ChildrenAsync(string id, string culture) {
            throw new NotImplementedException();
        }

        public abstract IEnumerable<PickerOption> Search(string searchTerm, string culture);

        public async Task<IEnumerable<PickerOption>> SearchAsync(string searchTerm, string culture) {
            throw new NotImplementedException();
        }
    }
}