using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDebuff : DebuffBase
{
    [SerializeField] WeaponAssaultRifle mainWeapon;
    [SerializeField] WeaponGrenade weaponGrenade;

    void MainWeaponTypeCheck()
    {
        switch(mainWeapon.mainWeapon.BulletType)
        {
            case BulletType.Nomal:
                break;
            case BulletType.Burn:
                break;
            case BulletType.Lightning:
                break;
            case BulletType.Freezing:
                break;
        }
    }
}
