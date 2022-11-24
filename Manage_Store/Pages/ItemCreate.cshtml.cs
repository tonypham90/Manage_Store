using Manage_Store.DAL;
using Manage_Store.Entity;
using Manage_Store.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Manage_Store.Pages;

public class ItemCreate : PageModel
{
    public Operation sv;
    public DataFlow df;

    public List<string> ListLabel { get; set; }
    public bool StatusRequestAddItem;
    [BindProperty] 
    public string Notification { get; set; }
    public string ItemId { get; set; }
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
        ListLabel = DataWorkFlow.DownloadListLabel();
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
        var newItem = new StrucItem();
        ItemId = sv.ManipulateFunction.CreateItemId();
        
        newItem.Id = ItemId;
        newItem.Name = ItemName;
        newItem.Manufacture = ItemManu;
        newItem.Qty = ItemQty;
        newItem.Label = ItemLabel;
        newItem.Exp = sv.DateManipulate.ConvertDatetoString(ItemExp);
        newItem.Mfg = sv.DateManipulate.ConvertDatetoString(ItemMfg);
        newItem.Price = ItemPrice;
        StatusRequestAddItem = sv.SolvingItem.RequestAddItem(newItem);
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