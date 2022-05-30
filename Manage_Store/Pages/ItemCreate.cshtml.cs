using Manage_Store.DAL;
using Manage_Store.Entity;
using Manage_Store.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Manage_Store.Pages;

public class ItemCreate : PageModel
{

    public List<string> ListLabel = DataWorkFlow.DownloadListLabel();
    public bool StatusRequestAddItem;
    [BindProperty] 
    public string Notification { get; set; }
    public string ItemId = ManipulateFunction.CreateItemId();
    [BindProperty]
    public string ItemName { get; set; }
    [BindProperty]
    public string ItemLabel { get; set; }
    [BindProperty]
    public string ItemManu { get; set; }
    [BindProperty]
    public int ItemQty { get; set; }
    [BindProperty]
    public int ItemPrice { get; set; }
    [BindProperty]
    public DateTime ItemExp { get; set; }
    [BindProperty]
    public DateTime ItemMfg { get; set; }
    
    
    public void OnGet()
    {
        // ItemId = ManipulateFunction.CreateItemId();
        ItemName = String.Empty;
        ItemManu = String.Empty;
        ItemLabel = String.Empty;
        ItemPrice = 0;
        ItemExp = DateTime.Today;
        ItemMfg = DateTime.Today;
        Notification = String.Empty;

    }

    public void OnPost()
    {
        StrucItem newItem = new StrucItem();
        
        newItem.Id = ItemId;
        newItem.Name = ItemName;
        newItem.Manufacture = ItemManu;
        newItem.Qty = ItemQty;
        newItem.Label = ItemLabel;
        newItem.Exp = DateManipulate.ConvertDatetoString(ItemExp);
        newItem.Mfg = DateManipulate.ConvertDatetoString(ItemMfg);
        newItem.Price = ItemPrice;
        StatusRequestAddItem = SolvingItem.RequestAddItem(newItem);
        switch (StatusRequestAddItem)
        {
            case true:
                Notification = $"Mat hang da duoc tao thanh cong";
                break;
            case false:
                Notification = $"That bai, Kiem tra lai thong tin mat hang duoc nhap vao";
                break;
        }
    }
}