using Azure.Identity;
using BLL.DAL;
using BLL.Models;
using BLL.Services.Bases;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BLL.Services
{
    public class AuthorService :ServiceBase, IService<Author, AuthorModel>
    {
        public AuthorService(Db db) : base(db)
        {
        }

        public ServiceBase Create(Author record)
        {
            throw new NotImplementedException();
        }

        public ServiceBase Delete(int id)
        {
            throw new NotImplementedException();
        }

        public IQueryable<AuthorModel> Query()
        {
            return _db.Author.OrderBy(a => a.Name).ThenBy(a => a.Surname).Select(a => new AuthorModel() { Record = a });
        }

        public ServiceBase Update(Author record)
        {
            throw new NotImplementedException();
        }

    }
}
