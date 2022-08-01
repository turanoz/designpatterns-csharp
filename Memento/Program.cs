using System;

namespace Memento
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Book book = new Book
            {
                Author = "Hugo",
                Title = "Sefiller",
                Isbn = "1231323"
            };
            book.ShowBook();
            CareTaker history = new CareTaker();
            history.Memento = book.CreateUndo();

            book.Isbn = "36652";
            book.Title = "SEFİLLER";
            book.ShowBook();
            
            book.RestoreFromUndo(history.Memento);

            book.ShowBook();
            
        }
    }

    class Book
    {
        public string Title
        {
            get => _title;
            set
            {
                _title = value;
                SetLastEdited();
            }
        }
 
        public string Author
        {
            get => _author;
            set
            {
                _author = value;
                SetLastEdited();
            }
        }

        public string Isbn
        {
            get => _isbn;
            set
            {
                _isbn = value;
                SetLastEdited();
            }
        }

        private DateTime _lastEdited;
        private string _title;
        private string _author;
        private string _isbn;


        private void SetLastEdited()
        {
            _lastEdited = DateTime.UtcNow;
        }

        public Memento CreateUndo()
        {
            return new Memento(_isbn, _author, _title, _lastEdited);
        }

        public void RestoreFromUndo(Memento memento)
        {
            _title = memento.Title;
            _author = memento.Author;
            _isbn = memento.Isbn;
            _lastEdited = memento.LastEdited;
        }

        public void ShowBook()
        {
            Console.WriteLine("{0},{1},{2} edited : {3}",Isbn,Title,Author,_lastEdited);
        }
    }

    class Memento
    {
        public string Isbn { get; set; }
        public string Author { get; set; }
        public string Title { get; set; }
        public DateTime LastEdited { get; set; }

        public Memento(string isbn, string author, string title, DateTime lastEdited)
        {
            Isbn = isbn;
            Author = author;
            Title = title;
            LastEdited = lastEdited;
        }
    }

    class CareTaker
    {
        public Memento Memento { get; set; }
    }
}