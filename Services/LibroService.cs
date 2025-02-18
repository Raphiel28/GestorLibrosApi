using GerstorLibrosAPI.Entidades;
using System.Text;
using System.Text.Json;

namespace GerstorLibrosAPI.Services
{
    public class LibroService
    {
        private readonly HttpClient _httpClient;
        private readonly string apiUrl = "https://fakerestapi.azurewebsites.net/api/v1/Books";

        public LibroService(HttpClient httpClient) {
        
        _httpClient = httpClient;
        
        }



        public async Task<List<Lilbros>> ObtenerTodosLibros()
        {
            return await _httpClient.GetFromJsonAsync<List<Lilbros>>(apiUrl) ?? new List<Lilbros>();
        }

        public async Task<Lilbros?> ObtenerLibroId(int id)
        {
            return await _httpClient.GetFromJsonAsync<Lilbros>($"{apiUrl}/{id}");
        }

        public async Task<Lilbros?> AgregarLibro(Lilbros libro)
        {
            var libros = await ObtenerTodosLibros();

           
            int nextId = libros.Any() ? libros.Max(b => b.Id) + 1 : 1;

           
            libro.Id = nextId;

          
            libros.Add(libro);

            
            return libro;
        }

        public async Task<Lilbros?> ActualizarLibro(int id, Lilbros libro)
        {
            var jsonContent = new StringContent(JsonSerializer.Serialize(libro), Encoding.UTF8, "application/json");
            var response = await _httpClient.PutAsync($"{apiUrl}/{id}", jsonContent);

            return response.IsSuccessStatusCode
                ? await response.Content.ReadFromJsonAsync<Lilbros>()
                : null;
        }

        public async Task<bool> BorrarLibro(int id)
        {
            var response = await _httpClient.DeleteAsync($"{apiUrl}/{id}");
            return response.IsSuccessStatusCode;
        }


    }
}
