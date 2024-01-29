
using NTierDemo.BusinessLogic.DTOs.Structs;
using System;
using System.Windows;
using System.Windows.Media;

namespace NTierDemo.Presentation;
public static class Converters
{
    public static Brush? GetBrushFromHex(string hex)
    {
        ArgumentException.ThrowIfNullOrEmpty(hex, nameof(hex));
        if (!hex.StartsWith('#')) throw new ArgumentException($"Hex value supplied to {nameof(hex)} does not begin with #");

        BrushConverter converter = new();
        return converter.ConvertFromString(hex) as Brush;
    }

    public static Thickness GetThicknessFromData(ThicknessData data)
    {
        return new Thickness(data.Left, data.Top, data.Right, data.Bottom);
    }

    internal static CornerRadius GetCornerRadiusFromData(CornerRadiusData data)
    {
        return new CornerRadius(data.TopLeft, data.TopRight, data.BottomRight, data.BottomLeft);
    }
}
