using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Principal;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.SocialPlatforms.Impl;

public class RankPanel : BasePanel<RankPanel>
{
    // 返回按钮
    public ButtonPre BackBtn;
    // 玩家名信息
    public LablePre[] PlayerNames = new LablePre[10];
    // 得分信息
    public LablePre[] Scores = new LablePre[10];
    // 用时信息
    public LablePre[] TimeCsm = new LablePre[10];

    private void Start()
    {
        BackBtn.ClickEvent += () =>
        {
            HideMe();
            BeginPanel.Instance.ShowMe();
        };

        for (int i = 0; i < 10; ++i)
        {
            PlayerNames[i] = transform.Find($"name/B ({i})").GetComponent<LablePre>();
            Scores[i] = transform.Find($"score/C ({i})").GetComponent<LablePre>();
            TimeCsm[i] = transform.Find($"time/D ({i})").GetComponent<LablePre>();
        }

        HideMe();
    }

    private void UpdateData()
    {
        RankData tmp;
        int num = GameDataManager.Instance.rknum + 1;
        int tm;
        for (int i = 0; i < num; ++i)
        {
            tmp = GameDataManager.Instance.rkdata[i];
            tm = tmp.TimeCsm;

            PlayerNames[i].content.text = tmp.PlayerName;
            Scores[i].content.text = $"{tmp.Score}";
            TimeCsm[i].content.text = "";
            if (tm >= 3600)
                TimeCsm[i].content.text += $"{tm / 3600}时";
            if (tm >= 60)
                TimeCsm[i].content.text += $"{tm % 3600 / 60}分";
            TimeCsm[i].content.text += $"{tm % 3600 % 60}秒";
        }
    }

    public override void ShowMe()
    {
        // // 测试添加用代码
        // if (GameDataManager.Instance.rknum == 10)
        // {
        //     GameDataManager.Instance.AddRankData("金角大王", 999, 3698);
        //     print("添加金角大王");
        // }
        // else
        // {
        //     GameDataManager.Instance.AddRankData("银角大王", 888, 3698);
        //     print(GameDataManager.Instance.rknum);
        // }
        UpdateData();
        base.ShowMe();
    }
}
