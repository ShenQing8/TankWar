using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeltaDestory : MonoBehaviour
{
    AudioSource ads;

    private void Start()
    {
        // 设置音效信息
        ads = GetComponent<AudioSource>();
        if (ads != null)
        {
            ads.mute = !GameDataManager.Instance.msdata.IsSoundEffectOn;
            ads.volume = (float)GameDataManager.Instance.msdata.SoundEffeftValue / 10;            
        }

        // 1.5秒后消失
        Destroy(gameObject, 1.5f);
    }
}
