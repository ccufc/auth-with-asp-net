using Api.Entities;
using Microsoft.EntityFrameworkCore;

namespace Api.Data;

public class Context(DbContextOptions<Context> options) : DbContext(options)
{
    public DbSet<User> Users { get; set; }
}
