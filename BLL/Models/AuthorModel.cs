using BLL.DAL;

namespace BLL.Models
{
    public class AuthorModel
    {
        public Author Record { get; set; }
        public string Name => Record.Name;
        public string Surname => Record.Surname;
        public string NameAndSurname => Record.Name + " " + Record.Surname;

    }
}
