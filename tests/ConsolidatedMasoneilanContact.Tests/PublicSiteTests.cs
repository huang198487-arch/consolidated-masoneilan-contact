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
        var html = System.Net.WebUtility.HtmlDecode(
            await response.Content.ReadAsStringAsync());

        Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        Assert.Equal("text/html", response.Content.Headers.ContentType?.MediaType);
        Assert.Contains("<html lang=\"zh-CN\">", html, StringComparison.Ordinal);
        Assert.Contains("<h1", html, StringComparison.Ordinal);
        Assert.Contains("可靠阀门方案，从一次直接沟通开始", html, StringComparison.Ordinal);
        Assert.Contains("康索尼德与梅索尼兰销售联系方式", html, StringComparison.Ordinal);
        Assert.Contains("Consolidated", html, StringComparison.Ordinal);
        Assert.Contains("Masoneilan", html, StringComparison.Ordinal);
        Assert.Contains("黄海宏", html, StringComparison.Ordinal);
        Assert.Contains("18001547123", html, StringComparison.Ordinal);
        Assert.Contains("king.huang@bakerhughes.com", html, StringComparison.Ordinal);
        Assert.Contains("tel:+8618001547123", html, StringComparison.Ordinal);
        Assert.Contains("mailto:king.huang@bakerhughes.com", html, StringComparison.Ordinal);
        Assert.Contains(
            "href=\"https://valves.bakerhughes.com/\"",
            html,
            StringComparison.Ordinal);
        Assert.Contains("rel=\"noopener noreferrer\"", html, StringComparison.Ordinal);
    }
}
