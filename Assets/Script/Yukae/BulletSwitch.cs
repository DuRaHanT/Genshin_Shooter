using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



public class BulletSwitch : BulletBase
{
    [SerializeField] Button[] bulletAbilityButton;
    MainWeapon mainWeapon;

    private void Awake()
    {
        mainWeapon = GetComponent<MainWeapon>();

        for (int i = 0; i < bulletAbilityButton.Length; i++) bulletAbilityButton[i].onClick.AddListener(() => BulletChange(bulletAbilityButton[i].gameObject.name));
    }

    void BulletChange(string buttonName)
    {
        if (buttonName == BulletType.Nomal.ToString()) mainWeapon.BulletType = BulletType.Nomal;
        else if (buttonName == BulletType.Burn.ToString()) mainWeapon.BulletType = BulletType.Burn;
        else if (buttonName == BulletType.Lightning.ToString()) mainWeapon.BulletType = BulletType.Lightning;
        else if (buttonName == BulletType.Freezing.ToString()) mainWeapon.BulletType = BulletType.Freezing;
    }
}
