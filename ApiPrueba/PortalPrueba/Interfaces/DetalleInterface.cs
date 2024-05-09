using BD.Models;
using Microsoft.AspNetCore.Mvc;
using PortalPrueba.Dtos;
using PortalPrueba.Models;

namespace PortalPrueba.Interfaces
{
    public interface DetalleInterface
    {
        Task<List<Detalle>> listDetalles();
        Task<Response> InsertDetalle(Detalle detalle);
    }
}
