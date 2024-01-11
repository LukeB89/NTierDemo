using FontAwesome.Sharp;
using System.Windows;

namespace NTierDemo.BusinessLogic;
public abstract class ControlBarBase
{
    public List<object> FillButton(IconChar Icon)
    {
        List<object> root = new();

        ButtonData button = new();

        button.IconStyle = "ctrlBarButtonIcon";
        button.IconName = (int)Icon;
        root.Add(button);

        return root;
    }
}
