using Manage_Store.Entity;
using Manage_Store.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Manage_Store.Pages;

public class ItemRemove : PageModel
{
    public List<StrucItem> CurrentItemsList = SolvingItem.RequestLoadStore();
    public string Notification = String.Empty;
    public bool statusRemoveItem;
    [BindProperty(SupportsGet = true)] 
    public string id { get; set; }
    public void OnGet()
    {
        Notification = String.Empty;
    }

    public void OnPost()
    {
        statusRemoveItem = SolvingItem.RequestRemoveItem(id);
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