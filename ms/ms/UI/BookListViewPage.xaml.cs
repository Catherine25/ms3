using ms.Data;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ms.UI
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class BookListViewPage : ContentPage, INotifyPropertyChanged
    {
        private bool deleteMode = false;

        public ObservableCollection<Book> Books
        {
            get => books;
            set
            {
                books = value;
                listView.ItemsSource = books;
            }
        }

        private ObservableCollection<Book> books = new ObservableCollection<Book>();

        public BookListViewPage()
        {
            InitializeComponent();

            System.Diagnostics.Debug.WriteLine("");
            System.Diagnostics.Debug.WriteLine("BookListViewPage init");
            System.Diagnostics.Debug.WriteLine("");

            updateButton.Clicked += updateButton_Clicked;
        }

        async void Handle_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            if (e.Item == null)
                return;

            object selectedBook = ((ListView)sender).SelectedItem;

            if (deleteMode)
                books.Remove((Book)selectedBook);
            else
                await Navigation.PushAsync(new BookPage((Book)selectedBook));

            ((ListView)sender).SelectedItem = null;
        }

        private async void updateButton_Clicked(object sender, EventArgs e)
        {
            string url = "http://ec2-18-130-203-173.eu-west-2.compute.amazonaws.com/ms.json";

            ObservableCollection<Book> newBooks = await BookLoader.loadDataFromURLAsync(url);

            if (newBooks != null)
                Books = newBooks;
            else
                //fail code
                await DisplayAlert("Update Failed",
                    "Couldn't update data, please try again later.",
                    "OK");
        }

        private void DeleteButton_Clicked(object sender, EventArgs e)
        {
            deleteMode = !deleteMode;

            if(deleteMode)
                ((Button)sender).BackgroundColor = Color.DarkGray;
            else
                ((Button)sender).BackgroundColor = Color.LightGray;
        }
    }
}
