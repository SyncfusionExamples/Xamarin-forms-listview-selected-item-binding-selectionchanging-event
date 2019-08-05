using Syncfusion.ListView.XForms;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace MVVM
{
public class BookInfoRepository : INotifyPropertyChanged
{
    private ObservableCollection<BookInfo> bookInfoCollection;
    public event PropertyChangedEventHandler PropertyChanged;
    private Command<ItemSelectionChangingEventArgs> selectedItem;

    public ObservableCollection<BookInfo> BookInfoCollection
    {
        get { return bookInfoCollection; }
        set
        {
            this.bookInfoCollection = value;
            this.OnPropertyChanged("BookInfoCollection");
        }
    }

    public Command<ItemSelectionChangingEventArgs> SelectedItem
    {
        get { return this.selectedItem; }
        set
        {
            this.selectedItem = value;
            this.OnPropertyChanged("SelectedItem");
        }
    }

        public void OnPropertyChanged(string name)
        {
            if (this.PropertyChanged != null)
                this.PropertyChanged(this, new PropertyChangedEventArgs(name));
        }

    public BookInfoRepository()
    {
        GenerateNewBookInfo();
        selectedItem = new Command<ItemSelectionChangingEventArgs>(OnSelectionChanging);
    }

        private void OnSelectionChanging(ItemSelectionChangingEventArgs obj)
        {
            var eventArgs = obj as ItemSelectionChangingEventArgs;
            if (eventArgs.AddedItems.Count > 0 && eventArgs.AddedItems[0] == this.BookInfoCollection[0])
                eventArgs.Cancel = true;
        }

        private void GenerateNewBookInfo()
        {
            BookInfoCollection = new ObservableCollection<BookInfo>();
            BookInfoCollection.Add(new BookInfo() { BookName = "Machine Learning Using C#", BookDescription = "You’ll learn several different approaches to applying machine learning"});
            BookInfoCollection.Add(new BookInfo() { BookName = "Object-Oriented Programming in C#", BookDescription = "Object-oriented programming is the de facto programming paradigm"});
            BookInfoCollection.Add(new BookInfo() { BookName = "C# Code Contracts", BookDescription = "Code Contracts provide a way to convey code assumptions"});
        }
    }
}
