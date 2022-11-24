using Manage_Store.Entity;
using Manage_Store.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Manage_Store.Pages;

public class Importupdate : PageModel
{
    public List<ImportRecord> CurrentImportRecords = ImportStore.RequestLoadImportRecords();
    [BindProperty (SupportsGet = true)]
    public string importid { get; set; }
    [BindProperty] public string itemId { get; set; }
    [BindProperty] public string Notification { get; set; }
    [BindProperty]
    public bool statusupdate { get; set; }
    [BindProperty]
    public int importvalue { get; set; }
    [BindProperty]
    public DateTime importdate { get; set; }
    public void OnGet()
    {
        ImportRecord RecordneedUpdate = new ImportRecord();
        foreach (ImportRecord record in CurrentImportRecords)
        {
            if (record.ImportId.Contains(importid))
            {
                RecordneedUpdate = record;
                break;
            }
        }

        importvalue = RecordneedUpdate.ImportQty;
        importdate = DateManipulate.ConvertStringtoDateTime(RecordneedUpdate.Date) ;
        itemId = RecordneedUpdate.ItemId;
        Notification = string.Empty;
    }

    public void OnPost()
    {
        ImportRecord newRecord = new ImportRecord();
        newRecord.Date = DateManipulate.ConvertDatetoString(importdate);
        newRecord.ItemId = itemId;
        newRecord.ImportQty = importvalue;
        newRecord.ImportId = importid;
        statusupdate = ImportStore.RequestUpdateImportRecord(newRecord);
        if (statusupdate)
        {
            Response.Redirect("/import");
        }

        Notification = "Cap nhat that bai, kiem tra lai thong tin";
    }
}