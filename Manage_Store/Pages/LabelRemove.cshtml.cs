using System.Linq.Expressions;
using System.Reflection.Emit;
using Manage_Store.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Manage_Store.Pages;

public class LabelRemove : PageModel
{
    public string? Notification { get; set; }
    [BindProperty(SupportsGet = true)]
    public string? Label { get; set; }
    [BindProperty]
    public string? TargetLabel { get; set; }
    
    public void OnGet()
    {
        Notification = String.Empty;
    }

    public void OnPost()
    {
        TargetLabel = Label;
        Notification = SolvingItemLabel.RemoveLabel(TargetLabel);
    }
        
}