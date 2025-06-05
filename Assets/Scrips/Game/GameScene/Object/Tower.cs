using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : TankBaseObj
{
    // 子弹预设体
    public GameObject bullet;
    // 开火点
    public Transform[] firepos;
    // 间隔开火
    public float fire_time = 1;
    float now_time = 0;

    private void Update()
    {
        now_time += Time.deltaTime;
        if (now_time > fire_time)
        {
            // 开火
            Fire();
            // 置零
            now_time = 0;
        }
        
    }

    public override void Fire()
    {
        for (int i = 0; i < firepos.Length; ++i)
        {
            // 发射子弹，并将子弹的发射者设为自己
            Instantiate(bullet, firepos[i].position, firepos[i].rotation).GetComponent<BulletObj>().SetMaster(this);
        }
    }


    // 塔类不能受伤，重写Wound函数，不是现任和逻辑
    public override void Wound(TankBaseObj other)
    {

    }
}
