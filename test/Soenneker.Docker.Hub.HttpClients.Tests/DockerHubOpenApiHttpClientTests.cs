using Soenneker.Docker.Hub.HttpClients.Abstract;
using Soenneker.Tests.HostedUnit;

namespace Soenneker.Docker.Hub.HttpClients.Tests;

[ClassDataSource<Host>(Shared = SharedType.PerTestSession)]
public sealed class DockerHubOpenApiHttpClientTests : HostedUnitTest
{
    private readonly IDockerHubOpenApiHttpClient _httpclient;

    public DockerHubOpenApiHttpClientTests(Host host) : base(host)
    {
        _httpclient = Resolve<IDockerHubOpenApiHttpClient>(true);
    }

    [Test]
    public void Default()
    {

    }
}
