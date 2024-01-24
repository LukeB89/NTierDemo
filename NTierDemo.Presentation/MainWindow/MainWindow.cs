using NTierDemo.BusinessLogic;
using System;
using System.Runtime.InteropServices;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Interop;
using FontAwesome.Sharp;
using System.Windows.Shapes;
using System.Windows.Data;
using System.ComponentModel;

namespace NTierDemo.Presentation;

public class MainWindow : Window, INotifyPropertyChanged
{
    #region Readonly Fields

    private readonly double _applicationDefaultHeight = 720;
    private readonly double _applicationDefaultWidth = 1080;
    private readonly string _controlBarName = "strlBarPnl";
    private readonly double _windowBorderRadius = 15;
    private readonly double _windowBorderThickness = 1.5;
    private readonly double _windowControlBarHeight = 25;
    private readonly double _windowCaptionHeight = 35;
    private readonly double _windowLeftEdgeMargin = 15;
    private readonly double _windowRightEdgeMargin = 10;
    private readonly double _windowTitleIconSize = 20;
    private readonly double _windowTitleFontSize = 16;
    private readonly double _windowUserFontSize = 16;
    private readonly double _windowMainContentMargin = 25;

    #endregion

    #region Fields

    private string _loggedInUser;
    private string _titleText;
    private IconChar _iconType;

    #endregion

    #region Window Properties

    public string TitleText
    {
        get { return _titleText; }
        set
        {
            if (_titleText != value)
            {
                _titleText = value;
                NotifyPropertyChanged(nameof(TitleText));
            }
        }
    }

    public IconChar IconType
    {
        get { return _iconType; }
        set
        {
            if (_iconType != value)
            {
                _iconType = value;
                NotifyPropertyChanged(nameof(IconType));
            }
        }
    }

    #endregion

    public MainWindow()
    {

        _loggedInUser = "Luke Byrne"; // this will be altered when login is implemented

        // This is the entry screen. It will setup the screen defaults, add the side panel and the initial content
        InitializeWindow();
        Border rootElement = AddWindowBorder();

        DataContext = this;

        rootElement.Child = MainLayout();

        Content = rootElement;

        _titleText = "ToDo";
        _iconType = IconChar.ListCheck;

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
        Grid.SetRow(ctrlBar, 0);
        contentGrid.Children.Add(ctrlBar);

        Grid titleBar = CreateTitleBar();
        Grid.SetRow(titleBar, 1);
        contentGrid.Children.Add(titleBar);

        ContentControl mainContent = CreateMainContent();
        Grid.SetRow(mainContent, 2);
        contentGrid.Children.Add(mainContent);

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

    private ContentControl CreateMainContent()
    {
        return new ContentControl()
        {
            Margin = new Thickness(_windowMainContentMargin)
        };
    }

    private Grid CreateTitleBar()
    {
        Grid titleBar = new();

        titleBar.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) });
        titleBar.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) });

        // Title section
        StackPanel title = new()
        {
            Orientation = Orientation.Horizontal,
            VerticalAlignment = VerticalAlignment.Center,
        };

        IconImage titleIcon = new()
        {
            Height = _windowTitleIconSize,
            Width = _windowTitleIconSize,
            Foreground = (Brush)Application.Current.TryFindResource("C_Title2"),
            Margin = new Thickness(35, 0, 10, 0)
        };
        titleIcon.SetBinding(IconImage.IconProperty, new Binding(nameof(IconType)));
        title.Children.Add(titleIcon);

        TextBlock titleText = new()
        {
            Foreground = (Brush)Application.Current.TryFindResource("C_Title2"),
            FontSize = _windowTitleFontSize,
            FontFamily = new FontFamily("Calibri"),
            FontWeight = FontWeights.Medium,
            VerticalAlignment= VerticalAlignment.Center,
        };
        titleText.SetBinding(TextBlock.TextProperty, new Binding(nameof(TitleText)));
        title.Children.Add(titleText);

        Grid.SetColumn(title, 0);
        titleBar.Children.Add(title);

        // User Control Section
        StackPanel userCtrl = new()
        {
            Orientation = Orientation.Horizontal,
            FlowDirection = FlowDirection.RightToLeft,
            VerticalAlignment = VerticalAlignment.Center,
            Margin = new Thickness(0,0,10,0)
        };

        Button userButton = new()
        {
            Style = (Style)Application.Current.TryFindResource("userCtrlButton"),
            Tag = Application.Current.TryFindResource("C_Pallet1")
        };

        IconImage butnIcon = new()
        {
            Icon = IconChar.AngleDown,
            Style = (Style)Application.Current.TryFindResource("userCtrlButtonIcon"),
        };
        userButton.Content = butnIcon;
        userCtrl.Children.Add(userButton);

        TextBlock userText = new()
        {
            Text = _loggedInUser,
            Foreground = (Brush)Application.Current.TryFindResource("C_Title3"),
            FontSize = _windowUserFontSize,
            FontFamily = new FontFamily("Calibri"),
            FontWeight = FontWeights.Medium,
            VerticalAlignment = VerticalAlignment.Center,
        };
        userCtrl.Children.Add(userText);

        // Profile Picture
        Ellipse profile = new()
        {
            Width = _windowCaptionHeight,
            Height = _windowCaptionHeight,
            Stroke = (Brush)Application.Current.TryFindResource("C_Pallet1"),
            StrokeThickness = 2,
            Margin = new Thickness(10,0,10,0),
        };

        // Picture to be replaced later
        IconImage iconImage = new()
        {
            Icon = IconChar.UserAstronaut,
            Foreground = (Brush)Application.Current.TryFindResource("C_Pallet2")
        };

        profile.Fill = new VisualBrush()
        {
            Visual = iconImage
        };
        userCtrl.Children.Add(profile);

        userButton = new()
        {
            Style = (Style)Application.Current.TryFindResource("userCtrlButton"),
            Tag = Application.Current.TryFindResource("C_Pallet3")
        };

        butnIcon = new()
        {
            Icon = IconChar.Clock,
            Style = (Style)Application.Current.TryFindResource("userCtrlButtonIcon"),
        };
        userButton.Content = butnIcon;
        userCtrl.Children.Add(userButton);

        userButton = new()
        {
            Style = (Style)Application.Current.TryFindResource("userCtrlButton"),
            Tag = Application.Current.TryFindResource("C_Pallet4")
        };

        butnIcon = new()
        {
            Icon = IconChar.Envelope,
            Style = (Style)Application.Current.TryFindResource("userCtrlButtonIcon"),
        };
        userButton.Content = butnIcon;
        userCtrl.Children.Add(userButton);

        userButton = new()
        {
            Style = (Style)Application.Current.TryFindResource("userCtrlButton"),
            Tag = Application.Current.TryFindResource("C_Pallet5")
        };

        butnIcon = new()
        {
            Icon = IconChar.Bell,
            Style = (Style)Application.Current.TryFindResource("userCtrlButtonIcon"),
        };
        userButton.Content = butnIcon;
        userCtrl.Children.Add(userButton);

        Grid.SetColumn(userCtrl, 1);
        titleBar.Children.Add(userCtrl);

        return titleBar;
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

    #region iNotifyPropertyChange Implementation

    public event PropertyChangedEventHandler? PropertyChanged;

    private void NotifyPropertyChanged(string propertyName)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

    #endregion

    #region Window Event Handlers

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

    #endregion
}
