
using NTierDemo.BusinessLogic.DTOs.Structs;

namespace NTierDemo.BusinessLogic.DTOs.Controls;
public class ToDoCardData
{
    public string LabelContent { get; set; } = string.Empty;
    public string Background { get; set; } = "#00FFFFFF"; // Brushes.Transparent
    public string BorderBrush { get; set; } = "#00FFFFFF"; // Brushes.Transparent
    public ThicknessData BorderThickness { get; set; }
    public CornerRadiusData CornerRadius { get; set; }
    public ThicknessData Margin { get; set; }

    public ToDoCardData() { }
    public ToDoCardData(string labelContent, string background, string borderBrush, ThicknessData borderThickness, CornerRadiusData cornerRadius, ThicknessData margin)
    {
        LabelContent = labelContent;
        Background = background;
        BorderBrush = borderBrush;
        BorderThickness = borderThickness;
        CornerRadius = cornerRadius;
        Margin = margin;
    }

}
