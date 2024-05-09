using AutoMapper;
using BD.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using PortalPrueba.Dtos;
using PortalPrueba.Interfaces;
using PortalPrueba.Models;
using System.Linq.Expressions;

namespace PortalPrueba.services
{
    public class DetalleServices : DetalleInterface
    {

        private readonly IMapper _mapper;

        public DetalleServices(IMapper mapper) 
        {
            this._mapper = mapper;
        }

        public async Task<List<Detalle>> listDetalles()
        {
            dynamic res;
            var deatllemodelo = new List<Detalle>();
            var content = string.Empty;
            HttpClient client = new HttpClient();
            try
            {
                string baseUrl = "http://localhost:5000/Detalle/ListaDetalles";

                // Hacer una solicitud GET a una URL
                HttpResponseMessage response = await client.GetAsync(baseUrl);

                // Verificar si la solicitud fue exitosa
                if (response.IsSuccessStatusCode)
                {
                    // Leer el contenido de la respuesta como una cadena
                    content = await response.Content.ReadAsStringAsync();
                    res = JsonConvert.DeserializeObject<List<Detalle>>(content);
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

        public async Task<Response> InsertDetalle(Detalle detalle)
        {
            var res = new Response();
            try
            {
                var client = new HttpClient();
                var request = new HttpRequestMessage(HttpMethod.Post, "http://localhost:5000/Detalle/InsertDeatlle");
                var content = new StringContent(JsonConvert.SerializeObject(detalle));
                request.Content = content;
                var response = await client.SendAsync(request);
                response.EnsureSuccessStatusCode();
                Console.WriteLine(await response.Content.ReadAsStringAsync());

            }
            catch (Exception)
            {

                throw;
            }
            return res;
        }
    }
}
