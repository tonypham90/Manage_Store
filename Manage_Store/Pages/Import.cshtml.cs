using Manage_Store.Entity;
using Manage_Store.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Manage_Store.Pages;

public class Import : PageModel
{
    private Operation sv;
    private DataFlow df;
    public List<ImportRecord> HistoryImportRecords { get; set; }
    [BindProperty] public List<ImportRecord> ImportShow { get; set; }
    [BindProperty] public string choicefunc { get; set; }

    [BindProperty]
    public string keyword { get; set; }
    public void OnGet()
    {
        HistoryImportRecords = sv.ImportStore.RequestLoadImportRecords();
        ImportShow = HistoryImportRecords;
        keyword = string.Empty;
    }

    public void OnPost()
    {
        if (string.IsNullOrEmpty(keyword))
        {
            HistoryImportRecords = sv.ImportStore.RequestLoadImportRecords();
            ImportShow = HistoryImportRecords;
        }

        ImportShow = sv.ImportStore.FindListRecords(keyword, choicefunc);
    }
}