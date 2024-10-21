using Api.Entities;

namespace Api.Services.Users.Interfaces;

public interface IGetUsersService
{
    public Task<List<User>> All();
}
