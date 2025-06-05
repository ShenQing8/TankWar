using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BeginPanel : BasePanel<BeginPanel>
{
    public ButtonPre GameBtn;
    public ButtonPre SettingBtn;
    public ButtonPre QuitBtn;
    public ButtonPre RankBtn;

    private void Start()
    {
        // 锁定光标
        Cursor.lockState = CursorLockMode.Confined;
        
        GameBtn.ClickEvent += () =>
        {
            // 切换开始场景
            SceneManager.LoadScene(1);
        };
        SettingBtn.ClickEvent += () =>
        {
            // 打开设置面板，并关闭开始面板
            HideMe();
            SettingPanel.Instance.ShowMe();
        };
        QuitBtn.ClickEvent += () =>
        {
            // 退出游戏
            Application.Quit();
        };
        RankBtn.ClickEvent += () =>
        {
            // 打开排行榜面板，并关闭开始面板
            HideMe();
            RankPanel.Instance.ShowMe();
        };
    }
}
