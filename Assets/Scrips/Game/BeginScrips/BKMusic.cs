using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BKMusic : MonoBehaviour
{
    private static BKMusic instance;

    public static BKMusic Instance => instance;

    // 得到自身挂载的音乐脚本
    public AudioSource ads;

    private void Awake()
    {
        instance = this;
        // 得到自身挂载的音乐脚本
        ads = transform.GetComponent<AudioSource>();
    }
    void Start()
    {
        // 设置音乐信息初始值
        ads.mute = !GameDataManager.Instance.msdata.IsSoundOn;
        ads.volume = (float)GameDataManager.Instance.msdata.SoundValue / 10;
    }

    // 控制音乐开关
    public void IsMusicOn(bool isopen)
    {
        ads.mute = !isopen;
    }

    // 改变音乐音量大小
    public void ChangeMusicVol(float value)
    {
        ads.volume = value / 10;
    }
}
