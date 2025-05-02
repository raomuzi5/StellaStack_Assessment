using System.Net.Http.Json;

public interface IAuthenticationService
{
    Task<string> Login(string username, string password);
}

public class AuthenticationService : IAuthenticationService
{
    private readonly HttpClient _httpClient;

    public AuthenticationService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<string> Login(string username, string password)
    {
        var loginModel = new { Username = username, Password = password };
        var response = await _httpClient.PostAsJsonAsync("api/authentication/login", loginModel);

        if (response.IsSuccessStatusCode)
        {
            var result = await response.Content.ReadFromJsonAsync<dynamic>();
            return result?.Token;
        }

        throw new Exception("Login failed.");
    }
}
