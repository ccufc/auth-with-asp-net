using Api.Entities;
using Api.Repositories.Interfaces;
using Api.Services.Users.Interfaces;

namespace Api.Services.Users;

public class GetUserService(IUserRepository repository) : IGetUserService
{
    private readonly IUserRepository _repository = repository;

    public async Task<User?> Get(int id)
        => await _repository.Get(id)
        ?? throw new ArgumentException("User not found");
}
