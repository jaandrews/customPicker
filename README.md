# customPickers - for Umbraco 10
This package is used to create pickers that match the look and feel of the built in umbraco picker with data pulled from any data source. See below for to add new pickers.

## Step 1 - Create the new picker class
Extend one of the base classes.

### BasePicker - Used for synchronous data sources
```csharp
public class ExamplePicker : BasePicker {

    public override Guid Key => new Guid("21696b2b-67fd-47a7-994f-596768e7ea17");
    public override string Name => "Example"; //This the used to identify the picker when creating a custom picker data type instance.

    public override IEnumerable<PickerOption> Children(string id, string culture) {
        ...
    }

    public override IEnumerable<PickerOption> GetInfo(IEnumerable<string> ids, string culture) {
        ...
    }

    public override IEnumerable<PickerOption> Search(string searchTerm, string culture) {
        ...
    }
}
```
### BaseAsyncPicker - Used for asynchronous data sources
```csharp
public class ExampleAsyncPicker : BaseAsyncPicker {

    public override Guid Key => new Guid("2470e2dd-b784-4ef2-a879-cffd65a494e5");
    public override string Name => "Example Async"; //This the used to identify the picker when creating a custom picker data type instance.

    public override Task<IEnumerable<PickerOption>> ChildrenAsync(string id, string culture) {
        ...
    }

    public override Task<IEnumerable<PickerOption>> GetInfoAsync(IEnumerable<string> ids, string culture) {
        ...
    }

    public override Task<IEnumerable<PickerOption>> SearchAsync(string searchTerm, string culture) {
        ...
    }
}
```

The Children and ChildrenAsync methods are used to content tree in the picker, where the id is the id of the parent content. The root id will always be "-1" This is the same approach umbraco uses for its TreeControllers (see [here](https://our.umbraco.com/documentation/extending/section-trees/trees/)).

The GetInfo and GetInfoAsync methods are used to retrieve data about the currently selected items. This is needed since the control only stores the id, similar to how umbraco content pickers store a udi and pull in the relevent information from that.

The Search and SearchAsync methods are used to return a list of options matching the provided searchTerm.

See the code for the [PickerPicker](https://github.com/jaandrews/customPicker/blob/v10/main/CustomPicker.Core/Pickers/PickerPicker.cs) for a full implementation of a picker. This is the picker used to select the picker when creating the data type instance.

## Step 2 - Create the custom picker instance
Create a new data type like usual and select the newly created picker for the picker property in the configuration.

And that's all there is to it.



