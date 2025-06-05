using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerObj : TankBaseObj
{
    // 武器
    public WeaponObj weapon;

    // 武器父对象
    public Transform weapon_master;


    private void Start()
    {
        GameUI.Instance.ChangeHP(hp, max_hp);
    }

    private void Update()
    {
        // ws键，前进后退
        transform.Translate(Input.GetAxis("Vertical") * Vector3.forward * Time.deltaTime * move_sp);
        // ad键，左右旋转
        transform.Rotate(Input.GetAxis("Horizontal") * Vector3.up * Time.deltaTime * rotate_sp);
        // 鼠标左右移动，炮台旋转
        paotai.transform.Rotate(Input.GetAxis("Mouse X") * Vector3.up * Time.deltaTime * head_rotate_sp);
        // 鼠标左键，开火
        if (Input.GetMouseButtonDown(0))
        {
            Fire();
        }
    }

    // 重写开火逻辑
    public override void Fire()
    {
        // 开火
        weapon?.Fire();
    }

    public override void Wound(TankBaseObj other)
    {
        base.Wound(other);
        GameUI.Instance.ChangeHP(hp, max_hp);
    }

    public override void Die()
    {
        // 不能销毁玩家，因为摄像机在玩家身上
        Time.timeScale = 0;
        GameUI.Instance.HideMe();
        DefeatPanel.Instance.ShowMe();
    }

    // 改变武器
    public void ChangeWeapon(GameObject wp)
    {
        if (weapon != null)
        {
            Destroy(weapon.gameObject);
        }
        weapon = Instantiate(wp, weapon_master, false).GetComponent<WeaponObj>();
        // 设置武器的拥有者
        weapon.SetMaster(this);
    }
}
