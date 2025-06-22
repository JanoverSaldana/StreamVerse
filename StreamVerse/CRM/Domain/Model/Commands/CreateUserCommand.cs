namespace StreamVerse.CRM.Domain.Model.Commands;

public record CreateUserCommand(
    string FirstName,
    string LastName,
    int Status, // EUserStatus
    int SubscriptionChannelType, // ESubscriptionChannelType
    string JoinedAt,
    string SubscriptionApprovedAt,
    string CancellationReportedAt
);