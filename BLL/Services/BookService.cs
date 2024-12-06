using BLL.DAL;
using BLL.Models;
using BLL.Services.Bases;

namespace BLL.Services
{
    public interface IBookService
    {
        public IQueryable<BookModel> Query();

        public ServiceBase Create(Book record);
        public ServiceBase Update(Book record);
        public ServiceBase Delete(int id);
    }
    public class BookService : ServiceBase, IBookService
    {
        public BookService(Db db) : base(db)
        {
        }

        public ServiceBase Create(Book record)
        {
            if (_db.Book.Any(b => b.Name.ToLower() == record.Name.ToLower().Trim() && b.PublicationYear == record.PublicationYear))
                return Error("Book with the same name, publication year exists!");
            record.Name = record.Name?.Trim();
            _db.Add(record);
            _db.SaveChanges();
            return Success("Book created.");
        }

        public ServiceBase Delete(int id)
        {
            var entity = _db.Book.SingleOrDefault(b => b.ID == id);
            if (entity is null)
                return Error("Book can't be found");
            _db.Book.Remove(entity);
            _db.SaveChanges();
            return Success("Book deleted");
        }

        public IQueryable<BookModel> Query()
        {
            return _db.Book.OrderByDescending(b => b.PublicationYear).ThenByDescending(b => b.IsAvailable).ThenBy(b => b.Name).
                 Select(b => new BookModel() { Record = b });
        }

        public ServiceBase Update(Book record)
        {
            if (_db.Book.Any(b => b.ID != record.ID && b.Name.ToLower() == record.Name.ToLower().Trim() && b.PublicationYear == record.PublicationYear))
                return Error("Book with the same name, publication year exists!");
            record.Name = record.Name?.Trim();
            _db.Update(record);
            _db.SaveChanges();
            return Success("Book updated.");
        }
    }
}
