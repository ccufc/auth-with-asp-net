using Api.Entities;
using Api.Repositories.Interfaces;
using Api.Services.Users.Interfaces;

namespace Api.Services.Users;

public class GetUsersService(IUserRepository repository) : IGetUsersService
{
    private readonly IUserRepository _repository = repository;

    public async Task<List<User>> All()
        => await _repository.All();
}
