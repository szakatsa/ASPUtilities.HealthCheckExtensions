using Microsoft.Extensions.Diagnostics.HealthChecks;
using SzakatsA.HealthCheckExtensions.Models;

namespace SzakatsA.HealthCheckExtensions;

public class HealthCheckDTO
{
    public string Status { get; set; }
    public TimeSpan Duration { get; set; }
    public IEnumerable<HealthCheckItemDTO> Info { get; set; }

    public HealthCheckDTO(HealthReport r)
    {
        Status = Enum.GetName(typeof(HealthStatus), r.Status) ?? "";
        Duration = r.TotalDuration;
        Info = r.Entries.Select(e => new HealthCheckItemDTO(e.Key, e.Value));
    }
}