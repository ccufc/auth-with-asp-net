using Api.Models;
using Api.Repositories.Interfaces;
using Api.Services.Auth.Interfaces;

namespace Api.Services.Auth;

public class LoginService(IUserRepository repository) : ILoginService
{
    private readonly IUserRepository _repository = repository;

    public async Task<(string, UserLoggedResponse)> Login(string email, string password)
    {
        if (string.IsNullOrWhiteSpace(email) || !email.Contains('@'))
            throw new ArgumentException("Please enter a valid email");

        if (string.IsNullOrWhiteSpace(password) || password.Length < 8)
            throw new ArgumentException("Password must be at least 8 characters");

        var user = await _repository.Get(email, password)
            ?? throw new ArgumentException("User not found");

        var model = new UserLoggedResponse(user.Id, user.Name, user.Email);
        var token = TokenService.Generate(user.Id, user.Email);

        return (token, model);
    }
}
