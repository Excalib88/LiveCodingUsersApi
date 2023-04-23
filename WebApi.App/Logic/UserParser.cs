using System.Text.Json;
using WebApi.App.Models;

namespace WebApi.App.Logic;

public class UserParser : IUserParser
{
    private readonly HttpClient _httpClient;

    public UserParser(IHttpClientFactory httpClientFactory)
    {
        _httpClient = httpClientFactory.CreateClient("UserService");
    }

    public async Task<List<UserModel>> Parse()
    {
        var response = await _httpClient.GetAsync("/users");

        if (response.IsSuccessStatusCode)
        {
            var responseContent = await response.Content.ReadAsStringAsync();
            var users = JsonSerializer.Deserialize<List<UserModel>>(responseContent, new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase
            }) ?? new List<UserModel>();

            return users;
        }

        throw new Exception("Request failed");
    }
}