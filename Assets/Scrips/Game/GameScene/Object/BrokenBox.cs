using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrokenBox : MonoBehaviour
{
    // 销毁特效
    public GameObject brokeEff;
    // 奖励数组
    public GameObject[] rewards;


    private void OnTriggerEnter(Collider other)
    {
        // 有50％的几率生成随机奖励
        int num = Random.Range(0, 100);
        int idx = Random.Range(0, rewards.Length);
        if (num < 50 && rewards[idx] != null)
            Instantiate(rewards[idx], transform.position, transform.rotation);

        // 创建销毁特效
        Instantiate(brokeEff, transform.position, transform.rotation);

        // 销毁自己
        Destroy(gameObject);
    }
}
