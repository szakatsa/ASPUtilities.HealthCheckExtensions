using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using Microsoft.AspNetCore.Http;
using SzakatsA.ASPUtilities.HealthCheckExtensions.Models;

namespace SzakatsA.ASPUtilities.HealthCheckExtensions;

public static class EndpointBuilderExtensions
{
    /// <summary>
    /// Maps a health check endpoint that returns the health check response in JSON format.
    /// </summary>
    /// <param name="app">The WebApplication instance to add the endpoint to.</param>
    /// <param name="pattern">The URL pattern for the health check endpoint. Defaults to "/healthz".</param>
    /// <returns>An <see cref="IEndpointConventionBuilder"/> for further configuration of the endpoint.</returns>
    public static IEndpointConventionBuilder MapHealthChecksJSON(this WebApplication app, string pattern = "/healthz")
    {
        return app.MapHealthChecks(pattern, new HealthCheckOptions() { AllowCachingResponses = false, ResponseWriter = (ctx, rep) => ctx.Response.WriteAsJsonAsync(new HealthCheckDTO(rep)) });
    }
}