using Manage_Store.DAL;
using Manage_Store.Entity;

namespace Manage_Store.Service;

public static class SolvingItem
{
    public static bool RequestAddItem(StrucItem item)
    {
        List<StrucItem> listItem = DataWorkFlow.DownloadListItem();
        listItem.Add(item);
        return DataWorkFlow.UploadItemList(listItem);
        
    }

    public static List<StrucItem> RequestLoadStore()
    {
        return DataWorkFlow.DownloadListItem();
        
    }

    public static bool RequestUploadStore(List<StrucItem> listItems)
    {
        return DataWorkFlow.UploadItemList(listItems);
    }

    public static StrucItem FindItem(string itemId,List<StrucItem> listItems) //tim item target
    {
        foreach (StrucItem item in listItems)
        {
            if (item.Id.Contains(itemId))
            {
                return item;
            }
        }
        return new StrucItem();
    }

    public static bool RequestUpdateItem(string itemId, StrucItem newItem)
    {
        List<StrucItem> currentListItems = RequestLoadStore();
        if (DateManipulate.ConvertStringtoDateTime(newItem.Exp)<DateManipulate.ConvertStringtoDateTime(newItem.Mfg))
        {
            return false;
        }
        for (int i = 0; i < currentListItems.Count; i++)
        {
            if (currentListItems[i].Id.Contains(itemId))
            {
                currentListItems[i] = newItem;
                return RequestUploadStore(currentListItems);
            }
        }
        return false;
    }

    public static bool RequestRemoveItem(string Id)
    {
        List<StrucItem> currentListItems = RequestLoadStore();
        List<StrucItem> newListItems = new List<StrucItem>();
        foreach (StrucItem item in currentListItems)
        {
            if (!item.Id.Contains(Id))
            {
                newListItems.Add(item);
            }
        }

        return DataWorkFlow.UploadItemList(newListItems);
    }

    public static List<StrucItem> FinalistItems(string keyword, string funcchoice)
    {
        List<string> resItemsId = new List<string>();
        List<StrucItem> currentStrucItemsList = RequestLoadStore();
        List<StrucItem> resList = new List<StrucItem>();
        switch (funcchoice)
        {
            case "0":
                foreach (StrucItem item in currentStrucItemsList)
                {
                    if (item.Id.Contains(keyword) || item.Name.Contains(keyword) || item.Manufacture.Contains(keyword) || item.Label.Contains(keyword))
                    {
                        resItemsId.Add(item.Id);
                    }
                }

                break;
            case "1":
                foreach (StrucItem item in currentStrucItemsList)
                {
                    if (item.Id.Contains(keyword))
                    {
                        resItemsId.Add(item.Id);
                    }
                }

                break;
            case "2":

                foreach (StrucItem item in currentStrucItemsList)
                {
                    if (item.Name.Contains(keyword))
                    {
                        resItemsId.Add(item.Id);
                    }
                }

                break;
            case "3":
                foreach (StrucItem item in currentStrucItemsList)
                {
                    if (item.Manufacture.Contains(keyword))
                    {
                        resItemsId.Add(item.Id);
                    }
                }

                break;
            case "4":
                foreach (StrucItem item in currentStrucItemsList)
                {
                    if (item.Label.Contains(keyword))
                    {
                        resItemsId.Add(item.Id);
                    }
                }

                break;
        }

        resList.AddRange(resItemsId.Select(s => FindItem(s, currentStrucItemsList)));
        return resList;
    } //find item follow function
}