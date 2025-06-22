namespace StreamVerse.CRM.Interfaces.REST.Resources;

public record CreateCommandResource(  
    string FirstName,
    string LastName,
    int Status, // EUserStatus
    int SubscriptionChannelType, // ESubscriptionChannelType
    string JoinedAt,
    string SubscriptionApprovedAt,
    string CancellationReportedAt);