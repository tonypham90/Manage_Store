using Manage_Store.DAL;
using Manage_Store.Entity;
using Microsoft.AspNetCore.Http.Features;

namespace Manage_Store.Service;

public class SolvingItemLabel
{
    public static string AddNewLabel(string newLabel)
    {
        bool isAddingGood = DataWorkFlow.AddNewLabel(newLabel.ToUpper());
        if (isAddingGood)
        {
            return $"Them loai hang thanh cong";
        }
        return $"Loai hang da ton tai";
    }

    public static List<string> CurrentLabel()
    {
        return DataWorkFlow.DownloadListLabel();
    }

    public static string RemoveLabel(string labelTarget)
    {
        List<string> currentLabelList = DataWorkFlow.DownloadListLabel();
        List<string> newLabeList = new List<string>();
        labelTarget = labelTarget.ToUpper();
        bool Iscontain = currentLabelList!.Contains(labelTarget);
        foreach (string label in currentLabelList)
        {
            if (label!=labelTarget)
            {  
                newLabeList.Add(label);
            }
        }

        DataWorkFlow.UploadLabel(newLabeList);
        // Remove item contain Label Target///
        int countItemRemoved = 0;
        //
        return $"Ton tai {Iscontain}.Da xoa loai hang {labelTarget} va {countItemRemoved} co cung loai hang";
    }

    public static string UpdateLabel(string? oldLabel, string? newLabel)
    {
        List<string> currentLabelList = DataWorkFlow.DownloadListLabel();
        List<StrucItem>? currentItemsList = DataWorkFlow.DownloadListItem();
        List<string> newLabeList = new List<string>();
        List<StrucItem>? ItemsneedUpdateID = new List<StrucItem>();
        newLabel = newLabel!.ToUpper();
        int countitemUpdated = 0;
        if (currentLabelList!.Contains(newLabel))
        {
            //Update new label for item relative with old label
            countitemUpdated = 0;
            //
            return $"Gia tri Nhan Hang moi da ton tai. {countitemUpdated} san pham tuong ung duoc thay doi,\n nhan hang moi khong them vao";
        }
        foreach (string elementLabel in currentLabelList)
        {
            if (elementLabel==oldLabel)
            {
                newLabeList.Add(newLabel);
            }
            newLabeList.Add(elementLabel);
        }
        //Update Store
        string funcChoise = "4";//find Item case 4
        ItemsneedUpdateID = SolvingItem.FindlistItems(oldLabel, funcChoise);
        foreach (StrucItem item in ItemsneedUpdateID)
        {
            StrucItem newItem = item;
            newItem.Label = newLabel;
            SolvingItem.RequestUpdateItem(newItem.Id, newItem);
        }

        bool uploadstatus = DataWorkFlow.UploadLabel(newLabeList);
        //Update new label for item relative with old label
        countitemUpdated = ItemsneedUpdateID.Count;
        //
        return $"upload status{uploadstatus}, So mat hang thay doi loai hang tuong ung la {countitemUpdated}";
    }
}