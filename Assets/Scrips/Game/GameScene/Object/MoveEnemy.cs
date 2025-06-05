using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class MoveEnemy : TankBaseObj
{
    // 子弹预设体
    public GameObject bullet;

    // 炮口位置
    public Transform[] firepos;

    // 发射子弹时间间隔
    public float fire_time = 1;
    float now_time = 0;

    // 开火距离
    public float fire_dis = 5;

    // 坦克攻击目标
    public Transform player;

    // 可移动去向
    public Transform[] targets;
    int now_tar;

    // 血条显示位置
    Vector3 screenPos;
    Rect bkRect;
    Rect hpRect;
    // 血条显示比例
    float tx_scale;
    // 血条初始长宽
    int wid = 150;
    int ht = 20;
    // 血条图片
    public Texture hpbk;
    public Texture hppic;
    // 受伤时血条显示时间
    float show_hp = 0;


    private void Update()
    {
        // 坦克行进目标点
        transform.LookAt(targets[now_tar]);

        transform.Translate(Vector3.forward * move_sp * Time.deltaTime);
        if (Vector3.Distance(transform.position, targets[now_tar].position) < 0.1)
        {
            // 改变目标点
            now_tar = Random.Range(0, targets.Length);
        }

        // 攻击目标靠近
        if (Vector3.Distance(transform.position, player.position) < fire_dis)
        {
            // 坦克看向攻击目标
            paotai.transform.LookAt(player);

            // 静止不动
            move_sp = 0;

            // 累加时间，开火
            now_time += Time.deltaTime;
            if (now_time > fire_time)
            {
                Fire();
                now_time = 0;
            }
        }
        else
        {
            move_sp = 10;
        }
    }

    // 绘制血条逻辑
    private void OnGUI()
    {
        if (show_hp > 0)
        {
            screenPos = Camera.main.WorldToScreenPoint(transform.position);

            tx_scale = 10.0f / screenPos.z;

            // 绘制背景图
            bkRect.x = screenPos.x - 50;
            bkRect.y = Screen.height - screenPos.y - 80;
            bkRect.width = wid * tx_scale;
            bkRect.height = ht * tx_scale;
            GUI.DrawTexture(bkRect, hpbk);

            // 绘制血条图
            hpRect.x = bkRect.x;
            hpRect.y = bkRect.y;
            // hpRect.width = (float)hp / max_hp * bkRect.width * tx_scale;
            hpRect.width = (float)hp / max_hp * bkRect.width * tx_scale;
            hpRect.height = bkRect.height;
            GUI.DrawTexture(hpRect, hppic);

            show_hp -= Time.deltaTime;
        }
    }

    public override void Wound(TankBaseObj other)
    {
        base.Wound(other);
        show_hp = 3;
    }


    public override void Fire()
    {
        for (int i = 0; i < firepos.Length; ++i)
        {
            Instantiate(bullet, firepos[i].position, firepos[i].rotation).GetComponent<BulletObj>().SetMaster(this);
        }
    }

    public override void Die()
    {
        // 加分
        GameUI.Instance.ChangeScore(max_hp);
        base.Die();
    }
}
