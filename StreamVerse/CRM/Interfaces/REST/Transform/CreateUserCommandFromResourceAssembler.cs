using StreamVerse.CRM.Domain.Model.Commands;
using StreamVerse.CRM.Interfaces.REST.Resources;

namespace StreamVerse.CRM.Interfaces.REST.Transform;

public static class CreateUserCommandFromResourceAssembler
{
    public static CreateUserCommand ToCommandFromResource(CreateCommandResource resource)
    {
        return new CreateUserCommand(
            resource.FirstName,
            resource.LastName,
            resource.Status,
            resource.SubscriptionChannelType,
            resource.JoinedAt,
            resource.SubscriptionApprovedAt,
            resource.CancellationReportedAt
        );
    }
}