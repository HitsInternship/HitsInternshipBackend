using System.Text.Json.Serialization;

namespace DeanModule.Domain.Enums;

public enum ApplicationStatus
{
    Created,
    UnderConsideration,
    Rejected,
    Accepted
}