using BD.Models;
using Microsoft.AspNetCore.Mvc;
using PortalPrueba.Interfaces;

namespace PortalPrueba.Controllers
{
    public class DetalleController : Controller
    {
        private readonly DetalleInterface _IDetalle;

        public DetalleController(DetalleInterface IDetalle)
        {
            this._IDetalle = IDetalle;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> listDetalles()
        {
            try
            {
                var res = await _IDetalle.listDetalles();

                return PartialView("DetalleCons", res);
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpPost]
        [Route("InsertDetalle")]
        public async Task<IActionResult> InsertDetalle([FromBody] Detalle detalle)
        {
            try
            {
                var res = await _IDetalle.InsertDetalle(detalle);

                return base.Json(res);
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
