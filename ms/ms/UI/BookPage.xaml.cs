using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ms.UI
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class BookPage : ContentPage, INotifyPropertyChanged
    {
        public BookPage(Data.Book book)
        {
            InitializeComponent();

            //Author = book.Author;
            //Desc = book.Desc;
            //Image = (FileImageSource)ImageSource.FromFile(book.Image);

            System.Diagnostics.Debug.WriteLine("");
            System.Diagnostics.Debug.WriteLine("BookPage init");
            System.Diagnostics.Debug.WriteLine("");

            this.authorLabel.Text = book.Author;
            this.descLabel.Text = book.Desc;
            this.imageName.Source = (FileImageSource)ImageSource.FromFile(book.Image);
        }
    }
}