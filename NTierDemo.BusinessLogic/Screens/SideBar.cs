
namespace NTierDemo.BusinessLogic;
public abstract class SideBarBase
{
    public List<object> FillRadioButton(string Name, int Icon)
    {
        List<object> root = new();

        RadioButtonData radioButton = new();

        radioButton.Content = Name;
        radioButton.Style = "menuButtonText";
        radioButton.IsChecked = Name.Equals("ToDo", StringComparison.OrdinalIgnoreCase);
        radioButton.IconStyle = "menuButtonIcon";
        radioButton.IconName = Icon;
        root.Add(radioButton);

        return root;
    }
}
