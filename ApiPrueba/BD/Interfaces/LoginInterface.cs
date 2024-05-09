using BD.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BD.Interfaces
{
    public interface LoginInterface
    {
        Task<string> RegistrarUsuario( Usuario usuario);
        Task<string> ValidacionUsuario(string usuario, string pass);
    }
}
