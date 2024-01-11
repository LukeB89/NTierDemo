namespace NTierDemo.BusinessLogic;
public class RadioButtonData : IControlData, IIconData, IControlCheckable
{
    public string Content { get; set; } = string.Empty;
    public string Style {  get; set; } = string.Empty;
    public bool IsChecked { get; set; }
    public string IconStyle {  get; set; } = string.Empty;
    public int IconName {  get; set; } = 88; // Icon X as default
}
