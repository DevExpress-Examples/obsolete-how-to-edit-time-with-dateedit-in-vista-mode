<!-- default file list -->
*Files to look at*:

* **[MainWindow.xaml](./CS/DatetimeEditor/MainWindow.xaml) (VB: [MainWindow.xaml](./VB/DatetimeEditor/MainWindow.xaml))**

# How to edit time within the DateEdit popup (Vista mode)

In **v19.2** and newer, you can use [DateEditNavigatorWithTimePickerStyleSettings](https://docs.devexpress.com/WPF/DevExpress.Xpf.Editors.DateEditNavigatorWithTimePickerStyleSettings?v=19.2) to show the time editor in the popup.

```xml
<dxe:DateEdit>
    <dxe:DateEdit.StyleSettings>
        <dxe:DateEditNavigatorWithTimePickerStyleSettings />
    </dxe:DateEdit.StyleSettings>
</dxe:DateEdit>
```