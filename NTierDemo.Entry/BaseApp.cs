using System;
using System.Windows;

namespace NTierDemo.Presentation;

public class BaseApp : Application
{
    [STAThread]
    public static void Main()
    {
        BaseApp app = new();
        app.Run(new MainWindow());
    }
}
