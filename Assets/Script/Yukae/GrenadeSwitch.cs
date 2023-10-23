using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GrenadeSwitch : MonoBehaviour
{
    [SerializeField] Button[] grenadeAbilityButton;
    public Grenade grenade;

    [SerializeField] Image imageGrenadeIcon;
    [SerializeField] Sprite[] spriteGrenadeIcon;

    public void GrenadeChange(string buttonName)
    {
        if (buttonName == GrenadeType.None.ToString())
        {
            grenade.grenadeType = GrenadeType.None;
            imageGrenadeIcon.sprite = spriteGrenadeIcon[(int)GrenadeType.None];
            grenade.grenadeSetting.grenadeDamage = grenadeAbilityButton[(int)GrenadeType.None].GetComponent<Grenade>().grenadeSetting.grenadeDamage;
            grenade.grenadeSetting.currentGrenade = grenadeAbilityButton[(int)GrenadeType.None].GetComponent<Grenade>().grenadeSetting.currentGrenade;
            grenade.grenadeSetting.possessionGrenade = grenadeAbilityButton[(int)GrenadeType.None].GetComponent<Grenade>().grenadeSetting.possessionGrenade;
        }
        else if (buttonName == GrenadeType.Air.ToString())
        {
            grenade.grenadeType = GrenadeType.Air;
            imageGrenadeIcon.sprite = spriteGrenadeIcon[(int)GrenadeType.Air];
            grenade.grenadeSetting.grenadeDamage = grenadeAbilityButton[(int)GrenadeType.Air].GetComponent<Grenade>().grenadeSetting.grenadeDamage;
            grenade.grenadeSetting.currentGrenade = grenadeAbilityButton[(int)GrenadeType.Air].GetComponent<Grenade>().grenadeSetting.currentGrenade;
            grenade.grenadeSetting.possessionGrenade = grenadeAbilityButton[(int)GrenadeType.Air].GetComponent<Grenade>().grenadeSetting.possessionGrenade;
        }
        else if (buttonName == GrenadeType.Water.ToString())
        {
            grenade.grenadeType = GrenadeType.Water;
            imageGrenadeIcon.sprite = spriteGrenadeIcon[(int)GrenadeType.Water];
            grenade.grenadeSetting.grenadeDamage = grenadeAbilityButton[(int)GrenadeType.Water].GetComponent<Grenade>().grenadeSetting.grenadeDamage;
            grenade.grenadeSetting.currentGrenade = grenadeAbilityButton[(int)GrenadeType.Water].GetComponent<Grenade>().grenadeSetting.currentGrenade;
            grenade.grenadeSetting.possessionGrenade = grenadeAbilityButton[(int)GrenadeType.Water].GetComponent<Grenade>().grenadeSetting.possessionGrenade;
        }
    }
}
