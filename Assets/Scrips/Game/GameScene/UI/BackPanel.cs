using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BackPanel : BasePanel<BackPanel>
{
    public ButtonPre NotBack;
    public ButtonPre YesBack;

    private void Start()
    {
        // 取消返回
        NotBack.ClickEvent += () =>
        {
            HideMe();
            GameUI.Instance.ShowMe();
        };
        // 确认返回
        YesBack.ClickEvent += () =>
        {
            SceneManager.LoadScene(0);
        };

        HideMe();
    }
}
