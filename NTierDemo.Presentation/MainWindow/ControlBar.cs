using FontAwesome.Sharp;
using NTierDemo.BusinessLogic;
using System.Collections.Generic;
using System.Windows.Controls;

namespace NTierDemo.Presentation;

public class ControlBar : ControlBarBase, IScreenBuilder
{
    public List<Active> Actives { get; } = new();

    public ControlBar()
    {
        Active active = new();
        active.ControlType = typeof(Button);
        active.Name = "ctrlBarClose";
        active.Style = "ctrlBarButton";
        active.Tag = "C_Pallet4";
        active.Click += WindowLogic.Handle_ControlBar_ButtonClose;
        active.Fill += (arg) => FillButton(IconChar.Xmark);
        Actives.Add(active);

        active = new();
        active.ControlType = typeof(Button);
        active.Name = "ctrlBarMaximise";
        active.Style = "ctrlBarButton";
        active.Tag = "C_Pallet6";
        active.Click += WindowLogic.Handle_ControlBar_ButtonMaximise;
        active.Fill += (arg) => FillButton(IconChar.WindowMaximize);
        Actives.Add(active);

        active = new();
        active.ControlType = typeof(Button);
        active.Name = "ctrlBarMinimise";
        active.Style = "ctrlBarButton";
        active.Tag = "C_Pallet8";
        active.Click += WindowLogic.Handle_ControlBar_ButtonMinimise;
        active.Fill += (arg) => FillButton(IconChar.WindowMinimize);
        Actives.Add(active);
    }
}
