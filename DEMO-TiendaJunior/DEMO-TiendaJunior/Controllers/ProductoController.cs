using DEMO_TiendaJunior.Models;
using DEMO_TiendaJunior.Repositories.Productos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace DEMO_TiendaJunior.Controllers
{
    public class ProductoController : Controller
    {
        private readonly IProductoRepository _productoRepository;
        private SelectList _categoriasList;


        public ProductoController(IProductoRepository productoRepository)
        {
            _productoRepository = productoRepository;
            _categoriasList = new SelectList(
                                   _productoRepository.GetAllCategorias(),
                                   nameof(CategoriaModel.Id_Categoria),
                                   nameof(CategoriaModel.Nombre)
                           );
        }

        public IActionResult Index()
        {
            return View(_productoRepository.GetAll());
        }


        [HttpGet]
        public ActionResult Create()
        {
            ViewBag.Categories = _categoriasList;

            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ProductoModel productos)
        {
            try
            {
                _productoRepository.Add(productos);

                TempData["message"] = "Datos guardados exitosamente";

                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                TempData["message"] = ex.Message;

                ViewBag.Categories = _categoriasList;

                return View(productos);
            }
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var productos = _productoRepository.GetById(id);

            _categoriasList = new SelectList(
                                       _productoRepository.GetAllCategorias(),
                                       nameof(CategoriaModel.Id_Categoria),
                                       nameof(CategoriaModel.Nombre),
                                       productos?.Categoria?.Id_Categoria
                                 );

            ViewBag.Categories = _categoriasList;

            return View(productos);

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(ProductoModel productos)
        {
            try
            {
                _productoRepository.Edit(productos);

                TempData["message"] = "Datos editados correctamente";

                return RedirectToAction(nameof(Index));
            }
            catch 
            {
                ViewBag.Categories = _categoriasList;

                return View(productos);
            }
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            var productos = _productoRepository.GetById(id);

            if (productos == null)
            {
                return NotFound();
            }

            return View(productos);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(ProductoModel productos)
        {
            try
            {
                _productoRepository.Delete(productos.Id_Producto);

                TempData["message"] = "Dato eliminado exitosamente";

                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                return View(productos);
            }
        }
    }
}