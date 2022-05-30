using Manage_Store.DAL;
using Manage_Store.Entity;
using Manage_Store.Pages;

namespace Manage_Store.Service;

public class ImportStore
{
    public static string RequestNewIdImport()
    {
        List<ImportRecord> importRecords = DataWorkFlow.DownloadDataRecordImports();
        return ManipulateFunction.CreateImportId();
    }

    public static bool RequestAddNewImport(ImportRecord newImportRecord)
    {
        List<ImportRecord> currentImportRecords = DataWorkFlow.DownloadDataRecordImports();
        if (newImportRecord.Qty == 0)
        {
            return false;
        }
        currentImportRecords.Add(newImportRecord);
        bool status = DataWorkFlow.UploadImportRecord(currentImportRecords);
        if (status)
        {
            return true;
        }

        return false;
    }
}