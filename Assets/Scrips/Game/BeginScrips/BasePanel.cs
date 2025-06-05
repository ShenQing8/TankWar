using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasePanel<T> : MonoBehaviour where T : class
{
    // 单例模式
    private static T instance;

    public static T Instance => instance;


    private void Awake()
    {
        instance = this as T;
    }

    public virtual void ShowMe()
    {
        gameObject.SetActive(true);
    }
    public virtual void HideMe()
    {
        gameObject.SetActive(false);
    }
}
