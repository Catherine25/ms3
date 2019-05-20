using System.ComponentModel;

namespace ms.Data
{
    public class Book : INotifyPropertyChanged
    {
        private string author, desc, image;

        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged(string prop = "") =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));

        public string Author
        {
            get => author;
            set
            {
                author = value;
                OnPropertyChanged("Author");
            }
        }

        public string Desc
        {
            get => desc;
            set
            {
                desc = value;
                OnPropertyChanged("Desc");
            }
        }

        public string Image
        {
            get { return image; }
            set
            {
                image = value;
                OnPropertyChanged("Image");
            }
        }
    }
}
