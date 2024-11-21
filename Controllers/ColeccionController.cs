using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Biblioteca.Controllers
{
    public class ColeccionController : Controller
    {
        // GET: ColeccionController
        public ActionResult Index()
        {
            return View();
        }

        // GET: ColeccionController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: ColeccionController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ColeccionController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ColeccionController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: ColeccionController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ColeccionController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ColeccionController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
