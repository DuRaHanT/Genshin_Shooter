using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



public class BulletSwitch : BulletBase
{
    Bullet currentBullet;
    Bullet previousBullet;

    [SerializeField] Image bulletIcon;
    [SerializeField] Sprite[] icons;
    [SerializeField] Vector2[] sizes;

    //public void SwitchingBullet(BulletType bulletType)
    //{
    //    if (bullets[(int)bulletType] == null) return;

    //    if (currentBullet != null) previousBullet = currentBullet;

    //    currentBullet = bullets[(int)bulletType];

    //    if (currentBullet == previousBullet) return;

    //    bulletIcon.sprite = icons[(int)BulletName];
    //    bulletIcon.rectTransform.sizeDelta = sizes[(int)BulletName];

    //    Cursor.lockState = CursorLockMode.Locked;
    //}
}
