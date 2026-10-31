using System.Net;
using Microsoft.AspNetCore.Mvc.Testing;

namespace ConsolidatedMasoneilanContact.Tests;

public sealed class StaticAssetTests(WebApplicationFactory<Program> factory)
    : IClassFixture<WebApplicationFactory<Program>>
{
    private readonly HttpClient _client = factory.CreateClient();

    [Theory]
    [InlineData("/css/site.css", "text/css")]
    [InlineData("/js/site.js", "text/javascript")]
    [InlineData("/images/valve-hero.jpg", "image/jpeg")]
    [InlineData("/images/favicon.svg", "image/svg+xml")]
    public async Task Required_public_asset_is_available(string path, string expectedMediaType)
    {
        using var response = await _client.GetAsync(path);

        Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        Assert.Equal(expectedMediaType, response.Content.Headers.ContentType?.MediaType);
    }

    [Fact]
    public async Task Stylesheet_and_script_contain_the_contact_page_behavior()
    {
        var css = await _client.GetStringAsync("/css/site.css");
        var script = await _client.GetStringAsync("/js/site.js");
        var html = WebUtility.HtmlDecode(await _client.GetStringAsync("/"));

        Assert.Contains("--teal: #02bc94", css, StringComparison.OrdinalIgnoreCase);
        Assert.Contains("@media (max-width: 760px)", css, StringComparison.Ordinal);
        Assert.Contains("prefers-reduced-motion", css, StringComparison.Ordinal);
        Assert.Contains("navigator.clipboard.writeText", script, StringComparison.Ordinal);
        Assert.Contains("data-copy-value", script, StringComparison.Ordinal);
        Assert.Contains("aria-live=\"polite\"", html, StringComparison.Ordinal);
        Assert.Contains("class=\"hero__image\"", html, StringComparison.Ordinal);
    }
}
