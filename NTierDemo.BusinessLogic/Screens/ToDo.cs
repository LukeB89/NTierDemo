namespace NTierDemo.BusinessLogic;
public abstract class ToDoBase
{
    public List<object> FillGrid()
    {
        List<object> root = new();

        GridColumnData gridColumnData = new()
        {
            ColumnWidth = 200,
            ContainerType = Enums.ContainerTypes.StackPanel,
            ScreenName = Enums.ScreenNames.ToDoContent
        };
        root.Add(gridColumnData);
        return root;
    }
}
