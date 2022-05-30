using Manage_Store.Entity;
using Manage_Store.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace Manage_Store.Pages;

public class IndexModel : PageModel
{
    // private readonly ILogger<IndexModel> _logger;
    //
    // // public IndexModel(ILogger<IndexModel> logger)
    // {
    //     _logger = logger;
    // }

    public List<StrucItem> ItemsInStore = SolvingItem.RequestLoadStore();
    public List<StrucItem> ItemsShow { get; set; }
    [BindProperty]
    public string ChoiceFunc { get; set; }
    [BindProperty]
    public string Keyword { get; set; }

    public void OnGet()
    {
        ChoiceFunc = String.Empty;
        Keyword = String.Empty;
        ItemsShow = ItemsInStore;
    }

    public void OnPost()
    {
        if (string.IsNullOrEmpty(Keyword))
        {
            ItemsShow = ItemsInStore;
        }
        else
        {
            ItemsShow = SolvingItem.FinalistItems(Keyword, ChoiceFunc);
        }
    }
}