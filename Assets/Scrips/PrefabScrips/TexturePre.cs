using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TexturePre : Father
{
    public ScaleMode scaleMode = ScaleMode.ScaleToFit;
    public bool alpha = true;
    protected override void DrawSelfStyle()
    {
        GUI.DrawTexture(guipos.Pos, content.image, scaleMode, alpha);
    }

    protected override void DrawSystemmStyle()
    {
        GUI.DrawTexture(guipos.Pos, content.image, scaleMode, alpha);
    }
}
