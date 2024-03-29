﻿using Bonsai.CustomPicker.Core.Pickers;
using Umbraco.Cms.Core.Composing;
using Umbraco.Cms.Core.DependencyInjection;

namespace Bonsai.CustomPicker.Core {
    public class CustomPickerComposer : IComposer {

        public void Compose(IUmbracoBuilder builder) {
            builder.CustomPickers().Add(() => builder.TypeLoader.GetTypes<ICustomPicker>());
        }
    }
}