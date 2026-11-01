using System.Security.Cryptography;
using ConsolidatedMasoneilanContact.Infrastructure;
using Microsoft.AspNetCore.HttpOverrides;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddRazorPages();
builder.Services.Configure<ForwardedHeadersOptions>(options =>
{
    options.ForwardedHeaders =
        ForwardedHeaders.XForwardedFor |
        ForwardedHeaders.XForwardedProto;
});

var app = builder.Build();

app.UseForwardedHeaders();

app.Use(async (context, next) =>
{
    var nonce = Convert.ToBase64String(RandomNumberGenerator.GetBytes(16));
    context.Items["csp-nonce"] = nonce;

    context.Response.Headers["Content-Security-Policy"] =
        $"default-src 'self'; base-uri 'self'; connect-src 'self'; font-src 'self'; " +
        $"frame-ancestors 'none'; img-src 'self' data:; object-src 'none'; " +
        $"script-src 'self' 'nonce-{nonce}'; style-src 'self'; form-action 'self'";
    context.Response.Headers["Permissions-Policy"] =
        "camera=(), geolocation=(), microphone=()";
    context.Response.Headers["Referrer-Policy"] =
        "strict-origin-when-cross-origin";
    context.Response.Headers["X-Content-Type-Options"] = "nosniff";
    context.Response.Headers["X-Frame-Options"] = "DENY";

    await next();
});

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
    app.UseHttpsRedirection();
}

app.UseStatusCodePagesWithReExecute("/Error", "?statusCode={0}");

app.UseRouting();

app.UseAuthorization();

app.MapStaticAssets();
app.MapSiteOperations();
app.MapRazorPages()
   .WithStaticAssets();

app.Run();

public partial class Program;
