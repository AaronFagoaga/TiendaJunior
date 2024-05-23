using DEMO_TiendaJunior.Models;
using DEMO_TiendaJunior.Repositories.UsersInfo;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Security.Claims;

namespace DEMO_TiendaJunior.Controllers
{
    public class LoginController : Controller
    {
        private readonly ILoginRepository _loginRepository;
        private SelectList _userList;

        public LoginController(ILoginRepository loginRepository)
        {
            _loginRepository = loginRepository;
            _userList = new SelectList(
                                   _loginRepository.GetAllUsuarios(),
                                   nameof(UsuarioModel.Id_Usuario),
                                   nameof(UsuarioModel.Nombre)
                           );
        }

        [Authorize]
        public ActionResult Index()
        {
            return View(_loginRepository.GetAll());
        }

        [Authorize]
        [HttpGet]
        public ActionResult Create()
        {
            ViewBag.Usuarios = _userList;

            return View();
        }

        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(LoginModel login)
        {
            try
            {
                _loginRepository.Add(login);

                TempData["message"] = "Datos guardados exitosamente";

                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                TempData["message"] = ex.Message;

                ViewBag.Usuarios = _userList;

                return View(login);
            }
        }

        [Authorize]
        [HttpGet]
        public ActionResult Edit(int id)
        {
            var logins = _loginRepository.GetById(id);

            _userList = new SelectList(
                                       _loginRepository.GetAllUsuarios(),
                                       nameof(UsuarioModel.Id_Usuario),
                                       nameof(UsuarioModel.Nombre),
                                       logins?.Usuario?.Id_Roles
                                 );

            ViewBag.Usuarios = _userList;

            return View(logins);
        }

        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(LoginModel login)
        {
            try
            {
                _loginRepository.Edit(login);

                TempData["message"] = "Datos editados correctamente";

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                ViewBag.Usuarios = _userList;

                return View(login);
            }
        }

        [Authorize]
        [HttpGet]
        public ActionResult Delete(int id)
        {
            var logins = _loginRepository.GetById(id);

            if (logins == null)
            {
                return NotFound();
            }

            return View(logins);
        }

        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(LoginModel login)
        {
            try
            {
                _loginRepository.Delete(login.Id_Login);

                TempData["message"] = "Dato eliminado exitosamente";

                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                return View(login);
            }
        }

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(LoginModel login)
        {
            var credential = _loginRepository.GetCredentials(login.UserName, login.Contraseña);
            var rol = _loginRepository.GetAllRoles();

            if (credential != null)
            {
                credential.Rol = rol.FirstOrDefault(r => r.Id_Roles == credential.Id_Rol);
                TempData["RolUsername"] = credential?.Rol?.Nombre;
                HttpContext.SignInAsync("CookieAuth", new ClaimsPrincipal(new ClaimsIdentity(new List<Claim> { new Claim(ClaimTypes.Name, login.UserName) }, "CookieAuth")));

                return RedirectToAction("Index", "Home");

            }
            else
            {
                TempData["messageLogin"] = "Usuario o Contraseña Incorrectos, Vuelva a Intentarlo";
            }

            return View(login);
        }

        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync("CookieAuth");
            return RedirectToAction("Login", "Login");
        }
    }
}
