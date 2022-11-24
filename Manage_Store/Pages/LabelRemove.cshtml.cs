using System.Linq.Expressions;
using System.Reflection.Emit;
using Manage_Store.Entity;
using Manage_Store.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Manage_Store.Pages;

public class LabelRemove : PageModel
{
    public Operation sv;
    public DataFlow df;
    public string? Notification { get; set; }
    [BindProperty]
    public List<StrucItem> removeItemsList { get; set; }
    [BindProperty(SupportsGet = true)]
    public string Label { get; set; }
    [BindProperty]
    public string TargetLabel { get; set; }
    
    public void OnGet()
    {
        Notification = String.Empty;
        string choicefuncFind = "4";
        removeItemsList = sv.SolvingItem.FindlistItems(Label, choicefuncFind);
    }

    public void OnPost()
    {
        TargetLabel = Label;
        Notification = sv.SolvingItemLabel.RemoveLabel(TargetLabel);
    }
        
}