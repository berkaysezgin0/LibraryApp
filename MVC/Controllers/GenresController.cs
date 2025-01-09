using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using BLL.Controllers.Bases;
using BLL.Services.Bases;
using BLL.Models;
using BLL.DAL;
using BLL.Services;
using Microsoft.AspNetCore.Authorization;

// Generated from Custom Template.

namespace MVC.Controllers
{
    [Authorize(Roles = "Admin")]
    public class GenresController : MvcController
    {
        // Service injections:
        private readonly IService _genresService;

        /* Can be uncommented and used for many to many relationships. {Entity} may be replaced with the related entiy name in the controller and views. */
        //private readonly IService<{Entity}, {Entity}Model> _{Entity}Service;

        public GenresController(
			IService genresService

            /* Can be uncommented and used for many to many relationships. {Entity} may be replaced with the related entiy name in the controller and views. */
            //, Service<{Entity}, {Entity}Model> {Entity}Service
        )
        {
            _genresService = genresService;

            /* Can be uncommented and used for many to many relationships. {Entity} may be replaced with the related entiy name in the controller and views. */
            //_{Entity}Service = {Entity}Service;
        }

        // GET: Genres
        
        public IActionResult Index()
        {
            // Get collection service logic:
            var list = _genresService.Query().ToList();
            return View(list);
        }

        // GET: Genres/Details/5
        public IActionResult Details(int id)
        {
            // Get item service logic:
            var item = _genresService.Query().SingleOrDefault(q => q.Record.ID == id);
            return View(item);
        }

        protected void SetViewData()
        {
            // Related items service logic to set ViewData (Record.Id and Name parameters may need to be changed in the SelectList constructor according to the model):
            
            /* Can be uncommented and used for many to many relationships. {Entity} may be replaced with the related entiy name in the controller and views. */
            //ViewBag.{Entity}Ids = new MultiSelectList(_{Entity}Service.Query().ToList(), "Record.Id", "Name");
        }

        // GET: Genres/Create
        public IActionResult Create()
        {
            SetViewData();
            return View();
        }

        // POST: Genres/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(GenresModel genres)
        {
            if (ModelState.IsValid)
            {
                // Insert item service logic:
                var result = _genresService.Create(genres.Record);
                if (result.IsSuccessful)
                {
                    TempData["Message"] = result.Message;
                    return RedirectToAction(nameof(Details), new { id = genres.Record.ID });
                }
                ModelState.AddModelError("", result.Message);
            }
            SetViewData();
            return View(genres);
        }

        // GET: Genres/Edit/5
        public IActionResult Edit(int id)
        {
            // Get item to edit service logic:
            var item = _genresService.Query().SingleOrDefault(q => q.Record.ID == id);
            SetViewData();
            return View(item);
        }

        // POST: Genres/Edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(GenresModel genres)
        {
            if (ModelState.IsValid)
            {
                // Update item service logic:
                var result = _genresService.Update(genres.Record);
                if (result.IsSuccessful)
                {
                    TempData["Message"] = result.Message;
                    return RedirectToAction(nameof(Details), new { id = genres.Record.ID });
                }
                ModelState.AddModelError("", result.Message);
            }
            SetViewData();
            return View(genres);
        }

        // GET: Genres/Delete/5
        public IActionResult Delete(int id)
        {
            // Get item to delete service logic:
            var item = _genresService.Query().SingleOrDefault(q => q.Record.ID == id);
            return View(item);
        }

        // POST: Genres/Delete
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            // Delete item service logic:
            var result = _genresService.Delete(id);
            TempData["Message"] = result.Message;
            return RedirectToAction(nameof(Index));
        }
	}
}
