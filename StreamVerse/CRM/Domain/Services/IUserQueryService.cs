using StreamVerse.CRM.Domain.Model.Aggregate;
using StreamVerse.CRM.Domain.Model.Queries;

namespace StreamVerse.CRM.Domain.Services;

public interface IUserQueryService
{
    
    // Get a user by ID
    Task<User?> Handle(GetUserByIdQuery query);
    
    // Find a user by First Name and Last Name
    Task<bool> Handle(FindUserByFirstNameAndLastNameQuery query);
    
}