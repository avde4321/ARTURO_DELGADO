using Microsoft.AspNetCore.Mvc;

namespace PortalPrueba.Interfaces
{
    public interface LoginInterface
    {
        Task<string> Logoneo(string usuario, string clave);
    }
}
