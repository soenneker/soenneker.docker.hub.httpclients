[![](https://img.shields.io/nuget/v/soenneker.docker.hub.httpclients.svg?style=for-the-badge)](https://www.nuget.org/packages/soenneker.docker.hub.httpclients/)
[![](https://img.shields.io/github/actions/workflow/status/soenneker/soenneker.docker.hub.httpclients/publish-package.yml?style=for-the-badge)](https://github.com/soenneker/soenneker.docker.hub.httpclients/actions/workflows/publish-package.yml)
[![](https://img.shields.io/nuget/dt/soenneker.docker.hub.httpclients.svg?style=for-the-badge)](https://www.nuget.org/packages/soenneker.docker.hub.httpclients/)
[![](https://img.shields.io/github/actions/workflow/status/soenneker/soenneker.docker.hub.httpclients/codeql.yml?label=CodeQL&style=for-the-badge)](https://github.com/soenneker/soenneker.docker.hub.httpclients/actions/workflows/codeql.yml)

# Soenneker.Docker.Hub.HttpClients

Provides a cached `HttpClient` configured for the Docker Hub API and bearer authentication.

## Installation

```bash
dotnet add package Soenneker.Docker.Hub.HttpClients
```

## Configuration

```json
{
  "DockerHub": {
    "AccessToken": "your-access-token"
  }
}
```

Keep the token in a secret provider rather than source control.

The transport can also be customized with these optional settings:

```json
{
  "Hub": {
    "ClientBaseUrl": "https://hub.docker.com",
    "AuthHeaderName": "Authorization",
    "AuthHeaderValueTemplate": "Bearer {token}"
  }
}
```

The template replaces every literal `{token}` with `DockerHub:AccessToken`. Treat the base URL, header name, and template as trusted configuration because they determine where and how the credential is sent.

## Registration and use

```csharp
using Soenneker.Docker.Hub.HttpClients.Abstract;
using Soenneker.Docker.Hub.HttpClients.Registrars;

services.AddDockerHubOpenApiHttpClientAsSingleton();

public sealed class DockerHubTransport(IDockerHubOpenApiHttpClient clientProvider)
{
    public async Task<HttpResponseMessage> Send(
        HttpRequestMessage request,
        CancellationToken cancellationToken)
    {
        HttpClient client = await clientProvider.Get(cancellationToken);
        return await client.SendAsync(request, cancellationToken);
    }
}
```

`Get` returns the cached client. Do not dispose the returned `HttpClient`; the registered provider owns the cache entry.

Singleton registration is the normal choice for direct transport use. `AddDockerHubOpenApiHttpClientAsScoped()` scopes the provider but still uses the shared singleton HTTP-client cache; disposing that provider removes its named cache entry.

This package only configures transport. It does not deserialize responses, paginate results, or convert non-success status codes into domain exceptions. Use the companion OpenAPI client utility when you want the generated Docker Hub API surface.
