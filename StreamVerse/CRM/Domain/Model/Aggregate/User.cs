using StreamVerse.CRM.Domain.Model.Commands;
using StreamVerse.CRM.Domain.Model.ValueObjects;

namespace StreamVerse.CRM.Domain.Model.Aggregate;

public partial class User
{
    
    public int Id { get; set; }
    public Guid UserId { get; set; }  // Guid único, autogenerado
    public string FirstName { get; set; } = null!; // Entre 4 y 40 caracteres
    public string LastName { get; set; } = null!; // Entre 4 y 40 caracteres
    public EUserStatus Status { get; set; } // Restringido por EUserStatus
    public ESubscriptionChannelType? SubscriptionChannelType { get; set; } // No obligatorio
    public DateTime? JoinedAt { get; set; } // No obligatorio
    public DateTime? SubscriptionApprovedAt { get; set; } // No obligatorio
    public DateTime? CancellationReportedAt { get; set; } // No obligatorio

    public User()
    {
        UserId =  Guid.NewGuid(); // Generar un nuevo Guid único para userId
        FirstName = string.Empty; // Inicializar como cadena vacía
        LastName = string.Empty; // Inicializar como cadena vacía
        Status = EUserStatus.Active; // Establecer un estado por defecto
        JoinedAt = DateTime.UtcNow; // Establecer la fecha de unión por defecto
        SubscriptionApprovedAt = null; // Inicializar como nulo
        CancellationReportedAt = null; // Inicializar como nulo
    }
    
    public User(string firstName, string lastName, EUserStatus status = EUserStatus.Active, 
                ESubscriptionChannelType? subscriptionChannelType = null, DateTime? joinedAt = null, 
                DateTime? subscriptionApprovedAt = null, DateTime? cancellationReportedAt = null) : this()
    {
        UserId = Guid.NewGuid(); // Generar un nuevo Guid único para userId
        FirstName = firstName;
        LastName = lastName;
        Status = status;
        SubscriptionChannelType = subscriptionChannelType;
        JoinedAt = joinedAt ?? DateTime.UtcNow;
        SubscriptionApprovedAt = subscriptionApprovedAt;
        CancellationReportedAt = cancellationReportedAt;
    }
    
    public User(CreateUserCommand command) : this()    
    {
        UserId = Guid.NewGuid(); // Generar un nuevo Guid único para userId
        FirstName = command.FirstName;
        LastName = command.LastName;
        Status = (EUserStatus)command.Status; // Convertir el estado del comando al tipo EUserStatus
        SubscriptionChannelType = (ESubscriptionChannelType?)command.SubscriptionChannelType; // Convertir el tipo de canal de suscripción
        JoinedAt = command.JoinedAt != null ? DateTime.Parse(command.JoinedAt) : DateTime.UtcNow; // Parsear la fecha de unión o establecer la fecha actual
        SubscriptionApprovedAt = command.SubscriptionApprovedAt != null ? DateTime.Parse(command.SubscriptionApprovedAt) : null; // Parsear la fecha de aprobación de suscripción
        CancellationReportedAt = command.CancellationReportedAt != null ? DateTime.Parse(command.CancellationReportedAt) : null; // Parsear la fecha de reporte de cancelación
    }
    
    
    public void UpdateUser(UpdateUserCommand command)
    {
        FirstName = command.FirstName;
        LastName = command.LastName;
    }
    
    
}