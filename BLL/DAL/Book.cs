using System.ComponentModel.DataAnnotations;

namespace BLL.DAL
{
    public class Book
    {
        public int ID { get; set; }

        [Required]
        [StringLength(50)]
        public string Name {  get; set; }

        public bool IsAvailable { get; set; }

        public DateTime? PublicationYear { get; set; }

        public string ISBN { get; set; }

        public int AuthorID { get; set; }
        public Author Author { get; set; }

        public int GenreID { get; set; }
        public Genres Genre { get; set; }
        public List<BookAuthor> BookAuthor {  get; set; }=new List<BookAuthor>();
    }
}
