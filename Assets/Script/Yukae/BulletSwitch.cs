using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum BulletType { Nomal, Burn, Lightning, Freezing, Air, Water, None }

public enum BulletName { Nomal, Burn, Lightning, Freezing, Air, Water, None }

public class BulletSwitch : MonoBehaviour
{
    [SerializeField] Bullet[] bullets;
    public BulletName BulletName;

    Bullet currentBullet;
    Bullet previousBullet;

    [SerializeField] Image bulletIcon;
    [SerializeField] Sprite[] icons;
    [SerializeField] Vector2[] sizes;

    public void SwitchingBullet(BulletType bulletType)
    {
        if (bullets[(int)bulletType] == null) return;

        if (currentBullet != null) previousBullet = currentBullet;

        currentBullet = bullets[(int)bulletType];

        if (currentBullet == previousBullet) return;

        bulletIcon.sprite = icons[(int)BulletName];
        bulletIcon.rectTransform.sizeDelta = sizes[(int)BulletName];

        Cursor.lockState = CursorLockMode.Locked;
    }
}
