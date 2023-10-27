using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GrenadeSwitch : MonoBehaviour
{
    [SerializeField] Button[] grenadeAbilityButton;
    public MainGrenadeType grenadeType;

    [SerializeField] Image imageGrenadeIcon;
    [SerializeField] Sprite[] spriteGrenadeIcon;
    [SerializeField] TextMeshProUGUI GrenadeText;
    [SerializeField] InventotyGrenade inventotyGrenade;

    void Awake()
    {
        grenadeType.grenadeType = GrenadeType.None;
        Setting(grenadeType.grenadeType);
    }

    public void GrenadeChange(string buttonName)
    {
        if (buttonName == GrenadeType.None.ToString())
        {
            grenadeType.grenadeType = GrenadeType.None;
            Setting(grenadeType.grenadeType);
        }
        else if (buttonName == GrenadeType.Air.ToString())
        {
            grenadeType.grenadeType = GrenadeType.Air;
            Setting(grenadeType.grenadeType);
        }
        else if (buttonName == GrenadeType.Water.ToString())
        {
            grenadeType.grenadeType = GrenadeType.Water;
            Setting(grenadeType.grenadeType);
        }
        inventotyGrenade.ViewInventory();
        GrenadeText.text = $"<size=40>{grenadeType.grenadeSetting.currentGrenade}/</size>{grenadeType.grenadeSetting.possessionGrenade}";
    }

    void Setting(GrenadeType type)
    {
        imageGrenadeIcon.sprite = spriteGrenadeIcon[(int)type];
        grenadeType.grenadeSetting.grenadeDamage = grenadeAbilityButton[(int)type].GetComponent<Grenade>().grenadeSetting.grenadeDamage;
        grenadeType.grenadeSetting.currentGrenade = grenadeAbilityButton[(int)type].GetComponent<Grenade>().grenadeSetting.currentGrenade;
        grenadeType.grenadeSetting.possessionGrenade = grenadeAbilityButton[(int)type].GetComponent<Grenade>().grenadeSetting.possessionGrenade;
    }
}
