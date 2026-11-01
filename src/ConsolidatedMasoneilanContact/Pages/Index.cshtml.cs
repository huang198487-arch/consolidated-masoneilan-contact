using ConsolidatedMasoneilanContact.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ConsolidatedMasoneilanContact.Pages;

public class IndexModel : PageModel
{
    public SiteContent PageContent { get; } = SiteContentCatalog.Chinese;

    public void OnGet()
    {
    }
}
