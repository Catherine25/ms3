using System.ComponentModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ms.UI
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class BookCell : ViewCell, INotifyPropertyChanged
	{
        public Data.Book Book { get; set; }
        public ImageSource Image { get; set; }
        public string Author { get; set; }
        public string Desc { get; set; }

        public BookCell()
        {
            InitializeComponent();

            System.Diagnostics.Debug.WriteLine("");
            System.Diagnostics.Debug.WriteLine("BookCell init");
            System.Diagnostics.Debug.WriteLine("");
        }

        public BookCell(Data.Book book)
        {
            InitializeComponent();

            Image = (FileImageSource)ImageSource.FromFile(book.Image);

            Author = book.Author;
            Desc = book.Desc;

            Book = book;
        }
    }
}