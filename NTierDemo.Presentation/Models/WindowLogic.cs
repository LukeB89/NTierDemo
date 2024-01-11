using FontAwesome.Sharp;
using NTierDemo.BusinessLogic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;

namespace NTierDemo.Presentation;
public static class WindowLogic
{
    public static void Handle_ControlBar_ButtonClose()
    {
        Application.Current.Shutdown();
    }

    public static void Handle_ControlBar_ButtonMaximise()
    {
        if (Application.Current.MainWindow is Window mainWindow)
        {
            SwitchState(mainWindow);
        }
    }
    public static void Handle_ControlBar_ButtonMinimise()
    {
        if (Application.Current.MainWindow is Window mainWindow)
        {
            SwitchState(mainWindow, true);
        }
    }
    public static void OpenScreen(Enums.ScreenNames screenName)
    {
        switch (screenName)
        {
            case Enums.ScreenNames.Unknown:
                MessageBox.Show($"Unknown Screen Selected");
                break;
            case Enums.ScreenNames.ToDo:
                MessageBox.Show($"ToDo Screen is opening");
                break;
            case Enums.ScreenNames.Calculator:
                MessageBox.Show($"Calculator Screen is opening");
                break;
            case Enums.ScreenNames.Calendar:
                MessageBox.Show($"Calendar Screen is opening");
                break;
            case Enums.ScreenNames.Clock:
                MessageBox.Show($"Clock Screen is opening");
                break;
            case Enums.ScreenNames.Weather:
                MessageBox.Show($"Weather Screen is opening");
                break;
        }
    }

    public static Button CreateButtonElement(Active active)
    {
        Button button = new()
        {
            Content = CreateImageTextContent(active.Content, active.ImagePath, active.Width, active.Height),
            Width = active.Width,
            Height = active.Height
        };
        button.Click += (sender, e) => active.Click?.Invoke();

        return button;
    }

    public static RadioButton CreateRadioButtonElement(Active active, string fillParameter = "")
    {
        RadioButton button = new()
        {
            Style = (Style)Application.Current.TryFindResource(active.Style),
            Tag = Application.Current.TryFindResource(active.Tag),
        };

        button.Click += (sender, e) => active.Click?.Invoke();

        if (string.IsNullOrWhiteSpace(active.Content))
        {

            List<object> buttonContent = active.Fill?.Invoke(fillParameter) ?? new();
            if (buttonContent.Count != 0)
            {
                RadioButtonData data = buttonContent.First() as RadioButtonData ?? new();
                button.IsChecked = data.IsChecked;

                StackPanel stackPanel = new()
                {
                    Orientation = Orientation.Horizontal
                };

                IconImage iconImage = new()
                {
                    Style = (Style)(Application.Current.TryFindResource(data.IconStyle)),
                    Icon = (IconChar)data.IconName
                };

                TextBlock textBlock = new()
                {
                    Text = data.Content,
                    Style = (Style)Application.Current.TryFindResource(data.Style)
                };

                stackPanel.Children.Add(iconImage);
                stackPanel.Children.Add(textBlock);
                button.Content = stackPanel;
            }
            else
            {
                throw new NotImplementedException($"The RadioButton Fill(\"{fillParameter}\") returned no data");
            }
        }
        else
        {
            button.Content = CreateImageTextContent(active.Content, active.ImagePath, active.Width, active.Height);
        }

        return button;
    }

    public static StackPanel CreateImageTextContent(string buttonText, string imagePath, double width, double height, bool imageLeftAligned = true)
    {
        // Create a stack panel to hold text and image
        StackPanel contentStackPanel = new StackPanel();

        contentStackPanel.Width = width;
        contentStackPanel.Height = height;

        // Create text block
        TextBlock textBlock = new TextBlock
        {
            Text = buttonText,
            HorizontalAlignment = HorizontalAlignment.Center,
            Margin = new Thickness(0, 0, 0, 5) // Optional margin to separate text and image
        };

        // Add text and image to the stack panel
        if (string.IsNullOrWhiteSpace(imagePath))
        {
            contentStackPanel.Children.Add(textBlock);
        }
        else
        {
            // Create image
            Image image = new Image
            {
                Source = new BitmapImage(new Uri(imagePath, UriKind.RelativeOrAbsolute)),
            };

            if (imageLeftAligned)
            {
                contentStackPanel.Children.Add(image);
                contentStackPanel.Children.Add(textBlock);
            }
            else
            {
                contentStackPanel.Children.Add(textBlock);
                contentStackPanel.Children.Add(image);
            }
        }

        return contentStackPanel;
    }

    public static void SwitchState(Window winObject, bool minimise = false)
    {
        switch (winObject.WindowState)
        {
            case WindowState.Normal:
            {
                winObject.WindowState = minimise ? WindowState.Minimized : WindowState.Maximized;
                break;
            }
            default:
            {
                winObject.WindowState = WindowState.Normal;
                break;
            }
        }
    }
}