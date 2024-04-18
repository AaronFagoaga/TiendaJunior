using DEMO_TiendaJunior.Models;
using DEMO_TiendaJunior.Repositories.DetallesVentas;
using DEMO_TiendaJunior.Repositories.Precios;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace DEMO_TiendaJunior.Controllers
{
	public class DetallesController : Controller
	{
		private readonly IDetalleRepository _detallesRepository;

		private SelectList _productosList;

		int IndexDeVenta;

		public DetallesController(IDetalleRepository detallesRepository)
		{
			_detallesRepository = detallesRepository;
			_productosList = new SelectList(
										_detallesRepository.GetAllProductos(),
										nameof(ProductoModel.Id_Producto),
										nameof(ProductoModel.Nombre_Producto)
									);
		}
        
		[HttpGet]
        public ActionResult Index(int Id_Venta)
        {
			IndexDeVenta = Id_Venta;
            var detalles = _detallesRepository.GetAllByIdVenta(Id_Venta);
            return View(detalles);
        }

		[HttpGet]
		public ActionResult Create()
        {
            ViewBag.Productos = _productosList;
            return View();
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Create(DetalleModel detalle)
		{
			try
			{
				_detallesRepository.Add(detalle);

				TempData["message"] = "Datos guardados exitosamente";

                return RedirectToAction("Index", "Ventas");
            }
			catch(Exception ex)
			{
				TempData["message"] = ex.Message;
                ViewBag.Productos = _productosList;
                return View(detalle);
			}
		}

		[HttpGet]
		public ActionResult Edit(int id)
		{
            var detalles = _detallesRepository.GetById(id);
            
			if (detalles == null)
            {
                return NotFound();
            }
            _productosList = new SelectList(
                _detallesRepository.GetAllProductos(),
                nameof(ProductoModel.Id_Producto),
                nameof(ProductoModel.Nombre_Producto),
                detalles?.Producto?.Id_Producto
            );

            ViewBag.Products = _productosList;
            return View(detalles);
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Edit(DetalleModel detalle)
		{
			try
			{
				_detallesRepository.Edit(detalle);

                return RedirectToAction("Index", "Ventas");
            }
			catch
			{
                ViewBag.Products = _productosList;
                return View(detalle);
			}
		}

		[HttpGet]
		public ActionResult Delete(int id)
		{
			return View();
		}

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
