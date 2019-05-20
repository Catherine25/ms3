using ms.Data;
using System;
using System.Collections.ObjectModel;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ms.UI
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class BookListViewPage : ContentPage
    {
        public ObservableCollection<Book> Books
        {
            get => books;
            set
            {
                books = value;
                OnPropertyChanged("books");
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

            listView.ItemsSource = Books;

            Books.Add(new Book()
            {
                Author = "author one",
                Desc = "desc one",
                Image = "capture.png"
            });
            Books.Add(new Book()
            {
                Author = "author two",
                Desc = "desc two",
                Image = "statue.png"
            });
            Books.Add(new Book()
            {
                Author = "author three",
                Desc = "desc three",
                Image = "user.png"
            });
        }

        async void Handle_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            if (e.Item == null)
                return;

            object selectedBook = ((ListView)sender).SelectedItem;

            await Navigation.PushAsync(new BookPage((Book)selectedBook));

            ((ListView)sender).SelectedItem = null;
        }

        private async void updateButton_Clicked(object sender, EventArgs e)
        {
            //try to update
            ObservableCollection<Book> newBooks = await BookLoader.loadDataAsync();

            if (newBooks != null)
            {
                books.Clear();
                //success code

                foreach (Book b in newBooks)
                    books.Add(b);
            }
            else
                //fail code
                await DisplayAlert("Update Failed",
                    "Couldn't update data, please try again later.",
                    "OK");

            books.Add(new Book());
        }
    }
}
