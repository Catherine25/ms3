using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ms.UI
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class BookCell : ViewCell
	{
        public Data.Book Book;
        public ImageSource ImageSource { get; set; }
        public string Author, Desc;

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

            Author = book.Author;
            Desc = book.Desc;
            ImageSource = (FileImageSource)ImageSource.FromFile(book.Image);

            Book = book;
        }
    }
}