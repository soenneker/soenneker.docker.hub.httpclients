[![](https://img.shields.io/nuget/v/soenneker.docker.hub.httpclients.svg?style=for-the-badge)](https://www.nuget.org/packages/soenneker.docker.hub.httpclients/)
[![](https://img.shields.io/github/actions/workflow/status/soenneker/soenneker.docker.hub.httpclients/publish-package.yml?style=for-the-badge)](https://github.com/soenneker/soenneker.docker.hub.httpclients/actions/workflows/publish-package.yml)
[![](https://img.shields.io/nuget/dt/soenneker.docker.hub.httpclients.svg?style=for-the-badge)](https://www.nuget.org/packages/soenneker.docker.hub.httpclients/)

# Soenneker.Docker.Hub.HttpClients

A .NET thread-safe singleton HttpClient for.

## Install

```bash
dotnet add package Soenneker.Docker.Hub.HttpClients
```

## Quick start

```csharp
using Soenneker.Docker.Hub.HttpClients.Registrars;
using Microsoft.Extensions.DependencyInjection;

var services = new ServiceCollection();
var result = services.AddDockerHubOpenApiHttpClientAsSingleton();
```

Adds `DockerHubOpenApiHttpClient` as a singleton service.

## What you get

- `IDockerHubOpenApiHttpClient` — A .NET thread-safe singleton HttpClient for.
- `DockerHubOpenApiHttpClientRegistrar` — Registers the OpenAPI HttpClient wrapper for dependency injection.

## API at a glance

| API | What it does | Result / important behavior |
| --- | --- | --- |
| `DockerHubOpenApiHttpClientRegistrar.AddDockerHubOpenApiHttpClientAsSingleton(services)` | Adds `DockerHubOpenApiHttpClient` as a singleton service. | The same service collection, so additional registrations can be chained. |
| `DockerHubOpenApiHttpClientRegistrar.AddDockerHubOpenApiHttpClientAsScoped(services)` | Adds `DockerHubOpenApiHttpClient` as a scoped service. | The same service collection, so additional registrations can be chained. |

## Practical notes

- Reuse the registered client instead of constructing one per operation.
- Calls that return a cached or singleton value reuse the same instance until the owning service is disposed.
- Dispose instances you own when their scope ends so held resources can be released.
