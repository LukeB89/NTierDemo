using System;
using System.Security.Policy;
using System.Windows;
using NTierDemo.Presentation;

namespace NTierDemo.Entry;

public class BaseApp : Application
{
    [STAThread]
    public static void Main()
    {
        BaseApp app = new();
        app.Resources = LoadResourceDictionaries();
        app.Run(new MainWindow());
    }

    /// <summary>
    /// Add all resource dictionaries to the application
    /// </summary>
    /// <returns></returns>
    private static ResourceDictionary LoadResourceDictionaries()
    {
        // Color Resources
        ResourceDictionary uiColorsDictionary = new();
        uiColorsDictionary.Source = new Uri("/NTierDemo.Presentation;component/Styles/UIColors.xaml", UriKind.RelativeOrAbsolute);

        // Button Resources
        ResourceDictionary uiButtonsDictionary = new();
        uiButtonsDictionary.Source = new Uri("/NTierDemo.Presentation;component/Styles/ButtonStyles.xaml", UriKind.RelativeOrAbsolute);

        // Merge the dictionaries
        ResourceDictionary appResources = new();
        appResources.MergedDictionaries.Add(uiColorsDictionary);
        appResources.MergedDictionaries.Add(uiButtonsDictionary);

        return appResources;
    }
}
