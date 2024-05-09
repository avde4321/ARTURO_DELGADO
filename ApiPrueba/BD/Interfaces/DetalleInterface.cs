using BD.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BD.Interfaces
{
    public interface DetalleInterface
    {
        Task<List<Detalle>> ListaDetalles();
        Task<string> InsertDeatlle(Detalle detalle);
    }
}
