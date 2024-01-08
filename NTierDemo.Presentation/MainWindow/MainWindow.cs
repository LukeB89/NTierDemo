using NTierDemo.BusinessLogic;
using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Markup;
using System.Windows.Media;

namespace NTierDemo.Presentation
{
    public class MainWindow : Window
    {
        private readonly double _windowBorderRadius = 15;
        private readonly double _windowBorderThickness = 1.5;
        private readonly double _windowControlBarHeight = 25;
        private readonly double _windowEdgeMargin = 15;
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


            return mainGrid;
        }

        private void InitializeWindow()
        {
            Width = 1080;
            Height = 720;
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
                Margin = new(_windowEdgeMargin, _windowControlBarHeight,0,40),
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
            //sidePanel.Children.Add(CreatePageElement<StackPanel>(new SideBar()));
            IScreenBuilder page = new SideBar();
            foreach (Active active in page.Actives)
            {
                if (active.ControlType == typeof(Button))
                {
                    sidePanel.Children.Add(WindowLogic.CreateButtonElement(active));
                }
                else if (active.ControlType == typeof(RadioButton))
                {
                    sidePanel.Children.Add(WindowLogic.CreateRadioButtonElement(active));
                }
            }

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
                BorderThickness = new Thickness(_windowBorderThickness),
                CornerRadius = new CornerRadius(_windowBorderRadius,0,0, _windowBorderRadius),

                Child = sidePanel

            };

            return border;

        }
        private T CreatePageElement<T>(IScreenBuilder page) where T : UIElement, IAddChild, new()
        {
            T rootElement = new();

            foreach (Active active in page.Actives)
            {
                if (active.ControlType == typeof(Button))
                {
                    rootElement.AddChild(WindowLogic.CreateButtonElement(active));
                }
                else if (active.ControlType == typeof(RadioButton))
                {
                    rootElement.AddChild(WindowLogic.CreateRadioButtonElement(active));
                }
            }
            return rootElement;
        }
    }
}
