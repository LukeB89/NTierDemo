using NTierDemo.BusinessLogic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace NTierDemo.Presentation
{
    class ToDoContent : ToDoContentBase, IScreenBuilder
    {

        public List<Active> Actives { get; } = new();

        public ToDoContent()
        {
            Active active = new();
            active.ControlType = typeof(ToDoCard);
            active.Width = double.NaN;
            active.Height = double.NaN;
            active.Fill += (arg) => GetToDoCardData();
            Actives.Add(active);
        }

    }
}
