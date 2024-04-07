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
        public ActionResult Create(PrecioModel precio)
        {
            try
            {
                _preciosRepository.Add(precio);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                ViewBag.ProductosModel = _productosList;
                return View();
            }
        }

        // GET: PrecioController/Edit/5
        public ActionResult Edit(int id)
        {
            var precio = _preciosRepository.GetById(id);

            _productosList = new SelectList(
                                    _preciosRepository.GetAllProductos(),
                                    nameof(ProductoModel.Id_Producto),
                                    nameof(ProductoModel.Nombre_Producto),
                                    precio?.Producto?.Id_Producto
                );
            ViewBag.ProductoModel = _productosList;

            return View(precio);
        }

        // POST: PrecioController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(PrecioModel precio)
        {
            try
            {
                _preciosRepository.Edit(precio);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                ViewBag.ProductModel = _productosList;
                return View(precio);
            }
        }

        // GET: PrecioController/Delete/5
        public ActionResult Delete(int id)
        {
            var precio = _preciosRepository.GetById(id);

            if (precio == null)
            {
                return NotFound();
            }

            return View(precio);
        }

        // POST: PrecioController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(PrecioModel precio)
        {
            try
            {
                _preciosRepository.Delete(precio.Id_Precio);

                TempData["message"] = "Dato eliminado exitosamente";

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}