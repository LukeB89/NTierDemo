
namespace NTierDemo.BusinessLogic;
public abstract class ControlBarBase
{
    public List<object> FillButton(int Icon)
    {
        List<object> root = new();

        ButtonData button = new();

        button.IconStyle = "ctrlBarButtonIcon";
        button.IconName = Icon;
        root.Add(button);

        return root;
    }
}
