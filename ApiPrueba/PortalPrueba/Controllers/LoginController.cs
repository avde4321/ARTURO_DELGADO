using Microsoft.AspNetCore.Mvc;
using PortalPrueba.Interfaces;
using PortalPrueba.Models;

namespace PortalPrueba.Controllers
{
    public class LoginController : Controller
    {
        readonly private LoginInterface loginInterface;

        public LoginController(LoginInterface _loginInterface)
        {
            this.loginInterface = _loginInterface;
        }


        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Logoneo(string usuario, string clave)
        {
            try
            {
                Response response = new Response();

                var res = await loginInterface.Logoneo(usuario, clave);

                if (res.Equals("OK"))
                {
                    response.data = "Acceso correcto";
                    response.status = res;
                    response.code = 0;
                    return base.Json(response);
                }
                else
                {
                    response.data = "El usuario o clave es incorrecto";
                    response.status = res;
                    response.code = 1;
                    return base.Json(response);
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
