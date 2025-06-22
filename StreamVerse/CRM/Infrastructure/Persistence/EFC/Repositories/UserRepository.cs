using Microsoft.EntityFrameworkCore;
using StreamVerse.CRM.Domain.Model.Aggregate;
using StreamVerse.CRM.Domain.Repositories;
using StreamVerse.Shared.Infrastructure.Persistence.EFC.Configuration;
using StreamVerse.Shared.Infrastructure.Persistence.EFC.Repositories;

namespace StreamVerse.CRM.Infrastructure.Persistence.EFC.Repositories;

public class UserRepository(AppDbContext context): BaseRepository<User>(context), IUserRepository
{
    public async Task<User> GetUserByIdAsync(int id)
    {
        return await context.Set<User>()
            .FirstOrDefaultAsync(u => u.Id == id);
    }

    public async Task<bool> FindUserByFirstNameAndLastName(string firstName, string lastName)
    {
        return await context.Set<User>()
            .AnyAsync(u => u.FirstName == firstName && u.LastName == lastName);
    }
}