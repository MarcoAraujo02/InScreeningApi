using InScreeningApi.Repository.Interface;
using System.Collections;

namespace InScreeningApi.Repository
{
    public class ExameRepository : IExameRepository
    {
        private readonly HttpClient _httpClient;

        public ExameRepository(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<IEnumerable> GetExame()
        {
            // Chamar o endpoint da API em Python
            var response = await _httpClient.GetAsync("http://127.0.0.1:5000/get_exames");
            if (response.IsSuccessStatusCode)
            {
                // Deserializa a resposta JSON para uma lista de exames
                return await response.Content.ReadFromJsonAsync<IEnumerable>();
            }
            else
            {
                // Tratar o erro conforme necessário
                throw new Exception("Erro ao obter exames: " + response.ReasonPhrase);
            }
        }
    }
}
