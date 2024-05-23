using DEMO_TiendaJunior.Models;
using DEMO_TiendaJunior.Repositories.Categoria;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DEMO_TiendaJunior.Controllers
{
    [Authorize]
    public class CategoriaController : Controller
    {
        private readonly ICategoriaRepository _categoriaRepository;

        public CategoriaController(ICategoriaRepository categoriaRepository)
        {
            _categoriaRepository = categoriaRepository;
        }

        public ActionResult Index()
        {
            return View(_categoriaRepository.GetAll());
        }

        public ActionResult Details(int id)
        {
            return View();
        }


        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CategoriaModel categoria)
        {
            try
            {
                _categoriaRepository.Add(categoria);

                TempData["message"] = "Datos guardados exitosamente";

                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                TempData["message"] = ex.Message;

                return View(categoria);
            }
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var categoria = _categoriaRepository.GetById(id);

            if (categoria == null)
            {
                return NotFound();
            }

            return View(categoria);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(CategoriaModel categoria)
        {
            try
            {
                _categoriaRepository.Edit(categoria);

                TempData["message"] = "Datos editados correctamente";

                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                return View(categoria);
            }
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            var categoria = _categoriaRepository.GetById(id);

            if (categoria == null)
            {
                return NotFound();
            }

            return View(categoria);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(CategoriaModel categoria)
        {
            try
            {
                _categoriaRepository.Delete(categoria.Id_Categoria);

                TempData["message"] = "Dato eliminado exitosamente";

                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                return View(categoria);
            }
        }

    }
}