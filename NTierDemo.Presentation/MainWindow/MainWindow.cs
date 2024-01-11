using NTierDemo.BusinessLogic;
using System;
using System.Runtime.InteropServices;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Interop;

namespace NTierDemo.Presentation;

public class MainWindow : Window
{

    private readonly double _applicationDefaultHeight = 720;
    private readonly double _applicationDefaultWidth = 1080;
    private readonly string _controlBarName = "strlBarPnl";
    private readonly double _windowBorderRadius = 15;
    private readonly double _windowBorderThickness = 1.5;
    private readonly double _windowControlBarHeight = 25;
    private readonly double _windowCaptionHeight = 35;
    private readonly double _windowLeftEdgeMargin = 15;
    private readonly double _windowRightEdgeMargin = 10;

    public MainWindow()
    {
        // This is the entry screen. It will setup the screen defaults, add the side panel and the initial content
        InitializeWindow();
        Border rootElement = AddWindowBorder();

        rootElement.Child = MainLayout();

        Content = rootElement;
    }

    private Border AddWindowBorder()
    {

        LinearGradientBrush linearGradient = new();
        linearGradient.StartPoint = new Point(0, 0);
        linearGradient.EndPoint = new Point(1, 1);
        linearGradient.GradientStops.Add(new()
        {
            Color = (Color)Application.Current.TryFindResource("C_WinBorder1"),
            Offset = 0
        });
        linearGradient.GradientStops.Add(new()
        {
            Color = (Color)Application.Current.TryFindResource("C_WinBorder2"),
            Offset = 0.5
        });
        linearGradient.GradientStops.Add(new()
        {
            Color = (Color)Application.Current.TryFindResource("C_WinBorder3"),
            Offset = 1
        });

        Border border = new()
        {
            Background = Brushes.Transparent,
            BorderBrush = linearGradient,
            BorderThickness = new Thickness(_windowBorderThickness),
            CornerRadius = new CornerRadius(_windowBorderRadius),
            SnapsToDevicePixels = true
        };

        return border;
    }

    private UIElement MainLayout()
    {
        Grid mainGrid = new();

        mainGrid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(250) });
        mainGrid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) });

        // Add a side panel
        Border sidePanel = CreateSidePanel();
        Grid.SetColumn(sidePanel, 0);
        mainGrid.Children.Add(sidePanel);

        // Add content panel
        Border contentPanel = CreateContentPanel();
        Grid.SetColumn(contentPanel, 1);
        mainGrid.Children.Add(contentPanel);


        return mainGrid;
    }

    private void InitializeWindow()
    {
        Width = _applicationDefaultWidth;
        Height = _applicationDefaultHeight;
        WindowStartupLocation = WindowStartupLocation.CenterScreen;
        WindowStyle = WindowStyle.None;
        AllowsTransparency = true;
        Background = Brushes.Transparent;
    }

    private Border CreateSidePanel()
    {
        StackPanel sidePanel = new();

        StackPanel logoPanel = new()
        {
            Height = 35,
            Margin = new(_windowLeftEdgeMargin, _windowControlBarHeight,0,40),
        };
        

        TextBlock logoText = new()
        {
            Text = "N-Tier Demo",
            Foreground = (Brush)Application.Current.TryFindResource("C_Title2"),
            FontSize = 20,
            FontFamily = new FontFamily("Calibri"),
            FontWeight = FontWeights.Medium,
            VerticalAlignment = VerticalAlignment.Center,
            HorizontalAlignment = HorizontalAlignment.Center
        };

        logoPanel.Children.Add(logoText);

        // Add some content to the side panel
        sidePanel.Children.Add(logoPanel);

        IScreenBuilder page = new SideBar();
        WindowLogic.FillControllWithActives(ref sidePanel, page.Actives);

        // Wrap in Border
        LinearGradientBrush linearGradient = new();
        linearGradient.StartPoint = new Point(0, 0);
        linearGradient.EndPoint = new Point(1, 0.7);
        linearGradient.GradientStops.Add(new()
        {
            Color = (Color)Application.Current.TryFindResource("C_SBackground1"),
            Offset = 0
        });
        linearGradient.GradientStops.Add(new()
        {
            Color = (Color)Application.Current.TryFindResource("C_SBackground2"),
            Offset = 1
        });

        Border border = new()
        {
            Background = linearGradient,
            CornerRadius = new CornerRadius(_windowBorderRadius,0,0, _windowBorderRadius),
            SnapsToDevicePixels = true,

            Child = sidePanel

        };

        return border;

    }

    private Border CreateContentPanel()
    {
        // Grid layout for Control Bar and Caption / Headers and Content / child views.
        Grid contentGrid = new();

        contentGrid.RowDefinitions.Add(new RowDefinition { Height = new GridLength(_windowControlBarHeight) });
        contentGrid.RowDefinitions.Add(new RowDefinition { Height = new GridLength(_windowCaptionHeight) });
        contentGrid.RowDefinitions.Add(new RowDefinition { Height = new GridLength(1, GridUnitType.Star) });

        StackPanel ctrlBar = CreateControlBar();
        Grid.SetColumn(ctrlBar, 0);
        contentGrid.Children.Add(ctrlBar);

        // Wrap in Border
        LinearGradientBrush linearGradient = new();
        linearGradient.StartPoint = new Point(0,0.1);
        linearGradient.EndPoint = new Point(1, 0.6);
        linearGradient.GradientStops.Add(new()
        {
            Color = (Color)Application.Current.TryFindResource("C_PBackground1"),
            Offset = 0
        });
        linearGradient.GradientStops.Add(new()
        {
            Color = (Color)Application.Current.TryFindResource("C_PBackground2"),
            Offset = 1
        });

        Border border = new()
        {
            Background = linearGradient,
            CornerRadius = new CornerRadius(0, _windowBorderRadius, _windowBorderRadius, 0),
            SnapsToDevicePixels = true,

            Child = contentGrid

        };

        return border;
    }

    private StackPanel CreateControlBar()
    {
        StackPanel sidePanel = new()
        {
            Name = _controlBarName,
            Orientation = Orientation.Horizontal,
            FlowDirection = FlowDirection.RightToLeft,
            Background = Brushes.Transparent,
            Margin = new(0, 0, _windowRightEdgeMargin, 0),
        };
        sidePanel.MouseLeftButtonDown += Handle_ControlBar_MouseLeftButtonDown;
        sidePanel.MouseEnter += Handle_ControlBar_MouseEnter;

        IScreenBuilder page = new ControlBar();
        WindowLogic.FillControllWithActives(ref sidePanel, page.Actives);

        return sidePanel;
    }

    private void Handle_ControlBar_MouseEnter(object sender, MouseEventArgs e)
    {
        MaxHeight = SystemParameters.MaximizedPrimaryScreenHeight;
        MaxWidth = SystemParameters.MaximizedPrimaryScreenWidth;
    }

    private void Handle_ControlBar_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
    {
        if (e.ClickCount == 2)
        {
            // double click chnages minmax state
            if (ResizeMode == ResizeMode.CanResize || ResizeMode == ResizeMode.CanResizeWithGrip)
            {
                WindowLogic.SwitchState(this);
            }
        }
        else
        {
            WindowInteropHelper helper = new WindowInteropHelper(this); // Gets the object
            SendMessage(helper.Handle, 161, 2, 0); // normalises if required and captures movement while mousbutton down
        }
    }

    [DllImport("user32.dll")]
    public static extern IntPtr SendMessage(IntPtr hWnd, int wMsg, int wParam, int lParam);
}
