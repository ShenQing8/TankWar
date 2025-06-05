using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RankData
{
    public string PlayerName;
    public int Score;
    public int TimeCsm;

    public RankData() { }
    public RankData(string nm, int sc, int tm)
    {
        PlayerName = nm;
        Score = sc;
        TimeCsm = tm;
    }
}
