using Api.Models;

namespace Api.Services.Auth.Interfaces;

public interface ILoginService
{
    public Task<(string, UserLoggedResponse)> Login(string email, string password);
}
