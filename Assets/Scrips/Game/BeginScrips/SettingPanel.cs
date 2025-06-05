using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SettingPanel : BasePanel<SettingPanel>
{
    public ButtonPre BackBtn;

    public Slider SoundSld;
    public Slider SoundEffectSld;

    public MultiToggles SoundTg;
    public MultiToggles SoundEffectTg;

    int NowScene;

    private void Start()
    {
        // 获取当前场景得下标，0为开始场景，1为游戏场景
        NowScene = SceneManager.GetActiveScene().buildIndex;
        
        BackBtn.ClickEvent += () =>
        {
            // 关闭设置面板，并打开开始面板
            HideMe();
            // 游戏场景代码为0，显示开始界面；为1，显示游戏UI界面
            if (NowScene == 0)
                BeginPanel.Instance.ShowMe();
            else if (NowScene == 1)
                GameUI.Instance.ShowMe();
        };
        SoundSld.ChangeEvent += (value) =>
        {
            // 音量改变时逻辑

            // 改变音量
            BKMusic.Instance.ChangeMusicVol(value);
            // 保存改变的值
            GameDataManager.Instance.SoundChange(value);
        };
        SoundEffectSld.ChangeEvent += (value) =>
        {
            // 音效改变时逻辑

            GameDataManager.Instance.SoundEffectChange(value);
        };
        SoundTg.IstrueToDoEvent += (value) =>
        {
            // 音量选择按钮改变时逻辑

            // 改变
            BKMusic.Instance.IsMusicOn(value);
            // 保存
            GameDataManager.Instance.SoundSwitch(value);
        };
        SoundEffectTg.IstrueToDoEvent += (value) =>
        {
            // 音效选择按钮改变时逻辑

            GameDataManager.Instance.SoundEffectSwitch(value);
        };

        HideMe();
    }


    private void UpdateData()
    {
        SoundTg.IsOn = GameDataManager.Instance.msdata.IsSoundOn;
        SoundEffectTg.IsOn = GameDataManager.Instance.msdata.IsSoundEffectOn;
        SoundEffectSld.CurNum = GameDataManager.Instance.msdata.SoundEffeftValue;
        SoundSld.CurNum = GameDataManager.Instance.msdata.SoundValue;
    }

    public override void ShowMe()
    {
        base.ShowMe();
        UpdateData();
    }
}
