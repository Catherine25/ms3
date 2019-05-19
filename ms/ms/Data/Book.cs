using System.ComponentModel;

namespace ms.Data
{
    public class Book : INotifyPropertyChanged
    {
        private string author, desc, imagePath;

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

        public string ImagePath
        {
            get { return imagePath; }
            set
            {
                imagePath = value;
                OnPropertyChanged("ImagePath");
            }
        }
    }
}
