using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public enum E_SliderMode
{
    Horizontal,
    Vertical
}

public class Slider : Father
{
    public E_SliderMode Slidermode = E_SliderMode.Horizontal;

    public int CurNum = 0;
    public float MinNum = 0;
    public float MaxNum = 10;
    public int OldNum = 0;

    public event UnityAction<int> ChangeEvent;

    public GUIStyle ThumbStyle;

    protected override void DrawSelfStyle()
    {
        switch (Slidermode)
        {
            case E_SliderMode.Horizontal:
                CurNum = (int)GUI.HorizontalSlider(guipos.Pos, CurNum, MinNum, MaxNum, SelfStyle, ThumbStyle);
                break;
            case E_SliderMode.Vertical:
                CurNum = (int)GUI.VerticalSlider(guipos.Pos, CurNum, MinNum, MaxNum, SelfStyle, ThumbStyle);
                break;
        }

        if (OldNum != CurNum)
        {
            ChangeEvent?.Invoke(CurNum);
            OldNum = CurNum;
        }
    }

    protected override void DrawSystemmStyle()
    {
        switch (Slidermode)
        {
            case E_SliderMode.Horizontal:
                CurNum = (int)GUI.HorizontalSlider(guipos.Pos, CurNum, MinNum, MaxNum);
                break;
            case E_SliderMode.Vertical:
                CurNum = (int)GUI.VerticalSlider(guipos.Pos, CurNum, MinNum, MaxNum);
                break;
        }

        if (OldNum != CurNum)
        {
            ChangeEvent?.Invoke(CurNum);
            OldNum = CurNum;
        }
    }
}
