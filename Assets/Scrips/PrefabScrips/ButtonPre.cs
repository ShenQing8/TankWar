using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ButtonPre : Father
{
    /// <summary>
    ///  用于用户自定义添加脚本，当按钮被点击时执行事件
    /// </summary>
    public event UnityAction ClickEvent;

    protected override void DrawSystemmStyle()
    {
        if (GUI.Button(guipos.Pos, content))
        {
            ClickEvent?.Invoke();
        }
    }

    protected override void DrawSelfStyle()
    {
        if (GUI.Button(guipos.Pos, content, SelfStyle))
        {
            ClickEvent?.Invoke();
        }
    }
}
