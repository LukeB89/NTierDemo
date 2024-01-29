using System.Windows.Controls;
using System.Windows.Data;
using System.Windows;
using System.Windows.Media;

namespace NTierDemo.Presentation;
public class ToDoCard : UserControl
{

    public static readonly DependencyProperty CardBackgroundProperty =
        DependencyProperty.Register("CardBackground", typeof(Brush), typeof(ToDoCard));

    public static readonly DependencyProperty CardBorderBrushProperty =
        DependencyProperty.Register("CardBorderBrush", typeof(Brush), typeof(ToDoCard));

    public static readonly DependencyProperty CardBorderThicknessProperty =
        DependencyProperty.Register("CardBorderThickness", typeof(Thickness), typeof(ToDoCard));

    public static readonly DependencyProperty CardCornerRadiusProperty =
        DependencyProperty.Register("CardCornerRadius", typeof(CornerRadius), typeof(ToDoCard));

    public static readonly DependencyProperty CardForegroundProperty =
        DependencyProperty.Register("CardForeground", typeof(Brush), typeof(ToDoCard));

    public static readonly DependencyProperty CardHeightProperty =
        DependencyProperty.Register("CardHeight", typeof(double), typeof(ToDoCard));

    public static readonly DependencyProperty CardMarginProperty =
        DependencyProperty.Register("CardMargin", typeof(Thickness), typeof(ToDoCard));

    public static readonly DependencyProperty CardPaddingProperty =
        DependencyProperty.Register("CardPadding", typeof(Thickness), typeof(ToDoCard));

    public static readonly DependencyProperty CardWidthProperty =
        DependencyProperty.Register("CardWidth", typeof(double), typeof(ToDoCard));

    public static readonly DependencyProperty LabelContentProperty =
        DependencyProperty.Register("LabelContent", typeof(string), typeof(ToDoCard));

    public Brush CardBackground
    {
        get { return (Brush)GetValue(CardBackgroundProperty); }
        set { SetValue(CardBackgroundProperty, value); }
    }

    public Brush CardBorderBrush
    {
        get { return (Brush)GetValue(CardBorderBrushProperty); }
        set { SetValue(CardBorderBrushProperty, value); }
    }

    public Thickness CardBorderThickness
    {
        get { return (Thickness)GetValue(CardBorderThicknessProperty); }
        set { SetValue(CardBorderThicknessProperty, value); }
    }

    public CornerRadius CardCornerRadius
    {
        get { return (CornerRadius)GetValue(CardCornerRadiusProperty); }
        set { SetValue(CardCornerRadiusProperty, value); }
    }

    public Brush CardForeground
    {
        get { return (Brush)GetValue(CardForegroundProperty); }
        set { SetValue(CardForegroundProperty, value); }
    }

    public double CardHeight
    {
        get { return (double)GetValue(CardHeightProperty); }
        set { SetValue(CardHeightProperty, value); }
    }

    public Thickness CardMargin
    {
        get { return (Thickness)GetValue(CardMarginProperty); }
        set { SetValue(CardMarginProperty, value); }
    }
    public Thickness CardPadding
    {
        get { return (Thickness)GetValue(CardPaddingProperty); }
        set { SetValue(CardPaddingProperty, value); }
    }

    public double CardWidth
    {
        get { return (double)GetValue(CardWidthProperty); }
        set { SetValue(CardWidthProperty, value); }
    }
    public string LabelContent
    {
        get { return (string)GetValue(LabelContentProperty); }
        set { SetValue(LabelContentProperty, value); }
    }

    public ToDoCard()
    {
        InitializeCard();
    }

    private void InitializeCard()
    {
        Border cardBorder = new Border()
        {
            Background = Brushes.Transparent,
            BorderBrush = Brushes.Black,

            HorizontalAlignment = HorizontalAlignment.Stretch,
            VerticalAlignment = VerticalAlignment.Stretch,
            BorderThickness = new Thickness(1),
            CornerRadius = new CornerRadius(0),
            Margin = new Thickness(5),
            MaxWidth = 600,
            MaxHeight = 300
        };

        TextBlock label = new TextBlock()
        {
            Text = LabelContent,
            HorizontalAlignment = HorizontalAlignment.Center,
            VerticalAlignment = VerticalAlignment.Center,
            FontSize = 18,
            Foreground = Brushes.Black,
            Background = Brushes.Transparent
        };
        
        cardBorder.Child = label;

        BindingOperations.SetBinding(cardBorder, Border.BackgroundProperty, new Binding("CardBackground") { Source = this });
        BindingOperations.SetBinding(cardBorder, Border.BorderBrushProperty, new Binding("CardBorderBrush") { Source = this });
        BindingOperations.SetBinding(cardBorder, Border.BorderThicknessProperty, new Binding("CardBorderThickness") { Source = this });
        BindingOperations.SetBinding(cardBorder, Border.CornerRadiusProperty, new Binding("CardCornerRadius") { Source = this });
        BindingOperations.SetBinding(cardBorder, Border.PaddingProperty, new Binding("CardPadding") { Source = this });
        BindingOperations.SetBinding(cardBorder, FrameworkElement.MarginProperty, new Binding("CardMargin") { Source = this });
        BindingOperations.SetBinding(cardBorder, FrameworkElement.WidthProperty, new Binding("CardWidth") { Source = this });
        BindingOperations.SetBinding(cardBorder, FrameworkElement.HeightProperty, new Binding("CardHeight") { Source = this });
        BindingOperations.SetBinding(label, TextBlock.TextProperty, new Binding("LabelContent") { Source = this });
        BindingOperations.SetBinding(label, TextBlock.BackgroundProperty, new Binding("CardBackground") { Source = this });
        BindingOperations.SetBinding(label, TextBlock.ForegroundProperty, new Binding("CardForeground") { Source = this });

        Content = cardBorder;
    }
}
