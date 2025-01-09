using BLL.DAL;
using System.ComponentModel;

namespace BLL.Models
{
    public class BookModel
    {
        public Book Record { get; set; }

        public string Name => Record.Name;

        [DisplayName("Gender")] // title: DisplayNameFor HTML Helper
        public string IsAvailable => Record.IsAvailable ? "Yes" : "No";

        public string PublicationYear => !Record.PublicationYear.HasValue ? string.Empty : Record.PublicationYear.Value.ToString("MM/dd/yyy");

        public string ISBN => Record.ISBN;

        public string Genre => Record.Genre?.Name;

        public string Author => string.Join("<br>", Record.BookAuthor?.Select(ba => ba.Author?.Name + " " + ba.Author?.Surname));

        [DisplayName("Authors")]
        public List<int> AuthorIDs
        {
            get => Record.BookAuthor?.Select(ba => ba.BookID).ToList();
            set => Record.BookAuthor = value.Select(v => new BookAuthor() { AuthorID = v }).ToList();
        }
    }
}
