using Manage_Store.Entity;
using Manage_Store.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Manage_Store.Pages;

public class ImportNew : PageModel
{
    public string Notification = string.Empty;
    public bool RequestStatus = false;
    [BindProperty (SupportsGet = true)]
    public string ItemId { get; set; }
    [BindProperty]
    public int Importvalue { get; set; }
    public string ImportDate { get; set; }
    public ImportRecord NewImport = new ImportRecord();

    public List<StrucItem> CurrentListItems = SolvingItem.RequestLoadStore();
    public StrucItem CurrentItem { get; set; }

    public string ImportId = ManipulateFunction.CreateImportId();
    [BindProperty]
    public int valueImport { get; set; }
    public void OnGet()
    {
        CurrentItem = SolvingItem.FindItem(ItemId,CurrentListItems);
        Importvalue = 0;
        ImportDate = string.Empty;
    }

    public void OnPost()
    {
        NewImport.ItemId = ItemId;
        NewImport.Date = ImportDate;
        NewImport.Qty = Importvalue;
        RequestStatus = ImportStore.RequestAddNewImport(NewImport);
        if (RequestStatus)
        {
            Notification = "Cap Nhat Thanh Cong";
            Response.Redirect("/index");
        }
        else
        {
            Notification = "Cap Nhat That Bai";
        }
    }
}