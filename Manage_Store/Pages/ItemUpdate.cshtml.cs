using Manage_Store.DAL;
using Manage_Store.Entity;
using Manage_Store.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Manage_Store.Pages;

public class ItemUpdate : PageModel
{
    public Operation sv;
    public DataFlow df;

    public List<string> ListLabel { get; set; }
    public List<StrucItem>? ListItems { get; set; }
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
        ListLabel = DataWorkFlow.DownloadListLabel();
        // ItemId = ManipulateFunction.CreateItemId();
        ListItems = DataWorkFlow.DownloadListItem();
        var item = sv.SolvingItem.FindItem(id, ListItems);
        ItemlabelList.Add(item.Label);
        List<string> showlist = ListLabel;
        foreach (string s in showlist)
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
        ItemExp = sv.DateManipulate.ConvertStringtoDateTime(item.Exp);
        ItemMfg = sv.DateManipulate.ConvertStringtoDateTime(item.Mfg);
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
        itemUpdated.Exp = sv.DateManipulate.ConvertDatetoString(ItemExp);
        itemUpdated.Mfg = sv.DateManipulate.ConvertDatetoString(ItemMfg);
        itemUpdated.Price = ItemPrice;
        
        
        StatusUpdateData = sv.SolvingItem.RequestUpdateItem(id,itemUpdated);
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