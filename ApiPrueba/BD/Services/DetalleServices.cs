using BD.Interfaces;
using BD.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BD.Services
{
    public class DetalleServices : DetalleInterface
    {
        readonly private PruebaAlmarContext context;

        public DetalleServices(PruebaAlmarContext _context)
        {
            this.context = _context;
        }

        public async Task<List<Detalle>> ListaDetalles()
        {
			var list = new List<Detalle>();

			try
			{
                list = context.Detalles.ToList();

                return list;
			}
			catch (Exception)
			{

				throw;
			}
        }

        public async Task<string> InsertDeatlle(Detalle detalle)
        {
            try
            {
                context.Detalles.Add(detalle);
                await context.SaveChangesAsync();

                return "OK";

            }
            catch (Exception)
            {
                return "BAD";
            }
        }
    }
}
