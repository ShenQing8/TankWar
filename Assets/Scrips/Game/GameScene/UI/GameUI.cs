using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameUI : BasePanel<GameUI>
{
    public LablePre ScoreLab;
    public LablePre TimeLab;

    public TexturePre HP;
    public TexturePre HPback;

    public ButtonPre SettingBtn;
    public ButtonPre BackBtn;

    // 当前得分
    [HideInInspector]
    public int NowSc;
    // 用时
    [HideInInspector]
    public float tmCsm;

    private void Start()
    {
        SettingBtn.ClickEvent += () =>
        {
            // 设置面板
            HideMe();
            SettingPanel.Instance.ShowMe();
        };
        BackBtn.ClickEvent += () =>
        {
            // 回到主界面，给出是否要回到主界面的提示
            HideMe();
            BackPanel.Instance.ShowMe();
        };
    }

    // 时间变化，写在Update里面
    private void Update()
    {
        tmCsm += Time.deltaTime;
        TimeLab.content.text = "";

        if (tmCsm >= 3600)
            TimeLab.content.text += $"{(int)tmCsm / 3600}时";
        if (tmCsm >= 60)
            TimeLab.content.text += $"{(int)tmCsm % 3600 / 60}分";
        TimeLab.content.text += $"{(int)tmCsm % 3600 % 60}秒";
    }

    // 加分
    public void ChangeScore(int sc)
    {
        NowSc += sc;
        ScoreLab.content.text = $"{NowSc}";
    }

    // HP变化
    public void ChangeHP(int NowHp, int MaxHp)
    {
        HP.guipos.width = ((float)NowHp / MaxHp) * HPback.guipos.width;
    }
}
