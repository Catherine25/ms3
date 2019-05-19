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
	public partial class BookCell : ViewCell
	{
        private ImageSource ImageSource { get; set; }
        private string Author, Desc;
        
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