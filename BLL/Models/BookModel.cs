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

    }
}
