using DEMO_TiendaJunior.Models;
using DEMO_TiendaJunior.Repositories.UsersInfo;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DEMO_TiendaJunior.Controllers
{
    [Authorize]
    public class RolesController : Controller
    {
        private readonly IRolesRepository _rolesRepository;
        public RolesController(IRolesRepository rolesRepository)
        {
            _rolesRepository = rolesRepository;
        }

        
        public ActionResult Index()
        {
            return View(_rolesRepository.GetAll());
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(RolesModel roles)
        {
            try
            {
                _rolesRepository.Add(roles);

                TempData["message"] = "Datos guardados exitosamente";

                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                TempData["message"] = ex.Message;

                return View(roles);
            }
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var rol = _rolesRepository.GetById(id);

            if (rol == null)
            {
                return NotFound();
            }

            return View(rol);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(RolesModel roles)
        {
            try
            {
                _rolesRepository.Edit(roles);

                TempData["message"] = "Datos editados correctamente";

                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                return View(roles);
            }
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            var rol = _rolesRepository.GetById(id);

            if (rol == null)
            {
                return NotFound();
            }

            return View(rol);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(RolesModel roles)
        {
            try
            {
                _rolesRepository.Delete(roles.Id_Roles);

                TempData["message"] = "Dato eliminado exitosamente";

                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                return View(roles);
            }
        }
    }
}
