using StreamVerse.CRM.Domain.Model.Aggregate;
using StreamVerse.CRM.Domain.Model.Commands;

namespace StreamVerse.CRM.Domain.Services;

public interface IUserCommandService
{
    
    // Create a new user
    public Task<User?> Handle(CreateUserCommand command);
    
}