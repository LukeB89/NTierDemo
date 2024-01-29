using NTierDemo.BusinessLogic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace NTierDemo.Presentation;
public class Calculator : IScreenBuilder
{
    public List<Active> Actives { get; } = new();

    public Calculator()
    {
        Active active = new();
        active.ControlType = typeof(Button);
        active.Content = "Calculator Button";
        active.Width = 100;
        active.Height = 100;
        Actives.Add(active);
    }

}
