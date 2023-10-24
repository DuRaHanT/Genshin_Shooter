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

    public void GrenadeChange(string buttonName)
    {
        if (buttonName == GrenadeType.None.ToString())
        {
            grenadeType.grenadeType = GrenadeType.None;
            imageGrenadeIcon.sprite = spriteGrenadeIcon[(int)GrenadeType.None];
            grenadeType.grenadeSetting.grenadeDamage = grenadeAbilityButton[(int)GrenadeType.None].GetComponent<Grenade>().grenadeSetting.grenadeDamage;
            grenadeType.grenadeSetting.currentGrenade = grenadeAbilityButton[(int)GrenadeType.None].GetComponent<Grenade>().grenadeSetting.currentGrenade;
            grenadeType.grenadeSetting.possessionGrenade = grenadeAbilityButton[(int)GrenadeType.None].GetComponent<Grenade>().grenadeSetting.possessionGrenade;
        }
        else if (buttonName == GrenadeType.Air.ToString())
        {
            grenadeType.grenadeType = GrenadeType.Air;
            imageGrenadeIcon.sprite = spriteGrenadeIcon[(int)GrenadeType.Air];
            grenadeType.grenadeSetting.grenadeDamage = grenadeAbilityButton[(int)GrenadeType.Air].GetComponent<Grenade>().grenadeSetting.grenadeDamage;
            grenadeType.grenadeSetting.currentGrenade = grenadeAbilityButton[(int)GrenadeType.Air].GetComponent<Grenade>().grenadeSetting.currentGrenade;
            grenadeType.grenadeSetting.possessionGrenade = grenadeAbilityButton[(int)GrenadeType.Air].GetComponent<Grenade>().grenadeSetting.possessionGrenade;
        }
        else if (buttonName == GrenadeType.Water.ToString())
        {
            grenadeType.grenadeType = GrenadeType.Water;
            imageGrenadeIcon.sprite = spriteGrenadeIcon[(int)GrenadeType.Water];
            grenadeType.grenadeSetting.grenadeDamage = grenadeAbilityButton[(int)GrenadeType.Water].GetComponent<Grenade>().grenadeSetting.grenadeDamage;
            grenadeType.grenadeSetting.currentGrenade = grenadeAbilityButton[(int)GrenadeType.Water].GetComponent<Grenade>().grenadeSetting.currentGrenade;
            grenadeType.grenadeSetting.possessionGrenade = grenadeAbilityButton[(int)GrenadeType.Water].GetComponent<Grenade>().grenadeSetting.possessionGrenade;
        }
        GrenadeText.text = $"<size=40>{grenadeType.grenadeSetting.currentGrenade}/</size>{grenadeType.grenadeSetting.possessionGrenade}";
    }
}
