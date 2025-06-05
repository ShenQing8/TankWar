using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameDataManager
{
    private static GameDataManager datamag = new();
    public static GameDataManager Instance { get => datamag; }

    #region  游戏内数据
    // 音乐数据
    public MusicData msdata;
    // 排行榜数据
    public RankData[] rkdata;
    public int rknum = -1;
    #endregion

    public GameDataManager()
    {
        // 初始化音乐数据
        msdata = PlayerprefsManager.Instance.LoadData<MusicData>("Music");
        if (!msdata.IsNotFirst)
        {
            msdata.IsNotFirst = true;
            msdata.IsSoundOn = true;
            msdata.IsSoundEffectOn = true;
            msdata.SoundValue = 5;
            msdata.SoundEffeftValue = 5;
            PlayerprefsManager.Instance.SaveDate(msdata, "Music");
        }

        // 初始化排行榜数据
        rkdata = new RankData[10];
        for (int i = 0; i < 10; ++i)
        {
            rkdata[i] = PlayerprefsManager.Instance.LoadData<RankData>($"Player{i}");
            if (rkdata[i].PlayerName != "")
                ++rknum;
        }
    }

    private int BinSearch(int sc)
    {
        int l = 0;
        int r = rknum;
        int mid;
        while (l <= r)
        {
            mid = l + (r - l) / 2;
            if (rkdata[mid].Score > sc)
                l = mid + 1;
            else
                r = mid - 1;
        }
        return l;
    }

    public void AddRankData(string nm, int sc, int tm)
    {
        int idx = BinSearch(sc);

        if (rknum < 9)
            ++rknum;

        for (int i = rknum; i > idx; --i)
        {
            rkdata[i] = rkdata[i - 1];
            PlayerprefsManager.Instance.SaveDate(rkdata[i], $"Player{i}");
        }
        rkdata[idx] = new RankData(nm, sc, tm);
        PlayerprefsManager.Instance.SaveDate(rkdata[idx], $"Player{idx}");
    }

    public void SoundSwitch(bool ison)
    {
        msdata.IsSoundOn = ison;
        PlayerprefsManager.Instance.SaveDate(msdata, "Music");
    }

    public void SoundEffectSwitch(bool ison)
    {
        msdata.IsSoundEffectOn = ison;
        PlayerprefsManager.Instance.SaveDate(msdata, "Music");
    }

    public void SoundChange(int value)
    {
        msdata.SoundValue = value;
        PlayerprefsManager.Instance.SaveDate(msdata, "Music");
    }

    public void SoundEffectChange(int value)
    {
        msdata.SoundEffeftValue = value;
        PlayerprefsManager.Instance.SaveDate(msdata, "Music");
    }
    
}
