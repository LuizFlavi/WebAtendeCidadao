using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using System.Collections.Generic;
using WebAtendeCidadao.Models;
using static WebAtendeCidadao.Models.Login;

namespace WebAtendeCidadao.Services
{
    public class WebAtendeCidadaoServices
    {
        private readonly HttpClient _httpClient;

        public WebAtendeCidadaoServices(HttpClient httpClient)
        {
            _httpClient = httpClient;
            _httpClient.BaseAddress = new Uri("https://localhost:44374/api/");
        }

        public async Task<LoginResponse> Login(Login model)
        {
            var response = await _httpClient.PostAsJsonAsync("login", model);

            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadFromJsonAsync<LoginResponse>();
            }

            var errorContent = await response.Content.ReadAsStringAsync();
            throw new Exception($"Erro no login: {errorContent}");
        }

        public async Task<List<SolicitacaoModel>> GetSolicitacoesAsync()
        {
            var response = await _httpClient.GetAsync("solicitacoes");
            if (response.IsSuccessStatusCode)            {
                
                var content = await response.Content.ReadAsStringAsync();
                Console.WriteLine($"Resposta da API: {content}");

                var solicitacoesResponse = await response.Content.ReadFromJsonAsync<SolicitacoesResponse>();

                if (solicitacoesResponse?.Items?.values != null)
                {
                    return solicitacoesResponse.Items.values;
                }
            }

            var errorContent = await response.Content.ReadAsStringAsync();
            Console.WriteLine($"Erro ao obter solicitações: {errorContent}");

            // Retornar uma lista vazia caso ocorra um erro
            return new List<SolicitacaoModel>();
        }


        public async Task<bool> CreateSolicitacaoAsync(SolicitacaoModel solicitacao)
        {
            var response = await _httpClient.PostAsJsonAsync("solicitacoes", solicitacao);
            return response.IsSuccessStatusCode;
        }

        public class SolicitacoesResponse
        {
            public ItemsContainer Items { get; set; }

            public class ItemsContainer
            {
                
                public List<SolicitacaoModel> values { get; set; }
            }

            public int CurrentPage { get; set; }
            public int PageSize { get; set; }
            public int TotalCount { get; set; }
        }
    }
}








