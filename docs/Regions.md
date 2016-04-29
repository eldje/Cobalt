# Regions

Prism regions are designed to support the development of composite applications (that is, applications that consist of multiple modules)
by allowing the application's overall UI to be constructed in a loosely-coupled way. 
Regions allow views defined in a module to be displayed within the application's UI without requiring the module to have 
explicit knowledge of the application's overall UI structure. They allow the layout of the application's UI to be 
changed easily, thereby allowing the UI designer to choose the most appropriate UI design and layout for the application without 
requiring changes in the modules themselves.

Prism regions are essentially named placeholders within which views can be displayed. Any control in the application's UI 
can be a declared a region by simply adding a RegionName attached property to it, as shown here.

```xaml
<ContentControl regions:RegionManager.RegionName="{x:Static infrastructure:RegionNames.ComplaintRegion}" />
```

Cobalt contains a static collection of region names in order to proivde non-magic strings. This collection is held in the infrastructure 
project under the class name, RegionNames.

In Cobalt view injection is supported through the module initialization method.

```csharp
public void Initialize()
{
    _regionManager.RegisterViewWithRegion(RegionNames.StatusBarRegion, typeof(StatusToolBarView));
}
```

For more information about modules see [Modules](https://github.com/TravisBoatman/Cobalt/blob/master/docs/Modules.md)

For more information about regions see [Prism Region Overview](https://msdn.microsoft.com/en-us/library/gg430861(v=pandp.40).aspx#sec7)
