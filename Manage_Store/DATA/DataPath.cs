namespace Manage_Store.DATA;

public class DataPath
{
    private static string CurrentDir;
    private static readonly DirectoryInfo DirectoryInfo;
    private static readonly FileInfo ItemLabelList;
    private static readonly FileInfo ImportRecord;
    private static FileInfo SaleRecord;
    private static readonly FileInfo ItemStore;

    
    public static string ItemLabel()
    {
        return ItemLabelList.FullName;
    }
    public static string Import()
    {
        return ImportRecord.FullName;
    }
    public static string Item()
    {
        return ItemStore.FullName;
    }
}