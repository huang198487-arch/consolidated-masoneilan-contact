using System.Net;
using System.Text;

namespace ConsolidatedMasoneilanContact.Infrastructure;

public static class SiteEndpoints
{
    public static IEndpointRouteBuilder MapSiteOperations(this IEndpointRouteBuilder endpoints)
    {
        endpoints.MapGet("/robots.txt", (HttpRequest request) =>
        {
            var sitemapUrl = SiteUrlBuilder.Absolute(request, "/sitemap.xml");
            var content = $"User-agent: *\nAllow: /\n\nSitemap: {sitemapUrl}\n";

            return Results.Text(content, "text/plain; charset=utf-8", Encoding.UTF8);
        });

        endpoints.MapGet("/sitemap.xml", (HttpRequest request) =>
        {
            var homeUrl = WebUtility.HtmlEncode(SiteUrlBuilder.Absolute(request, "/"));
            var xml = $"""
                <?xml version="1.0" encoding="UTF-8"?>
                <urlset xmlns="http://www.sitemaps.org/schemas/sitemap/0.9">
                  <url>
                    <loc>{homeUrl}</loc>
                    <changefreq>monthly</changefreq>
                    <priority>1.0</priority>
                  </url>
                </urlset>
                """;

            return Results.Text(xml, "application/xml; charset=utf-8", Encoding.UTF8);
        });

        endpoints.MapGet("/health", () => Results.Json(new { status = "ok" }));

        return endpoints;
    }
}
