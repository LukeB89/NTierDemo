namespace NTierDemo.BusinessLogic;
public class GridColumnData
{
    public double ColumnWidth { get; set; } // <= 10 is proportional (1*,2*,...) > 10 is exact
    public Enums.ContainerTypes ContainerType { get; set; }
    public Enums.ScreenNames ScreenName { get; set; }
}
