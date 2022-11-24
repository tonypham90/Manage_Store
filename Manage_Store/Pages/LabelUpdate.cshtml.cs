using Manage_Store.Entity;
using Manage_Store.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Manage_Store.Pages;

public class LabelUpdate : PageModel
{
    public string Notification { get; set; } = null!;
    // [BindProperty]
    // public List<StrucItem>? RemoveList { get; set; }
    [BindProperty]
    public int ItemNo { get; set; }

    [BindProperty(SupportsGet = true)]
    public string? Label { get; set; }
    [BindProperty]
    public string? NewLabel { get; set; }
    public void OnGet()
    {
        // string choicefuncfind = "4";
        // RemoveList = SolvingItem.FindlistItems(Label, choicefuncfind);
        Notification=String.Empty;
        NewLabel = String.Empty;
        // ItemNo = RemoveList.Count;
    }
    public void OnPost()
    {
        Notification = SolvingItemLabel.UpdateLabel(Label, NewLabel);
    }
}