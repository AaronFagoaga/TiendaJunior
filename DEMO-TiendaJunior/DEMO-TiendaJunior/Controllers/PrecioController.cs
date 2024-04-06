using DEMO_TiendaJunior.Models;
using DEMO_TiendaJunior.Repositories.Precios;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace DEMO_TiendaJunior.Controllers
{
    public class PrecioController : Controller
    {
        private readonly IPreciosRepository _preciosRepository;

        private SelectList _productosList;
        public PrecioController(IPreciosRepository preciosRepository)
        {
            _preciosRepository = preciosRepository;
            _productosList = new SelectList(
                                        _preciosRepository.GetAllProductos(),
                                        nameof(ProductoModel.Id_Producto),
                                        nameof(ProductoModel.Nombre_Producto)
                                    );
        }

        public ActionResult Index()
        {
            return View(_preciosRepository.GetAll());
        }

        [HttpGet]
        public ActionResult Create()
        {
            ViewBag.ProductosModel = _productosList;
            return View();
        }

        // POST: PrecioController/Create
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

        // GET: PrecioController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: PrecioController/Edit/5
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

        // GET: PrecioController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: PrecioController/Delete/5
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
