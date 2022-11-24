using Manage_Store.DATA;
using Manage_Store.Entity;
using Manage_Store.Service;
using Newtonsoft.Json;

namespace Manage_Store.DAL;

public static class DataWorkFlow
{

    private static DataPath dp;
    
    //space for label
    public static bool AddNewLabel(string? newLabel)
    {
        List<string> currentLabel = DownloadListLabel();
        if (newLabel != null)
        {
            newLabel = newLabel.ToUpper();
            
            if (currentLabel.Contains(newLabel))
            {
                return false;
            }
            currentLabel.Add(newLabel);
        }
        return UploadLabel(currentLabel);
    }

    public static List<string> DownloadListLabel()
    {
        List<string> resList = new List<string>();
        StreamReader fileReader = new StreamReader(DataPath.ItemLabel());
        string jsonstring = fileReader.ReadToEnd();
        fileReader.Close();
        if (string.IsNullOrEmpty(jsonstring))
        {
            return resList;
        }
        resList = JsonConvert.DeserializeObject<List<string>>(jsonstring) ?? throw new InvalidOperationException();
        return resList;
    }

    public static bool UploadLabel(List<string> listLabel)
    {
        if (listLabel.Count==0)
        {
            return false;
        }
        StreamWriter fileWriter = new StreamWriter(DataPath.ItemLabel());
        string jsonstring = JsonConvert.SerializeObject(listLabel);
        fileWriter.Write(jsonstring);
        fileWriter.Close();
        return true;
    }
    
    //end space for label

    //Store info
    public static List<StrucItem>? DownloadListItem()
    {
        List<StrucItem>? resList = new List<StrucItem>();
        StreamReader fileReader = new StreamReader(DataPath.Item());
        string jsonstring = fileReader.ReadToEnd();
        fileReader.Close();
        if (string.IsNullOrEmpty(jsonstring))
        {
            return resList;
        }
        resList = JsonConvert.DeserializeObject<List<StrucItem>>(jsonstring) ?? throw new InvalidOperationException();
        return resList;
    }
    
    public static bool UploadItemList(List<StrucItem>? listItems)
    {
        if (listItems.Count==0)
        {
            return false;
        }
        StreamWriter fileWriter = new StreamWriter(DataPath.Item());
        string jsonstring = JsonConvert.SerializeObject(listItems);
        fileWriter.Write(jsonstring);
        fileWriter.Close();
        return true;
    }

    //End Of store info

    //import store
    public static List<ImportRecord>? LoadImportHistory()
    {
        StreamReader fileReader = new StreamReader(DataPath.Import());
        string Jsonstring = fileReader.ReadToEnd();
        fileReader.Close();
        return JsonConvert.DeserializeObject<List<ImportRecord>>(Jsonstring);
    }

    public static bool UploadImportHistory(List<ImportRecord> Historylist)
    {
        StreamWriter fileWriter = new StreamWriter(DataPath.Import());
        fileWriter.Write(JsonConvert.SerializeObject(Historylist));
        fileWriter.Close();
        return true;
    }

    //End Import

    //Sale record
}