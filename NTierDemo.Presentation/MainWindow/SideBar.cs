using NTierDemo.BusinessLogic;
using System.Collections.Generic;
using System.Windows.Controls;
using FontAwesome.Sharp;
using System;

namespace NTierDemo.Presentation;
public class SideBar : SideBarBase, IScreenBuilder
{
    public List<Active> Actives { get; } = new();

    public SideBar()
    {
        Active active = new();
        active.ControlType = typeof(RadioButton);
        active.Style = "menuButton";
        active.Tag = "C_Pallet1";
        active.Click += () => WindowLogic.OpenScreen(Enums.ScreenNames.ToDo);
        active.Fill += (arg) => FillRadioButton("ToDo", IconChar.ListCheck);
        Actives.Add(active);

        active = new();
        active.ControlType = typeof(RadioButton);
        active.Style = "menuButton";
        active.Tag = "C_Pallet2";
        active.Click += () => WindowLogic.OpenScreen(Enums.ScreenNames.Calculator);
        active.Fill += (arg) => FillRadioButton("Calculator", IconChar.Calculator);
        Actives.Add(active);

        active = new();
        active.ControlType = typeof(RadioButton);
        active.Style = "menuButton";
        active.Tag = "C_Pallet3";
        active.Click += () => WindowLogic.OpenScreen(Enums.ScreenNames.Calendar);
        active.Fill += (arg) => FillRadioButton("Calendar", IconChar.CalendarDays);
        Actives.Add(active);

        active = new();
        active.ControlType = typeof(RadioButton);
        active.Style = "menuButton";
        active.Tag = "C_Pallet4";
        active.Click += () => WindowLogic.OpenScreen(Enums.ScreenNames.Clock);
        active.Fill += (arg) => FillRadioButton("Clock", IconChar.Clock);
        Actives.Add(active);

        active = new();
        active.ControlType = typeof(RadioButton);
        active.Style = "menuButton";
        active.Tag = "C_Pallet5";
        active.Click += () => WindowLogic.OpenScreen(Enums.ScreenNames.Weather);
        active.Fill += (arg) => FillRadioButton("Weather", IconChar.CloudSun);
        Actives.Add(active);

    }

}
