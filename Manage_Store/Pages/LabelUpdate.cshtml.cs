using Manage_Store.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Manage_Store.Pages;

public class LabelUpdate : PageModel
{
    public string Notification { get; set; } = null!;

    [BindProperty(SupportsGet = true)]
    public string? Label { get; set; }
    [BindProperty]
    public string? NewLabel { get; set; }
    public void OnGet()
    {
        Notification=String.Empty;
        NewLabel = String.Empty;
    }

    public void OnPost()
    {
        Notification = SolvingItemLabel.UpdateLabel(Label, NewLabel);
    }
}