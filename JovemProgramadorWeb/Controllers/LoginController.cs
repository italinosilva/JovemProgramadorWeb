using JovemProgramadorWeb.Data.Repositorio.Interfaces;
using JovemProgramadorWeb.Models;
using Microsoft.AspNetCore.Mvc;
using System.Runtime.ConstrainedExecution;
using System.Text.Json;

namespace JovemProgramadorWeb.Controllers
{
    public class LoginController : Controller
    {
        private readonly IConfiguration _configuration;
        private readonly ILoginRepositorio _loginRepositorio;

        public LoginController(ILoginRepositorio loginRepositorio)
        {
            _loginRepositorio = loginRepositorio;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult FazerLogin(Login login)
        {
            try
            {
               var acesso = _loginRepositorio.ValidarUsuario(login);

                if (acesso != null)
                {
                    return RedirectToAction("Index", "Home");
                }

                else
                {
                    ViewData["MsgErro"] = "Usuário e/ou senha incorretos, tente novamente!";
                }
            }

            catch (Exception)
            {
                ViewData["MsgErro"] = "Erro ao buscar dados do usuário!";

            }

            return View("Index");
        }
    }
}
