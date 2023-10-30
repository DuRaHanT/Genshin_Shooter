using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class BulletSwitch : MonoBehaviour
{
    [SerializeField] Button[] bulletAbilityButton;
    public MainWeapon mainWeapon;
    [SerializeField] Image imageBulletIcon;
    [SerializeField] Sprite[] spriteBulletIcon;
    [SerializeField] TextMeshProUGUI bulletText;
    [SerializeField] InventoryMainWeapon inventoryMainWeapon;

    void Awake()
    {
        mainWeapon.BulletType = BulletType.Nomal;
        Setting(mainWeapon.BulletType);
    }

    public void BulletChange(string buttonName)
    {
        if (buttonName == BulletType.Nomal.ToString())
        {
            mainWeapon.BulletType = BulletType.Nomal;
            Setting(mainWeapon.BulletType);
        }
        else if (buttonName == BulletType.Burn.ToString())
        {
            mainWeapon.BulletType = BulletType.Burn;
            Setting(mainWeapon.BulletType);
        }
        else if (buttonName == BulletType.Lightning.ToString())
        {
            mainWeapon.BulletType = BulletType.Lightning;
            Setting(mainWeapon.BulletType);
        }
        else if (buttonName == BulletType.Freezing.ToString())
        {
            mainWeapon.BulletType = BulletType.Freezing;
            Setting(mainWeapon.BulletType);
        }
        inventoryMainWeapon.ViewInventory();
        bulletText.text = $"<size=40>{mainWeapon.bulletSetting.currentBullet}/</size>{mainWeapon.bulletSetting.possessionBullet}";
    }

    void Setting(BulletType type)
    {
        imageBulletIcon.sprite = spriteBulletIcon[(int)type];
        mainWeapon.bulletSetting.bulletDamage = bulletAbilityButton[(int)type].GetComponent<Bullet>().bulletSetting.bulletDamage;
        mainWeapon.bulletSetting.currentBullet = bulletAbilityButton[(int)type].GetComponent<Bullet>().bulletSetting.currentBullet;
        mainWeapon.bulletSetting.possessionBullet = bulletAbilityButton[(int)type].GetComponent<Bullet>().bulletSetting.possessionBullet;
        mainWeapon.bulletSetting.maxBullet = bulletAbilityButton[(int)type].GetComponent<Bullet>().bulletSetting.maxBullet;
    }

    public void IncreasespossessionAmmo(BulletType type, int bullet)
    {
        bulletAbilityButton[(int)type].GetComponent<Bullet>().IncreaseMaxAmmo(bullet);
        mainWeapon.bulletSetting.currentBullet = bulletAbilityButton[(int)type].GetComponent<Bullet>().bulletSetting.currentBullet;
        mainWeapon.bulletSetting.possessionBullet = bulletAbilityButton[(int)type].GetComponent<Bullet>().bulletSetting.possessionBullet;
    }
}
