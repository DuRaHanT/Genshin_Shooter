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

    [Header("Ammo")]
    [SerializeField] TextMeshProUGUI textAmmo;

    [Header("Magazine")]
    [SerializeField] GameObject magazineUIPrefab;
    [SerializeField] Transform magazineParent;
    [SerializeField] int maxMagazineCount;
    List<GameObject> magazineList;

    [Header("HP & BloodScreen UI")]
    [SerializeField] TextMeshProUGUI textHP;
    [SerializeField] Image imageBloodScreen;
    [SerializeField] AnimationCurve curveBloodScreen;

    void Awake() => status.onHPEvent.AddListener(UpdateHPHUD);

    public void SetupAllWeapon(WeaponBase[] weapons)
    {
        SetupMagazine();

        for(int i = 0; i < weapons.Length; ++i)
        {
            weapons[i].onAmmoEvent.AddListener(UpdateAmmoHUD);
            weapons[i].onMagazineEvent.AddListener(UpdateMagazineHUD);
        }
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
    }

    void UpdateAmmoHUD(int currentAmmo, int maxAmmo)
    {
        textAmmo.text = $"<size=40>{currentAmmo}/</size>{maxAmmo}";
    }

    void SetupMagazine()
    {
        magazineList = new List<GameObject>();
        
        for(int i = 0; i < maxMagazineCount; ++i)
        {
            GameObject clone = Instantiate(magazineUIPrefab);
            clone.transform.SetParent(magazineParent);
            clone.SetActive(false);

            magazineList.Add(clone);
        }    
    }

    void UpdateMagazineHUD(int currentMagazine)
    {
        for(int i = 0; i < magazineList.Count; ++i)
        {
            magazineList[i].SetActive(false);
        }
        for(int i = 0; i< currentMagazine; ++i)
        {
            magazineList[i].SetActive(true);
        }
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
