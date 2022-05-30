using Manage_Store.DAL;
using Manage_Store.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Manage_Store.Pages;

public class LabelCreate : PageModel
{
    public string Nortification { get; set; }
    public List<string> Labelist { get; set; }
    [BindProperty] 
    public string NewLabel { get; set; } = null!;

    public void OnGet()
    {
        Nortification = String.Empty;
        Labelist = DataWorkFlow.DownloadListLabel();
    }

    public void OnPost()
    {
        string addNewLabel = NewLabel;
        Nortification = SolvingItemLabel.AddNewLabel(addNewLabel);
        Labelist = DataWorkFlow.DownloadListLabel();
    }
    
}