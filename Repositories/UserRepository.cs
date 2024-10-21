using Api.Data;
using Api.Entities;
using Api.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Api.Repositories;

public class UserRepository(Context context) : IUserRepository
{
    private readonly Context _context = context;

    public async Task Create(User user)
    {
        await _context.Users.AddAsync(user);
        await _context.SaveChangesAsync();
    }

    public async Task<User?> Get(int id)
        => await _context.Users.FindAsync(id);

    public async Task<User?> Get(string email, string passsword)
        => await _context.Users.FirstOrDefaultAsync(x => x.Email == email && x.Password == passsword);

    public Task<List<User>> All()
        => _context.Users.ToListAsync();

    public async Task Update(User user)
    {
        _context.Users.Update(user);
        await _context.SaveChangesAsync();
    }

    public async Task Remove(User user)
    {
        _context.Users.Remove(user);
        await _context.SaveChangesAsync();
    }

    public Task<bool> EmailExists(string email)
        => _context.Users.AnyAsync(x => x.Email.Equals(email));
}
