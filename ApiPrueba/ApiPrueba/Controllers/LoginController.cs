using BD.Interfaces;
using BD.Models;
using Microsoft.AspNetCore.Mvc;

namespace ApiPrueba.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LoginController : ControllerBase
    {
        private readonly ILogger<LoginController> _logger;
        private readonly LoginInterface _ILogin;

        public LoginController(ILogger<LoginController> logger, LoginInterface ILogin)
        {
            this._logger = logger;
            this._ILogin = ILogin;
        }

        [HttpPost]
        [Route("RegistrarUsuario")]
        public async Task<string> RegistrarUsuario([FromBody] Usuario usuario)
        {
            var res = string.Empty;
            try
            {
                 res = await _ILogin.RegistrarUsuario(usuario);
                return res;
            }
            catch (Exception)
            {
                throw;
            }

        }

        [HttpGet]
        [Route("ValidacionUsuario")]
        public async Task<string> ValidacionUsuario(string usuario, string pass)
        {
            var res = string.Empty;
            try
            {
                res = await _ILogin.ValidacionUsuario(usuario, pass);

                return res;
            }
            catch (Exception)
            {

                throw;
            }
        }

    }
}
