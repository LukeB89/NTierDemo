using FontAwesome.Sharp;

namespace NTierDemo.BusinessLogic;
public abstract class SideBarBase
{
    public List<object> FillRadioButton(string Name, IconChar Icon)
    {
        List<object> root = new();

        RadioButtonData radioButton = new();

        radioButton.Content = Name;
        radioButton.Style = "menuButtonText";
        radioButton.IsChecked = Name.Equals("ToDo", StringComparison.OrdinalIgnoreCase);
        radioButton.IconStyle = "menuButtonIcon";
        radioButton.IconName = (int)Icon;
        root.Add(radioButton);

        return root;
    }
}
