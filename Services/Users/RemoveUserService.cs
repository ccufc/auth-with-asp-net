using Api.Repositories.Interfaces;
using Api.Services.Users.Interfaces;

namespace Api.Services.Users;

public class RemoveUserService(IUserRepository repository) : IRemoveUserService
{
    private readonly IUserRepository _repository = repository;

    public async Task Remove(int id)
    {
        var user = await _repository.Get(id)
            ?? throw new ArgumentException("User not found");

        await _repository.Remove(user);
    }
}
