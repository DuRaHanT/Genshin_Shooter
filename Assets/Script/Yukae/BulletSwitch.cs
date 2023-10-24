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

    public void BulletChange(string buttonName)
    {
        if (buttonName == BulletType.Nomal.ToString())
        {
            mainWeapon.BulletType = BulletType.Nomal;
            imageBulletIcon.sprite = spriteBulletIcon[(int)BulletType.Nomal];
            mainWeapon.bulletSetting.bulletDamage = bulletAbilityButton[(int)BulletType.Nomal].GetComponent<Bullet>().bulletSetting.bulletDamage;
            mainWeapon.bulletSetting.currentBullet = bulletAbilityButton[(int)BulletType.Nomal].GetComponent<Bullet>().bulletSetting.currentBullet;
            mainWeapon.bulletSetting.possessionBullet = bulletAbilityButton[(int)BulletType.Nomal].GetComponent<Bullet>().bulletSetting.possessionBullet;
        }
        else if (buttonName == BulletType.Burn.ToString())
        {
            mainWeapon.BulletType = BulletType.Burn;
            imageBulletIcon.sprite = spriteBulletIcon[(int)BulletType.Burn];
            mainWeapon.bulletSetting.bulletDamage = bulletAbilityButton[(int)BulletType.Burn].GetComponent<Bullet>().bulletSetting.bulletDamage;
            mainWeapon.bulletSetting.currentBullet = bulletAbilityButton[(int)BulletType.Burn].GetComponent<Bullet>().bulletSetting.currentBullet;
            mainWeapon.bulletSetting.possessionBullet = bulletAbilityButton[(int)BulletType.Burn].GetComponent<Bullet>().bulletSetting.possessionBullet;
        }
        else if (buttonName == BulletType.Lightning.ToString())
        {
            mainWeapon.BulletType = BulletType.Lightning;
            imageBulletIcon.sprite = spriteBulletIcon[(int)BulletType.Lightning];
            mainWeapon.bulletSetting.bulletDamage = bulletAbilityButton[(int)BulletType.Lightning].GetComponent<Bullet>().bulletSetting.bulletDamage;
            mainWeapon.bulletSetting.currentBullet = bulletAbilityButton[(int)BulletType.Lightning].GetComponent<Bullet>().bulletSetting.currentBullet;
            mainWeapon.bulletSetting.possessionBullet = bulletAbilityButton[(int)BulletType.Lightning].GetComponent<Bullet>().bulletSetting.possessionBullet;
        }
        else if (buttonName == BulletType.Freezing.ToString())
        {
            mainWeapon.BulletType = BulletType.Freezing;
            imageBulletIcon.sprite = spriteBulletIcon[(int)BulletType.Freezing];
            mainWeapon.bulletSetting.bulletDamage = bulletAbilityButton[(int)BulletType.Freezing].GetComponent<Bullet>().bulletSetting.bulletDamage;
            mainWeapon.bulletSetting.currentBullet = bulletAbilityButton[(int)BulletType.Freezing].GetComponent<Bullet>().bulletSetting.currentBullet;
            mainWeapon.bulletSetting.possessionBullet = bulletAbilityButton[(int)BulletType.Freezing].GetComponent<Bullet>().bulletSetting.possessionBullet;
        }
        bulletText.text = $"<size=40>{mainWeapon.bulletSetting.currentBullet}/</size>{mainWeapon.bulletSetting.possessionBullet}";
    }
}
