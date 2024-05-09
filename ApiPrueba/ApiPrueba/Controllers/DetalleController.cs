using ApiPrueba.Models;
using BD.Interfaces;
using BD.Models;
using Microsoft.AspNetCore.Mvc;

namespace ApiPrueba.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DetalleController : Controller
    {
        private readonly DetalleInterface IDetalle;

        public DetalleController(DetalleInterface _IDetalle) 
        {
            this.IDetalle = _IDetalle;
        }


        [HttpGet]
        [Route("ListaDetalles")]
        public async Task<List<Detalle>> ListaDetalles()
        { 
            var list = new List<Detalle>();
            try
            {
                list = await IDetalle.ListaDetalles();

                return list;
            }
            catch (Exception)
            {

                throw;
            }
        }

        [HttpPost]
        [Route("InsertDeatlle")]
        public async Task<Response> InsertDeatlle([FromBody] Detalle detalle)
        {
            Response resp = new Response();
            var res = string.Empty;
            try
            {
                res = await IDetalle.InsertDeatlle(detalle);

                if (res.Equals("OK"))
                {
                    resp.data = "El detalle se creó correctamente";
                    resp.status = res;
                    resp.code = 0;
                }
                else
                {
                    resp.data = "Se presentó una novedad al insertar el registro";
                    resp.status = res;
                    resp.code = 1;
                }
                
            }
            catch (Exception)
            {

                throw;
            }

            return resp;
        }

    }
}
