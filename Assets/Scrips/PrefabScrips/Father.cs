using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum E_Style
{
    system,
    selfstyle
}

public abstract class Father : MonoBehaviour
{
    public GUIPos guipos;

    public E_Style style = E_Style.system;

    public GUIContent content;

    public GUIStyle SelfStyle;

    public void DrawGUI()
    {
        switch (style)
        {
            case E_Style.system:
                DrawSystemmStyle();
                break;
            case E_Style.selfstyle:
                DrawSelfStyle();
                break;
        }
    }

    protected abstract void DrawSystemmStyle();

    protected abstract void DrawSelfStyle();
}
