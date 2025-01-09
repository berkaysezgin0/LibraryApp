using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using BLL.Controllers.Bases;
using BLL.Services.Bases;
using BLL.Models;
using BLL.DAL;
using BLL.Services;

// Generated from Custom Template.

namespace MVC.Controllers
{
    public class BooksController : MvcController
    {
        // Service injections:
        private readonly IBookService _bookService;
        private readonly IService _genreService;

        /* Can be uncommented and used for many to many relationships. {Entity} may be replaced with the related entiy name in the controller and views. */
        private readonly IService<Author, AuthorModel> _authorService;

        public BooksController(
			IBookService bookService
            , IService  genreService

            /* Can be uncommented and used for many to many relationships. {Entity} may be replaced with the related entiy name in the controller and views. */
            , IService<Author, AuthorModel> authorService
        )
        {
            _bookService = bookService;
            _genreService = genreService;

            /* Can be uncommented and used for many to many relationships. {Entity} may be replaced with the related entiy name in the controller and views. */
            _authorService = authorService;
        }

        // GET: Books
        public IActionResult Index()
        {
            // Get collection service logic:
            var list = _bookService.Query().ToList();
            return View(list);
        }

        // GET: Books/Details/5
        public IActionResult Details(int id)
        {
            // Get item service logic:
            var item = _bookService.Query().SingleOrDefault(q => q.Record.ID == id);
            return View(item);
        }

        protected void SetViewData()
        {
            // Related items service logic to set ViewData (Record.Id and Name parameters may need to be changed in the SelectList constructor according to the model):
            ViewData["GenreID"] = new SelectList(_genreService.Query().ToList(), "Record.ID", "Name");
            
            /* Can be uncommented and used for many to many relationships. {Entity} may be replaced with the related entiy name in the controller and views. */
            ViewBag.AuthorIDs = new MultiSelectList(_authorService.Query().ToList(), "Record.ID", "NameAndSurname");
        }

        // GET: Books/Create
        public IActionResult Create()
        {
            SetViewData();
            return View();
        }

        // POST: Books/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(BookModel book)
        {
            if (ModelState.IsValid)
            {
                // Insert item service logic:
                var result = _bookService.Create(book.Record);
                if (result.IsSuccessful)
                {
                    TempData["Message"] = result.Message;
                    return RedirectToAction(nameof(Details), new { id = book.Record.ID });
                }
                ModelState.AddModelError("", result.Message);
            }
            SetViewData();
            return View(book);
        }

        // GET: Books/Edit/5
        public IActionResult Edit(int id)
        {
            // Get item to edit service logic:
            var item = _bookService.Query().SingleOrDefault(q => q.Record.ID == id);
            SetViewData();
            return View(item);
        }

        // POST: Books/Edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(BookModel book)
        {
            if (ModelState.IsValid)
            {
                // Update item service logic:
                var result = _bookService.Update(book.Record);
                if (result.IsSuccessful)
                {
                    TempData["Message"] = result.Message;
                    return RedirectToAction(nameof(Details), new { id = book.Record.ID });
                }
                ModelState.AddModelError("", result.Message);
            }
            SetViewData();
            return View(book);
        }

        // GET: Books/Delete/5
        public IActionResult Delete(int id)
        {
            // Get item to delete service logic:
            var item = _bookService.Query().SingleOrDefault(q => q.Record.ID == id);
            return View(item);
        }

        // POST: Books/Delete
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            // Delete item service logic:
            var result = _bookService.Delete(id);
            TempData["Message"] = result.Message;
            return RedirectToAction(nameof(Index));
        }
	}
}
