using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vectory : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // 时停
            Time.timeScale = 0;
            // 开启结束界面
            GameUI.Instance.HideMe();
            VectoryPanel.Instance.ShowMe();
        }
    }
}
