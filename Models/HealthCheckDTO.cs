using Microsoft.Extensions.Diagnostics.HealthChecks;

namespace SzakatsA.ASPUtilities.HealthCheckExtensions.Models;

/// <summary>
/// Data Transfer Object (DTO) that represents the overall result of a health check,
/// including status, total duration, and individual check results.
/// </summary>
public class HealthCheckDTO
{
    /// <summary>
    /// The aggregated health status (e.g., Healthy, Degraded, Unhealthy).
    /// </summary>
    public string Status { get; set; }

    /// <summary>
    /// The total duration of the health check execution.
    /// </summary>
    public TimeSpan Duration { get; set; }

    /// <summary>
    /// A collection of individual health check results.
    /// </summary>
    public IEnumerable<HealthCheckItemDTO> Info { get; set; }

    /// <summary>
    /// Initializes a new instance of the <see cref="HealthCheckDTO"/> class using the specified <see cref="HealthReport"/>.
    /// </summary>
    /// <param name="r">The health report from which to construct the DTO.</param>
    public HealthCheckDTO(HealthReport r)
    {
        Status = Enum.GetName(typeof(HealthStatus), r.Status) ?? "";
        Duration = r.TotalDuration;
        Info = r.Entries.Select(e => new HealthCheckItemDTO(e.Key, e.Value));
    }
}