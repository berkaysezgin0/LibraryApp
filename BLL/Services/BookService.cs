using BLL.DAL;
using BLL.Models;
using BLL.Services.Bases;
using Microsoft.EntityFrameworkCore;

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
            //Include(b=>b.Genres)
            return _db.Book.Include(b=>b.BookAuthor).ThenInclude(ba=>ba.Author).OrderByDescending(b => b.PublicationYear).ThenByDescending(b => b.IsAvailable).ThenBy(b => b.Name).
                 Select(b => new BookModel() { Record = b });
        }

        public ServiceBase Update(Book record)
        {
            if (_db.Book.Any(b => b.ID != record.ID && b.Name.ToLower() == record.Name.ToLower().Trim() && b.PublicationYear == record.PublicationYear))
                return Error("Book with the same name, publication year exists!");
            var entity = _db.Book.Include(b=>b.BookAuthor).SingleOrDefault(b => b.ID == record.ID);
            if (entity is null)
                return Error("Book not found!");
            _db.BookAuthor.RemoveRange(entity.BookAuthor);
            entity.Name = record.Name?.Trim();
            entity.IsAvailable = record.IsAvailable;
            entity.PublicationYear = record.PublicationYear;
            entity.ISBN = record.ISBN;
            entity.GenreID = record.GenreID;
            entity.BookAuthor = record.BookAuthor;
            _db.Update(entity);
            _db.SaveChanges();
            return Success("Book updated.");
        }
    }
}
