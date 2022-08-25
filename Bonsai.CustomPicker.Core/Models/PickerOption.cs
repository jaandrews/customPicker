using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Bonsai.CustomPicker.Core.Models {
    public class PickerOption {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Icon { get; set; }
        public string Description { get; set; }
        public string Extra { get; set; }
        public bool Disabled { get; set; }
        public bool HasChildren { get; set; }
    }
}