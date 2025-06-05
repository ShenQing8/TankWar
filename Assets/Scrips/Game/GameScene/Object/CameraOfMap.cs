using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraOfMap : MonoBehaviour
{
    // 所要跟随的目标
    public Transform target;
    // 更新相机位置所需的Vector3
    Vector3 pos;
    // 相机高度
    public float height = 18;


    private void LateUpdate()
    {
        if (target == null)
            return;

        pos.x = target.position.x;
        pos.z = target.position.z;
        pos.y = height;
        transform.position = pos;
    }
}
