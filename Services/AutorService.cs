using GerstorLibrosAPI.Entidades;
using System.Text.Json;
using System.Text;

namespace GerstorLibrosAPI.Services
{
    public class AutorService
    {

        private readonly HttpClient _httpClient;
        private readonly string apiUrl = "https://fakerestapi.azurewebsites.net/api/v1/Authors";

        public AutorService(HttpClient httpClient)
        {

            _httpClient = httpClient;

        }



        public async Task<List<Autor>> ObtenerTodosAutores()
        {
            return await _httpClient.GetFromJsonAsync<List<Autor>>(apiUrl) ?? new List<Autor>();
        }

        public async Task<Autor?> ObtenerAutorId(int id)
        {
            return await _httpClient.GetFromJsonAsync<Autor>($"{apiUrl}/{id}");
        }

        public async Task<Autor?> AgregarAutor(Autor autor)
        {
            var autores = await ObtenerTodosAutores();


            int nextId = autores.Any() ? autores.Max(b => b.Id) + 1 : 1;



            autor.Id = nextId;
            autor.IdBook = nextId;


            autores.Add(autor);


            return autor;
        }

        public async Task<Autor?> ActualizarAutor(int id, Autor autor)
        {
            var jsonContent = new StringContent(JsonSerializer.Serialize(autor), Encoding.UTF8, "application/json");
            var response = await _httpClient.PutAsync($"{apiUrl}/{id}", jsonContent);

            return response.IsSuccessStatusCode
                ? await response.Content.ReadFromJsonAsync<Autor>()
                : null;
        }

        public async Task<bool> BorrarAutor(int id)
        {
            var response = await _httpClient.DeleteAsync($"{apiUrl}/{id}");
            return response.IsSuccessStatusCode;
        }
    }
}
