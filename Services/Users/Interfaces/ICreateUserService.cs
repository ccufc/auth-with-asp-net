namespace Api.Services.Users.Interfaces;

public interface ICreateUserService
{
    public Task Create(string name, string email, string password);
}
