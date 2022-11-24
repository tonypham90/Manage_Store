namespace Manage_Store.Service;

public class Operation
{
    public CaculateSummary CaculateSummary;
    public DateManipulate DateManipulate;
    public ImportStore ImportStore;
    public ManipulateFunction ManipulateFunction;
    public SolvingItem SolvingItem;
    public SolvingItemLabel SolvingItemLabel;

    public Operation()
    {
        CaculateSummary = new CaculateSummary();
        DateManipulate = new DateManipulate();
        ImportStore = new ImportStore();
        ManipulateFunction = new ManipulateFunction();
        SolvingItem = new SolvingItem();
        SolvingItemLabel = new SolvingItemLabel();
    }
}