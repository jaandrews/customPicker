using Bonsai.CustomPicker.Core.Models;

namespace Bonsai.CustomPicker.Core.Pickers {
    public abstract class BaseAsyncPicker : ICustomPicker {
        public abstract Guid Key { get; }
        public abstract string Name { get; }

        public bool IsAsync => true;

        public IEnumerable<PickerOption> GetInfo(IEnumerable<string> ids, string culture) {
            throw new NotImplementedException();
        }

        public abstract Task<IEnumerable<PickerOption>> GetInfoAsync(IEnumerable<string> ids, string culture);

        public IEnumerable<PickerOption> Children(string id, string culture) {
            throw new NotImplementedException();
        }

        public abstract Task<IEnumerable<PickerOption>> ChildrenAsync(string id, string culture);

        public IEnumerable<PickerOption> Search(string searchTerm, string culture) {
            throw new NotImplementedException();
        }

        public abstract Task<IEnumerable<PickerOption>> SearchAsync(string searchTerm, string culture);
     }
}