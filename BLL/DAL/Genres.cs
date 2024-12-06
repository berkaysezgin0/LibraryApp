using System.ComponentModel.DataAnnotations;

namespace BLL.DAL
{
    public class Genres
    {
        public int ID { get; set; }

        [Required]
        [StringLength(40)]
        public string Name { get; set; }

        public List<Book> Book { get; set; } = new List<Book>();
    }
}
