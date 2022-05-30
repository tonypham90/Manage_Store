using Manage_Store.DAL;
using Manage_Store.Entity;

namespace Manage_Store.Service;

public class ManipulateFunction
{
    public static string CreateItemId()
    {
        List<StrucItem> currentListItem = DataWorkFlow.DownloadListItem();
        string id = String.Empty;
        List<string> currentIdList = new List<string>();
        foreach (StrucItem item in currentListItem)
        {
            currentIdList.Add(item.Id);
        }
        while (string.IsNullOrEmpty(id)|| currentIdList.Contains(id))
        {
            Random ran = new Random();
            id = ran.Next(9999).ToString("0000");
        }
        return id;
    }

    public static string CreateImportId()
    {
        List<ImportRecord> currentListdDataRecordImports = DataWorkFlow.DownloadDataRecordImports();
        string id = String.Empty;
        List<string> currentIdList = new List<string>();
        foreach (ImportRecord item in currentListdDataRecordImports)
        {
            currentIdList.Add(item.ImportId);
        }
        while (string.IsNullOrEmpty(id)|| currentIdList.Contains(id))
        {
            Random ran = new Random();
            id = ran.Next(9999).ToString("0000");
        }
        return id;
    }
    
}