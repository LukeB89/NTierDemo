
namespace NTierDemo.BusinessLogic;

public class Active
{
    public string Content { get; set; } = string.Empty;
    public Type? ControlType { get; set; }
    public double CornerRadius { get; set; }
    public double Height { get; set; }
    public string ImagePath { get; set; } = string.Empty;
    public double Margin { get; set; }
    public string Name { get; set; } = string.Empty;
    public double PosX { get; set; }
    public double PosY { get; set; }
    public string Style { get; set; } = string.Empty;
    public string Tag { get; set; } = string.Empty;
    public double Width { get; set; }

    public Action? Click { get; set; }
    public Action<bool>? Show { get; set; }
    public Delegates.DynamicDelegate<string?,List<object>>? Fill { get; set; }
}
