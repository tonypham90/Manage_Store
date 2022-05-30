namespace Manage_Store.Entity;

public struct StrucItem
{
    public string Id;
    public string Name;
    public string Label;
    public string Manufacture;
    public int Qty;
    public int Price;
    public string Exp,Mfg;
}

public struct ImportRecord
{
    public string Date, ImportId,ItemId;
    public int Qty;
}

public struct BillSale
{
    public string SaleId;
    public string SaleDate;
}
public struct DetailBill
{
    public string SaleId;
    public string ItemId;
    public int Qty;
}