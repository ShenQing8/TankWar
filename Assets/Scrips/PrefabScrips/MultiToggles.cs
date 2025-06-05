using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class MultiToggles : Father
{
    public bool IsOn = true;
    public bool IsOldChose = true;

    public event UnityAction<bool> IstrueToDoEvent;

    protected override void DrawSystemmStyle()
    {
        IsOn = GUI.Toggle(guipos.Pos, IsOn, content);
        if (IsOldChose != IsOn)
        {
            IstrueToDoEvent?.Invoke(IsOn);
            IsOldChose = IsOn;
        }
    }

    protected override void DrawSelfStyle()
    {
        IsOn = GUI.Toggle(guipos.Pos, IsOn, content, SelfStyle);
        if (IsOldChose != IsOn)
        {
            IstrueToDoEvent?.Invoke(IsOn);
            IsOldChose = IsOn;
        }
    }
}
