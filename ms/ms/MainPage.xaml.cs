using Xamarin.Forms;

namespace ms
{
    public partial class MainPage : ContentPage
    {
        public void setBookListViewPage() => Navigation.PopToRootAsync();
        public void setBookPage() => Navigation.PushAsync(new UI.BookPage());

        public MainPage() => InitializeComponent();
    }
}
