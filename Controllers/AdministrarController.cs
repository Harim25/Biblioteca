using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Biblioteca.Controllers
{
    public class AdministrarController : Controller
    {
        // GET: AdministrarController
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Autores()
        {
            return View();
        }
        public ActionResult Catalogo()
        {
            return View();
        }
        public ActionResult Generos()
        {
            return View();
        }
        public ActionResult LibrosPrestados()
        {
            return View();
        }
        public ActionResult Usuarios()
        {
            return View();
        }
        public ActionResult CrearEditarAutor()
        {
            return View();
        }
        public ActionResult CrearEditarGenero()
        {
            return View();
        }
        public ActionResult CrearEditarLibro()
        {
            return View();
        }

        //De aqui pa abajo ya no le sé. xd - Uziel
        // GET: AdministrarController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: AdministrarController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: AdministrarController/Create
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

        // GET: AdministrarController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: AdministrarController/Edit/5
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

        // GET: AdministrarController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: AdministrarController/Delete/5
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
