using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ConsolidatedMasoneilanContact.Pages;

[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
[IgnoreAntiforgeryToken]
public class ErrorModel : PageModel
{
    public int ResponseStatusCode { get; private set; }

    public void OnGet(int? statusCode = null)
    {
        ResponseStatusCode = statusCode is >= 400 and <= 599 ? statusCode.Value : 500;
        Response.StatusCode = ResponseStatusCode;
    }
}

