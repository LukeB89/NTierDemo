namespace NTierDemo.BusinessLogic;
public class ButtonData : IControlData, IIconData
{
    public string Content { get; set; } = string.Empty;
    public string Style {  get; set; } = string.Empty;
    public string IconStyle {  get; set; } = string.Empty;
    public int IconName {  get; set; }
}
