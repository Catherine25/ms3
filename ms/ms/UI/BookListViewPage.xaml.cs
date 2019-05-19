using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ms.UI
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class BookListViewPage : ContentPage
    {
        public ObservableCollection<Data.Book> books { get; set; }

        public BookListViewPage()
        {
            InitializeComponent();

            books = new ObservableCollection<Data.Book>
            {
                new Data.Book(),
                new Data.Book(),
                new Data.Book(),
                new Data.Book(),
                new Data.Book()
            };
			
			this.listView.ItemsSource = books;
        }

        async void Handle_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            if (e.Item == null)
                return;

            await Navigation.PushAsync(new BookPage());
                //DisplayAlert("Item Tapped", "An item was tapped.", "OK");

            //deselect Item
            ((ListView)sender).SelectedItem = null;
        }

        private void updateButtonClicked(object sender, EventArgs e)
        {
            //try to update
            Data.BookLoader.loadData();

            if (Data.BookLoader.result == null)
                //success code
                books = Data.BookLoader.result;
            else
                //fail code
                DisplayAlert("Update Failed",
                    "Couldn't update data, try again later.",
                    "OK");
        }
    }
}
