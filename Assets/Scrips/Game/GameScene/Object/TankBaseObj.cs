using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class TankBaseObj : MonoBehaviour
{
    // 坦克攻击力、防御力、hp、最大hp
    public int atk;
    public int def;
    public int hp;
    public int max_hp;
    public GameObject DieEFF;

    // 数值相关：移动速度、旋转速度、炮台旋转速度
    public int move_sp = 100;
    public int rotate_sp = 10;
    public int head_rotate_sp = 10;

    // 自身炮台
    public GameObject paotai;

    /*共有行为*/
    /// <summary>
    /// 开火
    /// </summary>
    public abstract void Fire();

    /// <summary>
    /// 受伤
    /// </summary>
    /// <param name="other"></param>
    public virtual void Wound(TankBaseObj other)
    {
        int get_hurt = other.atk - def;
        // 受到伤害 <=0，直接返回
        if (get_hurt <= 0)
            return;
        // 受到伤害 >0，受伤逻辑判断
        else
        {
            hp -= get_hurt;
            // hp <= 0，死了
            if (hp <= 0)
            {
                hp = 0;
                Die();
            }
            // hp > 0，还活着
        }
    }

    /// <summary>
    /// 死亡
    /// </summary>
    public virtual void Die()
    {
        // 若死亡特效物体不为空，获取其身上挂载的音效组件
        if (DieEFF != null)
        {
            AudioSource adsc = Instantiate(DieEFF, transform.position, transform.rotation).GetComponent<AudioSource>();
            if (adsc != null)
            {
                // 初始化数据
                adsc.mute = !GameDataManager.Instance.msdata.IsSoundEffectOn;
                adsc.volume = (float)GameDataManager.Instance.msdata.SoundEffeftValue / 10;
                // 播放
                adsc.Play();
            }
        }
        Destroy(gameObject);
    }
}
