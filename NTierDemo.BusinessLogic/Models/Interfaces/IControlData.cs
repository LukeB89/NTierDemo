namespace NTierDemo.BusinessLogic;
public interface IControlData
{
    public string Content { get; set; }
    public string Style { get; set; }
}

public interface IControlCheckable
{
    public bool IsChecked { get; set; }
}

public interface IIconData
{
    public string IconStyle { get; set; }
    public int IconName { get; set; }
}
