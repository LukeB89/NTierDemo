using NTierDemo.BusinessLogic;
using System.Collections.Generic;
using System.Windows.Controls;

namespace NTierDemo.Presentation;
public class ToDo : ToDoBase, IScreenBuilder
{
    
    public List<Active> Actives { get; } = new();

    public ToDo()
    {
        Active active = new();
        active.ControlType = typeof(Grid);
        active.Width = double.NaN;
        active.Height = double.NaN;
        active.Fill += (arg) => FillGrid();
        Actives.Add(active);
    }

}
