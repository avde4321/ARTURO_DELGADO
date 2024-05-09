using BD.Interfaces;
using BD.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BD.Services
{
    public class LoginServices : LoginInterface
    {

        readonly private PruebaAlmarContext context;

        public LoginServices(PruebaAlmarContext _context)
        {
            this.context = _context;
        }

        public async Task<string> RegistrarUsuario(Usuario usuario)
        {
            var res = string.Empty;
            try
            {
                context.Usuarios.Add(usuario);
                await context.SaveChangesAsync();

                res = "OK";
            }
            catch (Exception)
            {
                res = "Error";
            }

            return res;
        }

        public async Task<string> ValidacionUsuario(string usuario, string pass)
        {

            try
            {
                var valdia = await context.Usuarios.Where(x => x.Users.Equals(usuario) && x.Pass.Equals(pass)).CountAsync();

                if (valdia.Equals(1))
                {
                    return "OK";
                }
                else
                {
                    return "BAD";
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
