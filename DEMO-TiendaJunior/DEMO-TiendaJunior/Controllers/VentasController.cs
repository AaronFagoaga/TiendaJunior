using Microsoft.AspNetCore.Mvc;
using DEMO_TiendaJunior.Repositories.Venta;
using DEMO_TiendaJunior.Models;

namespace DEMO_TiendaJunior.Controllers
{
    public class VentasController : Controller
    {
        private readonly IVentaRepository _ventasRepository;

        public VentasController(IVentaRepository ventasRepository)
        {
            _ventasRepository = ventasRepository;
        }

        public ActionResult Index()
        {
            return View(_ventasRepository.GetAll());
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
        public ActionResult Create(VentasModel ventas)
        {
            try
            {
                _ventasRepository.Add(ventas);

                //for (int i = 0; i < products.Length; i++)
                //{
                //    VentaDetalle.Add({
                //        venta_id = venta->id,
                //            product_id = 
                //    })
                //}

                TempData["message"] = "Datos guardados exitosamente";

                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                TempData["message"] = ex.Message;

                return View(ventas);
            }
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var ventas = _ventasRepository.GetById(id);

            if (ventas == null)
            {
                return NotFound();
            }

            return View(ventas);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(VentasModel ventas)
        {
            try
            {
                _ventasRepository.Edit(ventas);

                TempData["message"] = "Datos editados correctamente";

                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                return View(ventas);
            }
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            var ventas = _ventasRepository.GetById(id);

            if (ventas == null)
            {
                return NotFound();
            }

            return View(ventas);
        }

        // POST: FacultyController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(VentasModel ventas)
        {
            try
            {
                _ventasRepository.Delete(ventas.Id_Venta);

                TempData["message"] = "Dato eliminado exitosamente";

                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                return View(ventas);
            }
        }
    }
}
