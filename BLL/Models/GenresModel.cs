using BLL.DAL;

namespace BLL.Models
{
    public class GenresModel
    {
        public Genres Record { get; set; }

        public string Name => Record.Name;

    }
}
