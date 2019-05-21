using Plugin.Settings;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace ms
{
    public partial class App : Application
    {
        UI.BookListViewPage navigationPage;

        public App()
        {
            InitializeComponent();

            navigationPage  = new UI.BookListViewPage();
            MainPage = new NavigationPage(navigationPage);
        }

        protected override void OnStart()
        {
            string s = CrossSettings.Current.GetValueOrDefault("books", "");

            if(s != "")
                navigationPage.Books = Data.BookLoader.parseToObject(s);
        }

        protected override void OnSleep()
        {
            string s = Data.BookLoader.parseToJSON(navigationPage.Books);

            CrossSettings.Current.AddOrUpdateValue("books", s);
        }

        protected override void OnResume() { }
    }
}
