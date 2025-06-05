using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*对齐方式枚举*/
public enum E_JustifyMode
{
    /// <summary>
    /// 左上
    /// </summary>
    LeftUp,
    /// <summary>
    /// 上
    /// </summary>
    Up,
    /// <summary>
    /// 右上
    /// </summary>
    RightUp,
    /// <summary>
    /// 左
    /// </summary>
    Left,
    /// <summary>
    /// 中心
    /// </summary>
    Center,
    /// <summary>
    /// 右
    /// </summary>
    Right,
    /// <summary>
    /// 左下
    /// </summary>
    LeftDown,
    /// <summary>
    /// 下
    /// </summary>
    Down,
    /// <summary>
    /// 右下
    /// </summary>
    RightDown
}

[System.Serializable]
public class GUIPos
{
    Rect pos = new Rect(0, 0, 0, 0);
    /*屏幕的长宽*/
    float screen_width = Screen.width;
    float screen_height = Screen.height;

    /*偏移量*/
    public float x = 0;
    public float y = 0;

    /*缩放大小*/
    public float width = 100;
    public float height = 100;

    /*相对屏幕位置*/
    public E_JustifyMode PosOfScreen = E_JustifyMode.Center;

    /*对齐方式*/
    public E_JustifyMode Alignment = E_JustifyMode.Center;

    private void Compute_posofscreen()
    {
        screen_width = Screen.width;
        screen_height = Screen.height;

        switch (PosOfScreen)
        {
            case E_JustifyMode.Center:
                pos.x = screen_width / 2;
                pos.y = screen_height / 2;
                break;
            case E_JustifyMode.Down:
                pos.x = screen_width / 2;
                pos.y = screen_height;
                break;
            case E_JustifyMode.Left:
                pos.x = 0;
                pos.y = screen_height / 2;
                break;
            case E_JustifyMode.LeftDown:
                pos.x = 0;
                pos.y = screen_height;
                break;
            case E_JustifyMode.LeftUp:
                pos.x = 0;
                pos.y = 0;
                break;
            case E_JustifyMode.Right:
                pos.x = screen_width;
                pos.y = screen_height / 2;
                break;
            case E_JustifyMode.RightDown:
                pos.x = screen_width;
                pos.y = screen_height;
                break;
            case E_JustifyMode.RightUp:
                pos.x = screen_width;
                pos.y = 0;
                break;
            case E_JustifyMode.Up:
                pos.x = screen_width / 2;
                pos.y = 0;
                break;
        }
    }

    private void Compute_alignment()
    {
        switch (Alignment)
        {
            case E_JustifyMode.Center:
                pos.x -= width / 2;
                pos.y -= height / 2;
                break;
            case E_JustifyMode.Down:
                pos.x -= width / 2;
                pos.y -= height;
                break;
            case E_JustifyMode.Left:
                pos.y -= height / 2;
                break;
            case E_JustifyMode.LeftDown:
                pos.y -= height;
                break;
            case E_JustifyMode.LeftUp:

                break;
            case E_JustifyMode.Right:
                pos.x -= width;
                pos.y -= height / 2;
                break;
            case E_JustifyMode.RightDown:
                pos.x -= width;
                pos.y -= height;
                break;
            case E_JustifyMode.RightUp:
                pos.x -= width;
                break;
            case E_JustifyMode.Up:
                pos.x -= width / 2;
                break;
        }
    }

    public Rect Pos
    {
        get
        {
            // 位置 = 相对屏幕位置 + 对齐方式 + 偏移量

            // 计算相对屏幕位置
            Compute_posofscreen();
            // 计算对齐方式
            Compute_alignment();
            // 计算偏移量
            pos.x += x;
            pos.y += y;
            // 更改大小
            pos.width = width;
            pos.height = height;

            return pos;
        }
    }
}
