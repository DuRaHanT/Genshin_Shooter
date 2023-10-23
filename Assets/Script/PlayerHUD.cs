using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerHUD : MonoBehaviour
{
    WeaponBase weapon;

    [Header("Components")]
    [SerializeField] Status status;

    [Header("Weapon Base")]
    [SerializeField] TextMeshProUGUI textWeaponName;
    [SerializeField] Image imageWeaponIcon;
    [SerializeField] Sprite[] spriteWeaponIcons;
    [SerializeField] Vector2[] sizeWeaponIcons;

    [Header("Swith System")]
    [SerializeField] BulletSwitch bulletSwitch;
    [SerializeField] GrenadeSwitch grenadeSwitch;
    [SerializeField] Image imageAbilityIcon;
    [SerializeField] Sprite[] spriteBulletIcon;
    [SerializeField] Sprite[] spriteGrenadeIcon;

    [Header("Ammo")]
    [SerializeField] TextMeshProUGUI textAmmo;

    [Header("Magazine")]
    [SerializeField] int maxMagazineCount;

    [Header("HP & BloodScreen UI")]
    [SerializeField] TextMeshProUGUI textHP;
    [SerializeField] Image imageBloodScreen;
    [SerializeField] AnimationCurve curveBloodScreen;

    void Awake() => status.onHPEvent.AddListener(UpdateHPHUD);

    public void SetupAllWeapon(WeaponBase[] weapons)
    {

        for(int i = 0; i < weapons.Length; ++i) weapons[i].onAmmoEvent.AddListener(UpdateAmmoHUD);
    }

    public void SwitchingWeapon(WeaponBase newWeapon)
    {
        weapon = newWeapon;

        SetupWeapon();
    }

    void SetupWeapon()
    {
        textWeaponName.text = weapon.WeaponName.ToString();
        imageWeaponIcon.sprite = spriteWeaponIcons[(int)weapon.WeaponName];
        imageWeaponIcon.rectTransform.sizeDelta = sizeWeaponIcons[(int)weapon.WeaponName];

        if (weapon.WeaponName.ToString() == "AssaultRifle")
        {
            imageAbilityIcon.sprite = spriteBulletIcon[(int)bulletSwitch.mainWeapon.BulletType];
        }

        else if (weapon.WeaponName.ToString() == "HandGrenade")
        {
            imageAbilityIcon.sprite = spriteGrenadeIcon[(int)grenadeSwitch.grenade.grenadeType];
        }

        else
        {
            imageAbilityIcon.sprite = null;
        }
    }

    void UpdateAmmoHUD(int currentAmmo, int maxAmmo)
    {
        textAmmo.text = $"<size=40>{currentAmmo}/</size>{maxAmmo}";
    }

    void UpdateHPHUD(int previous, int current)
    {
        textHP.text = "HP " + current;

        if (previous <= current) return;
        
        if(previous - current > 0)
        {
            StopCoroutine("OnBloodScreen");
            StartCoroutine("OnBloodScreen");
        }
    }

    IEnumerator OnBloodScreen()
    {
        float percent = 0;

        while(percent < 1)
        {
            percent += Time.deltaTime;

            Color color = imageBloodScreen.color;
            color.a = Mathf.Lerp(1, 0, curveBloodScreen.Evaluate(percent));
            imageBloodScreen.color = color;

            yield return null;
        }
    }
}
