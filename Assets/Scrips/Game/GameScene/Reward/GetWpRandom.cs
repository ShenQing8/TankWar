using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetWpRandom : MonoBehaviour
{
    // 所有能获得的武器数组
    public GameObject[] weapns;
    // 获得时的特效
    public GameObject getEff;

    private void OnTriggerEnter(Collider other)
    {
        // 如果是玩家
        if (other.CompareTag("Player"))
        {
            // 生成随机数，决定玩家获得哪款武器
            int index = Random.Range(0, weapns.Length);

            // 播放获取特效
            Instantiate(getEff, transform.position, transform.rotation);

            // 改变玩家的武器样式
            PlayerObj player = other.GetComponent<PlayerObj>();
            player.ChangeWeapon(weapns[index]);

            // 销毁自己
            Destroy(gameObject);
        }
    }
}
