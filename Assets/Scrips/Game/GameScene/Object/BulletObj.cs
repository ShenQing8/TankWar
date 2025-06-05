using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class BulletObj : MonoBehaviour
{
    // 所依附得坦克
    public TankBaseObj master;
    // 子弹速度
    public int speed = 100;
    // 销毁时的特效
    public GameObject dstEff;
    // 挂载的音效组件
    AudioSource ads;



    // 设置依附的坦克物体
    public void SetMaster(TankBaseObj mt)
    {
        master = mt;
    }

    private void Start()
    {
        // 生成子弹时发出声音
        ads = GetComponent<AudioSource>();
        ads.mute = !GameDataManager.Instance.msdata.IsSoundEffectOn;
        ads.volume = (float)GameDataManager.Instance.msdata.SoundEffeftValue / 10;
    }

    private void Update()
    {
        // 向前移动
        transform.Translate(Vector3.forward * Time.deltaTime * speed);
    }

    // 判断是否碰到墙壁或地板
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Cube") ||
            master.CompareTag("Player") && other.CompareTag("Enemy") ||
            master.CompareTag("Enemy") && other.CompareTag("Player"))
        {
            // 受伤逻辑
            if (!other.CompareTag("Cube"))
                other.GetComponent<TankBaseObj>().Wound(master);
            // 播放销毁音效
            if (dstEff != null)
            {
                // 创建特效
                Instantiate(dstEff, transform.position, transform.rotation);
            }
            // 使自己消失
            Destroy(this.gameObject);
        }
    }
}
