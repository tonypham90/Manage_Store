using Manage_Store.Entity;
using Manage_Store.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Manage_Store.Pages;

public class ItemRemove : PageModel
{
    public Operation sv;
    public DataFlow df;
    public List<StrucItem>? CurrentItemsList { get; set; }
    [BindProperty]
    public string Notification { get; set; }
    public bool statusRemoveItem;
    [BindProperty(SupportsGet = true)] 
    public string id { get; set; }
    public void OnGet()
    {
        CurrentItemsList = sv.SolvingItem.RequestLoadStore();
        Notification = String.Empty;
    }

    public void OnPost()
    {
        statusRemoveItem = sv.SolvingItem.RequestRemoveItem(id);
        switch (statusRemoveItem)
        {
            case true:
                Notification = $"Xoa thanh cong";
                Response.Redirect("/index");
                break;
            case false:
                Notification = $"Xoa That bai- kiem tra lai thong tin";
                break;
        }
    }
}