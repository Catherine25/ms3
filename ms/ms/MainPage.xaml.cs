using Xamarin.Forms;

namespace ms
{
    public partial class MainPage : ContentPage
    {
        private UI.BookListViewPage bookListViewPage = new UI.BookListViewPage();
        private UI.BookPage bookPage = new UI.BookPage();

        public void setBookListViewPage() => Navigation.PopToRootAsync();
        public void setBookPage() => Navigation.PushAsync(bookPage);

        public MainPage() => InitializeComponent();
    }
}
