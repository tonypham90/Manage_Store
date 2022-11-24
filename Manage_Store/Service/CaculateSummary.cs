using Manage_Store.Entity;

namespace Manage_Store.Service;

public class CaculateSummary
{
    public static List<StrucItem> listOverdue()
    {
        List<StrucItem> resList = new List<StrucItem>();
        List<StrucItem> currentItemsList = SolvingItem.RequestLoadStore();
        foreach (StrucItem item in currentItemsList)
        {
            DateTime itemdate = DateManipulate.ConvertStringtoDateTime(item.Exp);
            if (itemdate<DateTime.Today)
            {
                resList.Add(item);
            }
        }
        return resList;
    }

    public static int countItemLabel(string label)
    {
        List<StrucItem> currentlistItems = SolvingItem.RequestLoadStore();
        int count = 0;
        foreach (StrucItem item in currentlistItems)
        {
            if (item.Label.Contains(label))
            {
                count++;
            }
        }

        return count;
    }
}