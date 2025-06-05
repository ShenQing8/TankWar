using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class VectoryPanel : BasePanel<VectoryPanel>
{
    public ButtonPre TrueBtn;
    public Filed fl;

    private void Start()
    {
        TrueBtn.ClickEvent += () =>
        {
            if (fl.input != "")
            {
                // 记录排名
                GameDataManager.Instance.AddRankData(fl.input, GameUI.Instance.NowSc, (int)GameUI.Instance.tmCsm);
                Time.timeScale = 1;
                // 返回主界面
                SceneManager.LoadScene(0);
            }
        };
        // 隐藏自己
        HideMe();
    }
}
