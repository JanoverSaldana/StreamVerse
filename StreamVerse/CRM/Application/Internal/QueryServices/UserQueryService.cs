using StreamVerse.CRM.Domain.Model.Aggregate;
using StreamVerse.CRM.Domain.Model.Queries;
using StreamVerse.CRM.Domain.Repositories;
using StreamVerse.CRM.Domain.Services;
using StreamVerse.Shared.Domain.Repositories;

namespace StreamVerse.CRM.Application.Internal.QueryServices;

public class UserQueryService(IUserRepository userRepository) : IUserQueryService
{
    public async Task<User?> Handle(GetUserByIdQuery query)
    {
        return await userRepository.GetUserByIdAsync(query.Id);
    }

    public async Task<bool> Handle(FindUserByFirstNameAndLastNameQuery query)
    {
        return await userRepository.FindUserByFirstNameAndLastName(query.firstName, query.lastName);
    }
}