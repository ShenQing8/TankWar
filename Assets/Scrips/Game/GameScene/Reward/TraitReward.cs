using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum E_RWtype
{
    atk,
    def,
    addHp,
    maxHp
}

public class TraitReward : MonoBehaviour
{
    // 奖励种类
    public E_RWtype RW;
    // 改变的数值大小
    public int hp = 10;
    public int atk = 5;
    public int def = 5;
    // 被拾取时触发的特效
    public GameObject Eff;
    // 玩家身上挂载的玩家脚本
    PlayerObj player;

    private void OnTriggerEnter(Collider other)
    {
        // 如果碰到的是玩家
        if (other.CompareTag("Player"))
        {
            player = other.GetComponent<PlayerObj>();
            switch (RW)
            {
                case E_RWtype.addHp:
                    player.hp += hp;
                    if (player.hp > player.max_hp)
                        player.hp = player.max_hp;
                    // 改变UI显示的HP
                    GameUI.Instance.ChangeHP(player.hp, player.max_hp);
                    break;
                case E_RWtype.maxHp:
                    player.hp = player.max_hp;
                    // 改变UI显示的HP
                    GameUI.Instance.ChangeHP(player.hp, player.max_hp);
                    break;
                case E_RWtype.atk:
                    player.atk += atk;
                    break;
                case E_RWtype.def:
                    player.def += def;
                    break;
            }
            // 触发特效
            Instantiate(Eff, transform.position, transform.rotation);
            // 销毁自己
            Destroy(gameObject);
        }
    }
}
