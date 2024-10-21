namespace Api.Services.Users.Interfaces;

public interface IUpdateUserService
{
    public Task Update(int id, string? name, string? email, string? password);
}
