using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LablePre : Father
{
    protected override void DrawSystemmStyle()
    {
        GUI.Label(guipos.Pos, content);
    }

    protected override void DrawSelfStyle()
    {
        GUI.Label(guipos.Pos, content, SelfStyle);
    }
}
