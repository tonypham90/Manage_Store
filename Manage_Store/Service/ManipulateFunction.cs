using Manage_Store.DAL;
using Manage_Store.Entity;

namespace Manage_Store.Service;

public class ManipulateFunction
{
    private Operation sv;
    private DataFlow df;

    public ManipulateFunction()
    {
        sv = new Operation();
        df = new DataFlow();
    }
    public string CreateItemId()
    {
        List<StrucItem>? currentListItem = DataWorkFlow.DownloadListItem();
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
    public string? NewImportId()
    {
        List<ImportRecord>? currentList = DataWorkFlow.LoadImportHistory();
        string? id = string.Empty;
        List<string?> currentIdList = new List<string?>();
        foreach (ImportRecord record in currentList)
        {
            currentIdList.Add(record.ImportId);
        }

        while (string.IsNullOrEmpty(id)||currentIdList.Contains(id))
        {
            Random ran = new Random();
            id =$"I{ran.Next(9999):0000}" ;
        }

        return id;
    }
}