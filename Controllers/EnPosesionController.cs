using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Biblioteca.Controllers
{
    public class EnPosesionController : Controller
    {
        // GET: En_posesionController
        public ActionResult Index()
        {
            return View();
        }

        // GET: En_posesionController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: En_posesionController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: En_posesionController/Create
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

        // GET: En_posesionController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: En_posesionController/Edit/5
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

        // GET: En_posesionController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: En_posesionController/Delete/5
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
