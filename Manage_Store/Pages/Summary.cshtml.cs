using Manage_Store.Entity;
using Manage_Store.Service;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Manage_Store.Pages;

public class Summary : PageModel
{
    public Operation sv;
    public DataFlow df;
    public List<string> labelList { get; set; }
    public List<StrucItem> listItemOverDue { get; set; }
    public List<string[]> showlist { get; set; }

    public void OnGet()
    {
         labelList = sv.SolvingItemLabel.CurrentLabel();
         listItemOverDue = sv.CaculateSummary.listOverdue();
         showlist = new List<string[]>();
         foreach (var label in labelList)
         {
             var row = new string[2];
             row[0] = label;
             row[1] = sv.CaculateSummary.countItemLabel(label).ToString();
         }
    }
}