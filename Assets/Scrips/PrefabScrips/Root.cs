using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteAlways]
public class Root : MonoBehaviour
{
    Father[] children;
    int i = 0;


    private void Start()
    {
        children = GetComponentsInChildren<Father>();
    }

    private void OnGUI()
    {
        // 只在编辑模式下才持续获取子对象的 以Father为父类的 脚本
        // if (!Application.isPlaying)
        // {
        // }
        children = GetComponentsInChildren<Father>();

        for (i = 0; i < children.Length; ++i)
        {
            children[i].DrawGUI();
        }
    }
}
