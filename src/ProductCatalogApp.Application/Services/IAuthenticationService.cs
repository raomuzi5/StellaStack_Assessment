using ProductCatalogApp.Application.Interfaces;
using ProductCatalogApp.Application.Services;

public interface IAuthenticationService
{
    Task<string> AuthenticateAsync(string username, string password);
}

public class AuthenticationService : IAuthenticationService
{
    private readonly IJwtTokenService _jwtTokenService;
    private readonly IUserRepository _userRepository;

    public AuthenticationService(IJwtTokenService jwtTokenService, IUserRepository userRepository)
    {
        _jwtTokenService = jwtTokenService;
        _userRepository = userRepository;
    }

    public async Task<string> AuthenticateAsync(string username, string password)
    {
        var user = await _userRepository.GetByUsernameAsync(username);
        if (user == null || !VerifyPassword(password, user.Password))
        {
            throw new UnauthorizedAccessException("Invalid credentials.");
        }

        return _jwtTokenService.GenerateToken(user);
    }

    private bool VerifyPassword(string enteredPassword, string storedPassword)
    {
        return enteredPassword == storedPassword; 
    }
}
