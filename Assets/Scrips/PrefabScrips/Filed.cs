using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum E_FiledMode
{
    Text,
    Password
}

public class Filed : Father
{
    public E_FiledMode Filedmode = E_FiledMode.Text;

    [HideInInspector]
    public string input = "";

    protected override void DrawSelfStyle()
    {
        switch (Filedmode)
        {
            case E_FiledMode.Text:
                input = GUI.TextField(guipos.Pos, input, SelfStyle);
                break;
            case E_FiledMode.Password:
                input = GUI.PasswordField(guipos.Pos, input, '*', SelfStyle);
                break;
        }
    }

    protected override void DrawSystemmStyle()
    {
        switch (Filedmode)
        {
            case E_FiledMode.Text:
                input = GUI.TextField(guipos.Pos, input);
                break;
            case E_FiledMode.Password:
                input = GUI.PasswordField(guipos.Pos, input, '*');
                break;
        }
    }
}
