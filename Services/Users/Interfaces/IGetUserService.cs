using Api.Entities;

namespace Api.Services.Users.Interfaces;

public interface IGetUserService
{
    public Task<User?> Get(int id);
}
