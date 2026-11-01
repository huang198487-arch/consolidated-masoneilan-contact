namespace ConsolidatedMasoneilanContact.Infrastructure;

public static class SiteUrlBuilder
{
    public static string Absolute(HttpRequest request, string path)
    {
        var pathBase = request.PathBase.Value?.TrimEnd('/') ?? string.Empty;
        var normalizedPath = path.StartsWith('/') ? path : $"/{path}";

        return $"{request.Scheme}://{request.Host}{pathBase}{normalizedPath}";
    }
}
