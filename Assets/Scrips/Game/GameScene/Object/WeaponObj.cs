using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponObj : MonoBehaviour
{
    // 子弹
    public GameObject bullet;
    // 炮口
    public Transform[] weapons;
    // 父物体，即炮身
    public TankBaseObj master;


    // 设置依附的坦克物体
    public void SetMaster(TankBaseObj mt)
    {
        master = mt;
    }

    // 开火
    public void Fire()
    {
        // 在所有炮口出生成子弹
        for (int i = 0; i < weapons.Length; ++i)
        {
            // 生成子弹，设置子弹的依附对象
            Instantiate(bullet, weapons[i].position, weapons[i].rotation).GetComponent<BulletObj>().SetMaster(master);
        }
    }
}
