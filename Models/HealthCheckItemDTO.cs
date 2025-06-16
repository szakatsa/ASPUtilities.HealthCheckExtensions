using Microsoft.Extensions.Diagnostics.HealthChecks;

namespace SzakatsA.ASPUtilities.HealthCheckExtensions.Models;

/// <summary>
/// Data Transfer Object (DTO) that represents the result of an individual health check entry,
/// including status, duration, error message, and associated metadata.
/// </summary>
public class HealthCheckItemDTO
{
    /// <summary>
    /// The unique identifier or name of the health check.
    /// </summary>
    public string Key { get; set; }

    /// <summary>
    /// A textual description of the health check, if provided.
    /// </summary>
    public string? Description { get; set; }

    /// <summary>
    /// The time taken to execute the health check.
    /// </summary>
    public TimeSpan Duration { get; set; }

    /// <summary>
    /// The health status of the check (e.g., Healthy, Degraded, Unhealthy).
    /// </summary>
    public string Status { get; set; }

    /// <summary>
    /// The error message if the health check failed, or an empty string if none.
    /// </summary>
    public string ExceptionMessage { get; set; }

    /// <summary>
    /// Additional data returned by the health check.
    /// </summary>
    public IReadOnlyDictionary<string, object> Data { get; set; }

    /// <summary>
    /// Tags associated with the health check entry.
    /// </summary>
    public IEnumerable<string> Tags { get; set; }

    /// <summary>
    /// Initializes a new instance of the <see cref="HealthCheckItemDTO"/> class using the specified key and <see cref="HealthReportEntry"/>.
    /// </summary>
    /// <param name="key">The name or key of the health check.</param>
    /// <param name="entry">The health report entry containing detailed result information.</param>
    public HealthCheckItemDTO(string key, HealthReportEntry entry)
    {
        Key = key;
        Data = entry.Data;
        Description = entry.Description;
        Duration = entry.Duration;
        ExceptionMessage = entry.Exception?.Message ?? "";
        Status = Enum.GetName(typeof(HealthStatus), entry.Status) ?? "";
        Tags = entry.Tags;
    }
}