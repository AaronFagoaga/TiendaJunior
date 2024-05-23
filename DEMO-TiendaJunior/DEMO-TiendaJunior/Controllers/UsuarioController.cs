using DEMO_TiendaJunior.Models;
using DEMO_TiendaJunior.Repositories.UsersInfo;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace DEMO_TiendaJunior.Controllers
{
    [Authorize]
    public class UsuarioController : Controller
    {
        private readonly IUsuarioRepository _usuarioRepository;
        private SelectList _rolesList;
        
        public UsuarioController(IUsuarioRepository usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
            _rolesList = new SelectList(
                                   _usuarioRepository.GetAllRoles(),
                                   nameof(RolesModel.Id_Roles),
                                   nameof(RolesModel.Nombre)
                           );
        }

        public ActionResult Index()
        {
            return View(_usuarioRepository.GetAll());
        }

        [HttpGet]
        public ActionResult Create()
        {
            ViewBag.Roles = _rolesList;

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(UsuarioModel usuario)
        {
            try
            {
                _usuarioRepository.Add(usuario);

                TempData["message"] = "Datos guardados exitosamente";

                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                TempData["message"] = ex.Message;

                ViewBag.Roles = _rolesList;

                return View(usuario);
            }
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var usuarios = _usuarioRepository.GetById(id);

            _rolesList = new SelectList(
                                       _usuarioRepository.GetAllRoles(),
                                       nameof(RolesModel.Id_Roles),
                                       nameof(RolesModel.Nombre),
                                       usuarios?.Roles?.Id_Roles
                                 );

            ViewBag.Roles = _rolesList;

            return View(usuarios);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(UsuarioModel usuario)
        {
            try
            {
                _usuarioRepository.Edit(usuario);

                TempData["message"] = "Datos editados correctamente";

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                ViewBag.Roles = _rolesList;

                return View(usuario);
            }
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            var usuarios = _usuarioRepository.GetById(id);

            if (usuarios == null)
            {
                return NotFound();
            }

            return View(usuarios);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(UsuarioModel usuario)
        {
            try
            {
                _usuarioRepository.Delete(usuario.Id_Usuario);

                TempData["message"] = "Dato eliminado exitosamente";

                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                return View(usuario);
            }
        }
    }
}
