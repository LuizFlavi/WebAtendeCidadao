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
            _httpClient.BaseAddress = new Uri("https://localhost:44374/api");
        }

        public async Task<LoginResponse> login(Login model)
        {
            var response = await _httpClient.PostAsJsonAsync("/login", model);

            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadFromJsonAsync<LoginResponse>();
            }
            return null;
        }
    }
}