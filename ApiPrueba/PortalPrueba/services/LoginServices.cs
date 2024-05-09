using PortalPrueba.Interfaces;

namespace PortalPrueba.services
{
    public class LoginServices : LoginInterface
    {
        public async Task<string> Logoneo(string usuario, string clave)
        {
            dynamic res;
            var content = string.Empty;
            HttpClient client = new HttpClient();
            try
            {
                string baseUrl = "http://localhost:5000/Login/ValidacionUsuario?";

                string parametro1 = $"usuario={usuario}";
                string parametro2 = $"pass={clave}";

                string urlFinal = $"{baseUrl}{parametro1}&{parametro2}";

                // Hacer una solicitud GET a una URL
                HttpResponseMessage response = await client.GetAsync(urlFinal);

                // Verificar si la solicitud fue exitosa
                if (response.IsSuccessStatusCode)
                {
                    // Leer el contenido de la respuesta como una cadena
                    content = await response.Content.ReadAsStringAsync();
                    res = content;
                }
                else
                {
                    Console.WriteLine("La solicitud no fue exitosa. Código de estado: " + response.StatusCode);
                    res = content;
                }
            }
            catch (Exception)
            {

                throw;
            }

            return res;
        }
    }
}
