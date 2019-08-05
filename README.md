# Binding SelectionChanging event to Listview

In ListView, the [SelectionChanging](https://help.syncfusion.com/cr/cref_files/xamarin/Syncfusion.SfListView.XForms~Syncfusion.ListView.XForms.SfListView~SelectionChanging_EV.html) event will be raised when selecting an item at the execution time. MVVM for the `SelectionChanging` event can be achieved by binding through the event to command converter.

Refer [EventToCommand](https://www.syncfusion.com/kb/7523/how-to-turn-events-into-commands-with-behaviors-in-sflistview?_ga=2.49538854.1823797169.1563166718-1085055173.1562420655) knowledge base to create the command for event using behavior.

```
<syncfusion:SfListView x:Name="listView" 
                       ItemsSource="{Binding BookInfoCollection}">
    <syncfusion:SfListView.Behaviors>
        <local:EventToCommandBehavior EventName="SelectionChanging" Command="{Binding SelectedItem}" 
                                          Converter="{StaticResource EventArgs}"/>
    </syncfusion:SfListView.Behaviors>
</syncfusion:SfListView>
```
```
//ViewModel.cs
public class BookInfoRepository : INotifyPropertyChanged
{
    private Command<ItemSelectionChangingEventArgs> selectedItem

    public Command<ItemSelectionChangingEventArgs> SelectedItem
    {
        get { return this.selectedItem; }
        set
        {
            this.selectedItem = value;
            this.OnPropertyChanged("SelectedItem");
        }
    }

    public BookInfoRepository()
    {
        selectedItem = new Command<ItemSelectionChangingEventArgs>(OnSelectionChanging);
    }

    ///<summary>
    ///To disable the selection for particular item
    ///</summary>
    public void OnSelectionChanging(ItemSelectionChangingEventArgs obj)
    {
        var eventArgs = obj as ItemSelectionChangingEventArgs;
        if (eventArgs.AddedItems.Count > 0 && eventArgs.AddedItems[0] == this.BookInfoCollection[0])
            eventArgs.Cancel = true;
    }
}
```
To know more about MVVM in ListView, please refer our documentation [here](https://help.syncfusion.com/xamarin/sflistview/mvvm)