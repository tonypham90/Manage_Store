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
    public string Date;
    public string? ImportId;
    public string ItemId;
    public int ImportQty;
}