using Manage_Store.Entity;

namespace Manage_Store.Service;

public class CaculateSummary
{
    private Operation sv;

    public CaculateSummary()
    {
        sv = new Operation();
    }
    public List<StrucItem> listOverdue()
    {
        List<StrucItem> resList = new List<StrucItem>();
        List<StrucItem> currentItemsList = sv.SolvingItem.RequestLoadStore();
        foreach (StrucItem item in currentItemsList)
        {
            DateTime itemdate = sv.DateManipulate.ConvertStringtoDateTime(item.Exp);
            if (itemdate<DateTime.Today)
            {
                resList.Add(item);
            }
        }
        return resList;
    }

    public int countItemLabel(string label)
    {
        List<StrucItem> currentlistItems = sv.SolvingItem.RequestLoadStore();
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