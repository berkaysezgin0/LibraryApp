using BLL.DAL;
using BLL.Models;
using BLL.Services.Bases;
using Microsoft.EntityFrameworkCore;

namespace BLL.Services
{
    public interface IService
    {
        public IQueryable<GenresModel> Query();

        public ServiceBase Create(Genres record);
        public ServiceBase Update(Genres record);
        public ServiceBase Delete(int id);
    }

    public class GenresService : ServiceBase, IService
    {
        public GenresService(Db db) : base(db)
        {
        }

        public ServiceBase Create(Genres record)
        {
            if (_db.Genre.Any(g => g.Name.ToUpper() == record.Name.ToUpper().Trim()))
                return Error("Genres with the same name exists!");
            record.Name = record.Name?.Trim();
            _db.Genre.Add(record);
            _db.SaveChanges();
            return Success("Genres created.");
        }

        public ServiceBase Delete(int id)
        {
            var entity = _db.Genre.Include(g=>g.Book).SingleOrDefault(g => g.ID == id);
            if (entity is null)
                return Error("Genres can't be found!");
            if (entity.Book.Any())
                return Error("Genres has relational books");
            _db.Genre.Remove(entity); 
            _db.SaveChanges();
            return Success("Genres deleted.");
        }

        public IQueryable<GenresModel> Query()
        {
            return _db.Genre.OrderBy(g => g.Name).Select(g => new GenresModel() { Record = g });
        }

        public ServiceBase Update(Genres record)
        {
            if (_db.Genre.Any(g => g.ID != record.ID && g.Name.ToUpper() == record.Name.ToUpper().Trim()))
                return Error("Genres with the same name exists!");
            var entity = _db.Genre.SingleOrDefault(g => g.ID == record.ID);
            if (entity == null)
            {
                return Error("Genres can't be found!");
            }
            entity.Name = record.Name?.Trim();
            _db.Genre.Update(entity);
            return Success("Genres updated.");
        }
    }
}
