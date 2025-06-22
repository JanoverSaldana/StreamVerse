namespace StreamVerse.CRM.Interfaces.REST.Resources;

public record UserResource(
    Guid UserId,
    string FirstName,
    string LastName,
    int Status,
    int SubscriptionChannelType,
    string JoinedAt,
    string SubscriptionApprovedAt,
    string CancellationReportedAt
);