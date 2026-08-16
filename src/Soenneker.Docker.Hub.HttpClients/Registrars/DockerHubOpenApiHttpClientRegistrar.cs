using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Soenneker.Docker.Hub.HttpClients.Abstract;
using Soenneker.Utils.HttpClientCache.Registrar;

namespace Soenneker.Docker.Hub.HttpClients.Registrars;

/// <summary>
/// Registers the OpenAPI HttpClient wrapper for dependency injection.
/// </summary>
public static class DockerHubOpenApiHttpClientRegistrar
{
    /// <summary>
    /// Adds <see cref="DockerHubOpenApiHttpClient"/> as a singleton service. <para/>
    /// </summary>
    public static IServiceCollection AddDockerHubOpenApiHttpClientAsSingleton(this IServiceCollection services)
    {
        services.AddHttpClientCacheAsSingleton()
                .TryAddSingleton<IDockerHubOpenApiHttpClient, DockerHubOpenApiHttpClient>();

        return services;
    }

    /// <summary>
    /// Adds <see cref="DockerHubOpenApiHttpClient"/> as a scoped service. <para/>
    /// </summary>
    public static IServiceCollection AddDockerHubOpenApiHttpClientAsScoped(this IServiceCollection services)
    {
        services.AddHttpClientCacheAsSingleton()
                .TryAddScoped<IDockerHubOpenApiHttpClient, DockerHubOpenApiHttpClient>();

        return services;
    }
}
