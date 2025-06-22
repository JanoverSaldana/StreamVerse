using StreamVerse.CRM.Domain.Model.Aggregate;
using StreamVerse.Shared.Domain.Repositories;

namespace StreamVerse.CRM.Domain.Repositories;

public interface IUserRepository: IBaseRepository<User>
{
    
    Task<User> GetUserByIdAsync(int id);
    
    Task<bool> FindUserByFirstNameAndLastName(string firstName, string lastName);
    
}