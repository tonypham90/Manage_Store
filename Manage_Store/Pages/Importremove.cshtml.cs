using Manage_Store.Entity;
using Manage_Store.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Manage_Store.Pages;

public class Importremove : PageModel
{
    [BindProperty(SupportsGet = true)]
    public string importid { get; set; }
    [BindProperty]
    public bool statusRemoveRecord { get; set; }
    [BindProperty]
    public string notification { get; set; }

    public List<StrucItem> CurrentItemsList = SolvingItem.RequestLoadStore();
    public List<ImportRecord> CurrentRecords = ImportStore.RequestLoadImportRecords();
    public void OnGet()
    {
        notification = string.Empty;
    }

    public void OnPost()
    {
        statusRemoveRecord = ImportStore.RequestRemoveImportReport(importid);
        if (statusRemoveRecord)
        {
            Response.Redirect("/import");
        }
        else
        {
            notification = "Kiem tra lai thong so, co the mat hang khong con ton tai";
        }
    }
}