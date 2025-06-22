using StreamVerse.CRM.Domain.Model.Aggregate;
using StreamVerse.CRM.Interfaces.REST.Resources;

namespace StreamVerse.CRM.Interfaces.REST.Transform;

public static class UserResourceFromEntityAssembler
{
    public static UserResource ToResourceFromEntity(User entity)
    {
        return new UserResource(
            entity.UserId,
            entity.FirstName,
            entity.LastName,
            (int)entity.Status,
            (int)entity.SubscriptionChannelType,
            entity.JoinedAt?.ToString("o"), // ISO 8601 format
            entity.SubscriptionApprovedAt?.ToString("o"),
            entity.CancellationReportedAt?.ToString("o")
        );
    }
    
}