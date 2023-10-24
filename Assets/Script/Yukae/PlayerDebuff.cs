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
                debuffSetting.isBurn = true;
                break;
            case BulletType.Lightning:
                debuffSetting.isLightning = true;
                break;
            case BulletType.Freezing:
                debuffSetting.isFreezing = true;
                break;
        }
    }

    void GrenadeTypeCheck()
    {
        switch(weaponGrenade.mainGrenadeType.grenadeType)
        {
            case GrenadeType.None:

                break;
            case GrenadeType.Air:
                debuffSetting.isAur = true;
                break;
            case GrenadeType.Water:
                debuffSetting.isAur = true;
                break;
        }
    }
}
