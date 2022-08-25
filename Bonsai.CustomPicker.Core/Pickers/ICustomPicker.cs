using Bonsai.CustomPicker.Core.Models;

namespace Bonsai.CustomPicker.Core.Pickers {
    public interface ICustomPicker {
        Guid Key { get; }
        string Name { get; }
        bool IsAsync { get; }
        IEnumerable<PickerOption> GetInfo(IEnumerable<string> ids, string culture);
        IEnumerable<PickerOption> Children(string id, string culture);
        IEnumerable<PickerOption> Search(string searchTerm, string culture);
        Task<IEnumerable<PickerOption>> GetInfoAsync(IEnumerable<string> ids, string culture);
        Task<IEnumerable<PickerOption>> ChildrenAsync(string id, string culture);
        Task<IEnumerable<PickerOption>> SearchAsync(string searchTerm, string culture);
    }
}