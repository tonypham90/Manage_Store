using Manage_Store.Entity;
using Manage_Store.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Manage_Store.Pages;

public class Import : PageModel
{
    public List<ImportRecord> HistoryImportRecords = ImportStore.RequestLoadImportRecords();
    [BindProperty] public List<ImportRecord> ImportShow { get; set; }
    [BindProperty] public string choicefunc { get; set; }

    [BindProperty]
    public string keyword { get; set; }
    public void OnGet()
    {
        ImportShow = HistoryImportRecords;
        keyword = string.Empty;
    }

    public void OnPost()
    {
        if (string.IsNullOrEmpty(keyword))
        {
            ImportShow = HistoryImportRecords;
        }

        ImportShow = ImportStore.FindListRecords(keyword, choicefunc);
    }
}