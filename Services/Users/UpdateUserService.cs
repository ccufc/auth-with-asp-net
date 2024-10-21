using Api.Repositories.Interfaces;
using Api.Services.Users.Interfaces;

namespace Api.Services.Users;

public class UpdateUserService(IUserRepository repository) : IUpdateUserService
{
    private readonly IUserRepository _repository = repository;

    public async Task Update(int id, string? name, string? email, string? password)
    {
        var user = await _repository.Get(id)
            ?? throw new ArgumentException("User not found");

        if (!string.IsNullOrWhiteSpace(name))
        {
            if (name.Length < 4)
                throw new ArgumentException("name must be at least 4 characters");

            user.Name = name;
        }

        if (!string.IsNullOrWhiteSpace(email))
        {
            if (await _repository.EmailExists(email))
                throw new ArgumentException("Email already exists");

            user.Email = email;
        }

        if (!string.IsNullOrWhiteSpace(password))
        {
            if (password.Length < 8)
                throw new ArgumentException("password must be at least 8 characters");

            user.Password = password;
        }

        await _repository.Update(user);
    }
}
