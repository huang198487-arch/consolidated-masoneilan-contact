using System.Net;
using Microsoft.AspNetCore.Mvc.Testing;

namespace ConsolidatedMasoneilanContact.Tests;

public sealed class PublicSiteTests(WebApplicationFactory<Program> factory)
    : IClassFixture<WebApplicationFactory<Program>>
{
    [Fact]
    public async Task Chinese_home_page_exposes_primary_contact()
    {
        using var client = factory.CreateClient();

        using var response = await client.GetAsync("/");
        var html = await response.Content.ReadAsStringAsync();

        Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        Assert.Contains("黄海宏", html, StringComparison.Ordinal);
        Assert.Contains("18001547123", html, StringComparison.Ordinal);
        Assert.Contains("king.huang@bakerhughes.com", html, StringComparison.Ordinal);
    }
}
