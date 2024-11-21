using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Biblioteca.Controllers
{
    public class EstadisticasController : Controller
    {
        // GET: EstadisticasController
        public ActionResult Index()
        {
            return View();
        }

        // GET: EstadisticasController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: EstadisticasController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: EstadisticasController/Create
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

        // GET: EstadisticasController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: EstadisticasController/Edit/5
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

        // GET: EstadisticasController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: EstadisticasController/Delete/5
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
