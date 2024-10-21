using Api.Entities;
using Api.Repositories.Interfaces;
using Api.Services.Users.Interfaces;

namespace Api.Services.Users;

public class CreateUserService(IUserRepository repository) : ICreateUserService
{
    private readonly IUserRepository _repository = repository;

    public async Task Create(string name, string email, string password)
    {
        if (string.IsNullOrWhiteSpace(name) || name.Length < 4)
            throw new ArgumentException("name must be at least 4 characters");

        if (string.IsNullOrWhiteSpace(password) || password.Length < 8)
            throw new ArgumentException("password must be at least 8 characters");

        if (await _repository.EmailExists(email))
            throw new ArgumentException("Email already exists");

        var user = new User
        {
            Name = name,
            Email = email,
            Password = password
        };

        await _repository.Create(user);
    }
}
