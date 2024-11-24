using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Biblioteca.Controllers
{
    public class CanjearCodigoController : Controller
    {
        // GET: Canjear_codigoController
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult CanjearCodigo()
        {
            return View();
        }
        public ActionResult DetallesPrestamo()
        {
            return View();
        }

        // GET: Canjear_codigoController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Canjear_codigoController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Canjear_codigoController/Create
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

        // GET: Canjear_codigoController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Canjear_codigoController/Edit/5
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

        // GET: Canjear_codigoController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Canjear_codigoController/Delete/5
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
