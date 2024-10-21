using Api.Entities;

namespace Api.Repositories.Interfaces;

public interface IUserRepository
{
    public Task Create(User user);
    public Task<User?> Get(int id);
    public Task<User?> Get(string email, string password);
    public Task<List<User>> All();
    public Task Update(User user);
    public Task Remove(User user);
    public Task<bool> EmailExists(string email);
}
