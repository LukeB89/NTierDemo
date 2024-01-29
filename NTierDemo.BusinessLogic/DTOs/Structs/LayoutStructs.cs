using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NTierDemo.BusinessLogic.DTOs.Structs;
public readonly struct ThicknessData
{
    public double Left { get; }
    public double Top { get; }
    public double Right { get; }
    public double Bottom { get; }
    public ThicknessData()
    {
        Left = Top = Right = Bottom = 0;
    }

    public ThicknessData(double uniformLength)
    {
        Left = Top = Right = Bottom = uniformLength;
    }

    public ThicknessData(double left, double top, double right, double bottom)
    {
        Left = left;
        Top = top;
        Right = right;
        Bottom = bottom;
    }

    public ThicknessData(double horizontal, double vertical)
    {
        Left = Right = horizontal;
        Top = Bottom = vertical;
    }
}

public readonly struct CornerRadiusData
{
    public double TopLeft { get; }
    public double TopRight { get; }
    public double BottomLeft { get; }
    public double BottomRight { get; }

    public CornerRadiusData()
    {
        TopLeft = TopRight = BottomLeft = BottomRight = 0;
    }

    public CornerRadiusData(double uniformRadius)
    {
        TopLeft = TopRight = BottomLeft = BottomRight = uniformRadius;
    }

    public CornerRadiusData(double topLeft, double topRight, double bottomRight, double bottomLeft)
    {
        TopLeft = topLeft;
        TopRight = topRight;
        BottomLeft = bottomLeft;
        BottomRight = bottomRight;
    }
}