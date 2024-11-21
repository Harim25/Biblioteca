using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Biblioteca.Controllers
{
    public class ExplorarController : Controller
    {
        // GET: ExplorarController
        public ActionResult Index()
        {
            return View();
        }

        // GET: ExplorarController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: ExplorarController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ExplorarController/Create
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

        // GET: ExplorarController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: ExplorarController/Edit/5
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

        // GET: ExplorarController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ExplorarController/Delete/5
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
