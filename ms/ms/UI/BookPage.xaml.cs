using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ms.UI
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class BookPage : ContentPage
	{
        string Author, Desc;
        ImageSource ImageSource;

        public BookPage(Data.Book book)
        {
            InitializeComponent();

            Author = book.Author;
            Desc = book.Desc;
            ImageSource = (FileImageSource)ImageSource.FromFile(book.Image);

            System.Diagnostics.Debug.WriteLine("");
            System.Diagnostics.Debug.WriteLine("BookPage init");
            System.Diagnostics.Debug.WriteLine("");
        }

        private void Back_Clicked(object sender, EventArgs e) => Navigation.PopAsync();
    }
}