using Manage_Store.DAL;
using Manage_Store.Entity;
using Manage_Store.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Manage_Store.Pages;

public class ItemUpdate : PageModel
{

    public List<string> ListLabel = DataWorkFlow.DownloadListLabel();
    public List<StrucItem> ListItems = DataWorkFlow.DownloadListItem();
    public List<string> ItemlabelList = new List<string>();
    public bool StatusUpdateData;
    public string Notification { get; set; }
    [BindProperty(SupportsGet = true)]
    public string id { get; set; }
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
        StrucItem item = SolvingItem.FindItem(id, ListItems);
        ItemlabelList.Add(item.Label);
        foreach (string s in ListLabel)
        {
            if (!ItemlabelList.Contains(s))
            {
                ItemlabelList.Add(s);
            }
        }
        ItemName = item.Name;
        ItemManu = item.Manufacture;
        ItemQty = item.Qty;
        ItemLabel = item.Label;
        ItemPrice = item.Price;
        ItemExp = DateManipulate.ConvertStringtoDateTime(item.Exp);
        ItemMfg = DateManipulate.ConvertStringtoDateTime(item.Mfg);
        Notification = String.Empty;
    }

    public void OnPost()
    {
        StrucItem itemUpdated = new StrucItem();
        itemUpdated.Id = id;
        itemUpdated.Name = ItemName;
        itemUpdated.Manufacture = ItemManu;
        itemUpdated.Qty = ItemQty;
        itemUpdated.Label = ItemLabel;
        itemUpdated.Exp = DateManipulate.ConvertDatetoString(ItemExp);
        itemUpdated.Mfg = DateManipulate.ConvertDatetoString(ItemMfg);
        itemUpdated.Price = ItemPrice;
        
        
        StatusUpdateData = SolvingItem.RequestUpdateItem(id,itemUpdated);
        switch (StatusUpdateData)
        {
            case true:
                Notification = $"Cap nhat thanh cong";
                Response.Redirect("/index");
                break;
            case false:
                Notification = $"Cap nhat That bai- kiem tra lai thong tin";
                break;
        }
    }
}

class ItemUpdateImpl : ItemUpdate
{
}