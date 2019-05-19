using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ms.UI
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class BookCell : ViewCell
	{
        public ImageSource ImageSource { get; set; }
        public string Author, Desc;
        
        public BookCell() => InitializeComponent();

        public BookCell(Data.Book book)
        {
            InitializeComponent();

            Author = book.Author;
            Desc = book.Desc;
            ImageSource = (FileImageSource)ImageSource.FromFile(book.ImagePath);
        }
    }
}