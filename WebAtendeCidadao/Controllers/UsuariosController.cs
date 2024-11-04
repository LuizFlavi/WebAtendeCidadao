using Microsoft.AspNetCore.Mvc;
using WebAtendeCidadao.Models;
using WebAtendeCidadao.Services;

namespace WebAtendeCidadao.Controllers
{
    public class UsuariosController : Controller
    {
        private readonly WebAtendeCidadaoServices _apiservices;
        public UsuariosController(WebAtendeCidadaoServices apiservices) 
        {
            _apiservices = apiservices;
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(Login model)
        {
            var data = await _apiservices.Login(model);

            return View();
        }
    }
}
