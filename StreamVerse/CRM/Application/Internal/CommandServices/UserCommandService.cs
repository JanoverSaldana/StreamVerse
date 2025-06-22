using StreamVerse.CRM.Domain.Model.Aggregate;
using StreamVerse.CRM.Domain.Model.Commands;
using StreamVerse.CRM.Domain.Repositories;
using StreamVerse.CRM.Domain.Services;
using StreamVerse.Shared.Domain.Repositories;

namespace StreamVerse.CRM.Application.Internal.CommandServices;

public class UserCommandService(IUserRepository userRepository, IUnitOfWork unitOfWork) : IUserCommandService
{
    public async Task<User?> Handle(CreateUserCommand command)
    {
        var user = new User(command);
        
        // Validar que no existe un usuario con el mismo firstName y lastName (booleano)
        var existingUser = await userRepository.FindUserByFirstNameAndLastName(command.FirstName, command.LastName);
        
        if (existingUser)
        {
            // Si ya existe un usuario con el mismo nombre, lanzar una excepción o manejar el error según sea necesario
            throw new InvalidOperationException($"User with name {command.FirstName} {command.LastName} already exists.");
        }
        
        // Validaciones o restricciones para crear un usuario
        if (string.IsNullOrWhiteSpace(command.FirstName) || command.FirstName.Length < 4 || command.FirstName.Length > 40)
        {
            throw new ArgumentException("First name must be between 4 and 40 characters.");
        }
        
        // Validar que el estado del usuario sea uno de los valores permitidos
        if (string.IsNullOrWhiteSpace(command.LastName) || command.LastName.Length < 4 || command.LastName.Length > 40)
        {
            throw new ArgumentException("Last name must be between 4 and 40 characters.");
        }
        
   
        await userRepository.AddAsync(user);
        await unitOfWork.CompleteAsync();
        
        return user;
    }
}