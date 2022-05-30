using Manage_Store.Entity;
using Newtonsoft.Json;

namespace Manage_Store.DAL;

public static class DataWorkFlow
{
    private static readonly string CurrentDir = Environment.CurrentDirectory;
    private static readonly DirectoryInfo DirectoryInfo = new DirectoryInfo(CurrentDir);
    private static readonly FileInfo ItemLabelList = new FileInfo("DataLabel.json");
    private static readonly FileInfo ImportRecord = new FileInfo("DataImportHistory.json");
    private static readonly FileInfo ImportDetail = new FileInfo("DataImportDetail.json");
    private static readonly FileInfo SaleRecord = new FileInfo("DataSaleHistory.json");
    private static readonly FileInfo BillDetail = new FileInfo("DataBillDetail.json");
    private static readonly FileInfo ItemStore = new FileInfo("DataStore.json");
    
    //space for label
    public static bool AddNewLabel(string newLabel)
    {
        List<string> currentLabel = DownloadListLabel();
        if (!string.IsNullOrEmpty(newLabel))
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
        StreamReader fileReader = new StreamReader(ItemLabelList.FullName);
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
        StreamWriter fileWriter = new StreamWriter(ItemLabelList.FullName);
        string jsonstring = JsonConvert.SerializeObject(listLabel);
        fileWriter.Write(jsonstring);
        fileWriter.Close();
        return true;
    }
    
    //end space for label

    //Store info
    public static List<StrucItem> DownloadListItem()
    {
        List<StrucItem> resList = new List<StrucItem>();
        StreamReader fileReader = new StreamReader(ItemStore.FullName);
        string jsonstring = fileReader.ReadToEnd();
        fileReader.Close();
        if (string.IsNullOrEmpty(jsonstring))
        {
            return resList;
        }
        resList = JsonConvert.DeserializeObject<List<StrucItem>>(jsonstring) ?? throw new InvalidOperationException();
        return resList;
    }
    
    public static bool UploadItemList(List<StrucItem> listItems)
    {
        if (listItems.Count==0)
        {
            return false;
        }
        StreamWriter fileWriter = new StreamWriter(ItemStore.FullName);
        string jsonstring = JsonConvert.SerializeObject(listItems);
        fileWriter.Write(jsonstring);
        fileWriter.Close();
        return true;
    }

    //End Of store info

    //import store
    public static List<ImportRecord>? DownloadDataRecordImports() //Get data from source to user
    {
        List<ImportRecord>? resList;
        StreamReader fileReader = new StreamReader(ImportRecord.FullName);
        string jsonstring = fileReader.ReadToEnd();
        fileReader.Close();
        resList = JsonConvert.DeserializeObject<List<ImportRecord>>(jsonstring);
        return resList;
    }

    public static bool UploadImportRecord(List<ImportRecord> historyImports)
    {
        if (historyImports.Count == 0)
        {
            return false;
        }

        StreamWriter fileWriter = new StreamWriter(ImportRecord.FullName);
        string jsonstring = JsonConvert.SerializeObject(historyImports);
        fileWriter.Write(jsonstring);
        fileWriter.Close();
        return true;
    }

    //End Import

    //Sale record
}