using Manage_Store.Entity;
using Manage_Store.Service;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Manage_Store.Pages;

public class Summary : PageModel
{
    public List<string> labelList = SolvingItemLabel.CurrentLabel();
    public List<StrucItem> listItemOverDue = CaculateSummary.listOverdue();

    public void OnGet()
    {
    }
}