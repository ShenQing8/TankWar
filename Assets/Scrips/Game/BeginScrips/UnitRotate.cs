using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitRotate : MonoBehaviour
{
    public float speed = 10;

    void Update()
    {
        transform.Rotate(Vector3.up, speed * Time.deltaTime);
    }
}
