using Manage_Store.Entity;
using Manage_Store.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Manage_Store.Pages;

public class Importremove : PageModel
{
    public Service.Operation sv;
    public DataFlow df;
    [BindProperty(SupportsGet = true)]
    public string importid { get; set; }
    [BindProperty]
    public bool statusRemoveRecord { get; set; }
    [BindProperty]
    public string notification { get; set; }

    public List<StrucItem> CurrentItemsList { get; set; }
    public List<ImportRecord> CurrentRecords { get; set; }
    public void OnGet()
    {
        CurrentRecords = sv.ImportStore.RequestLoadImportRecords();
        notification = string.Empty;
        CurrentItemsList = sv.SolvingItem.RequestLoadStore();
    }

    public void OnPost()
    {
        
        statusRemoveRecord = sv.ImportStore.RequestRemoveImportReport(importid);
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