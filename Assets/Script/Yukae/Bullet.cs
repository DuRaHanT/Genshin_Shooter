using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : BulletBase
{
    public virtual void IncreaseMaxAmmo(int Ammo)
    {
        bulletSetting.possessionBullet = bulletSetting.currentBullet + Ammo > bulletSetting.maxBullet ? bulletSetting.maxBullet : bulletSetting.possessionBullet + Ammo;

        onBulletEvent.Invoke(bulletSetting.currentBullet, bulletSetting.possessionBullet);
    }
}
