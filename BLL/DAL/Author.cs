using System.ComponentModel.DataAnnotations;

namespace BLL.DAL
{
    public class Author
    {
        public int ID { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        [Required]
        [StringLength(50)]
        public string Surname { get; set; }

        public DateTime BirthDate { get; set; }

        public int NumberofWork { get; set; }

        //public List<Book> Book { get; set; } = new List<Book>();
        public List<BookAuthor> BookAuthor { get; set; } = new List<BookAuthor>();
    }
}