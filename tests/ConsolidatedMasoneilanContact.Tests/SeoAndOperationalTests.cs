using System.Net;
using System.Net.Http.Json;
using Microsoft.AspNetCore.Mvc.Testing;

namespace ConsolidatedMasoneilanContact.Tests;

public sealed class SeoAndOperationalTests(WebApplicationFactory<Program> factory)
    : IClassFixture<WebApplicationFactory<Program>>
{
    private readonly HttpClient _client = factory.CreateClient();

    [Fact]
    public async Task Home_page_contains_search_and_structured_contact_metadata()
    {
        using var response = await _client.GetAsync("/");
        var html = WebUtility.HtmlDecode(await response.Content.ReadAsStringAsync());

        Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        Assert.Contains("rel=\"canonical\" href=\"http://localhost/\"", html, StringComparison.Ordinal);
        Assert.Contains("property=\"og:title\"", html, StringComparison.Ordinal);
        Assert.Contains("name=\"twitter:card\"", html, StringComparison.Ordinal);
        Assert.Contains("application/ld+json", html, StringComparison.Ordinal);
        Assert.Contains("\"@type\":\"ContactPage\"", html, StringComparison.Ordinal);
        Assert.Contains("\"@type\":\"Person\"", html, StringComparison.Ordinal);
        Assert.Contains("king.huang@bakerhughes.com", html, StringComparison.Ordinal);
    }

    [Theory]
    [InlineData("/robots.txt", "text/plain")]
    [InlineData("/sitemap.xml", "application/xml")]
    public async Task Operational_endpoint_returns_expected_content_type(
        string path,
        string expectedMediaType)
    {
        using var response = await _client.GetAsync(path);

        Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        Assert.Equal(expectedMediaType, response.Content.Headers.ContentType?.MediaType);
    }

    [Fact]
    public async Task Robots_and_sitemap_reference_the_canonical_home_page()
    {
        var robots = await _client.GetStringAsync("/robots.txt");
        var sitemap = await _client.GetStringAsync("/sitemap.xml");

        Assert.Contains("User-agent: *", robots, StringComparison.Ordinal);
        Assert.Contains("Sitemap: http://localhost/sitemap.xml", robots, StringComparison.Ordinal);
        Assert.Contains("<loc>http://localhost/</loc>", sitemap, StringComparison.Ordinal);
    }

    [Fact]
    public async Task Health_endpoint_returns_minimal_ok_payload()
    {
        using var response = await _client.GetAsync("/health");
        var payload = await response.Content.ReadFromJsonAsync<HealthResponse>();

        Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        Assert.NotNull(payload);
        Assert.Equal("ok", payload.Status);
    }

    [Fact]
    public async Task Responses_include_security_headers()
    {
        using var response = await _client.GetAsync("/");

        Assert.Equal("nosniff", response.Headers.GetValues("X-Content-Type-Options").Single());
        Assert.Equal("DENY", response.Headers.GetValues("X-Frame-Options").Single());
        Assert.Equal(
            "strict-origin-when-cross-origin",
            response.Headers.GetValues("Referrer-Policy").Single());
        Assert.Contains(
            "frame-ancestors 'none'",
            response.Headers.GetValues("Content-Security-Policy").Single(),
            StringComparison.Ordinal);
    }

    [Fact]
    public async Task Unknown_route_returns_branded_404_with_home_link()
    {
        using var response = await _client.GetAsync("/not-a-real-page");
        var html = WebUtility.HtmlDecode(await response.Content.ReadAsStringAsync());

        Assert.Equal(HttpStatusCode.NotFound, response.StatusCode);
        Assert.Contains("页面未找到", html, StringComparison.Ordinal);
        Assert.Contains("href=\"/\"", html, StringComparison.Ordinal);
        Assert.Contains("href=\"/#contact\"", html, StringComparison.Ordinal);
    }

    private sealed record HealthResponse(string Status);
}
