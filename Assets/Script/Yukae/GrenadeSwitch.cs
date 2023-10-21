using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GrenadeSwitch : GrenadeBase
{
    [SerializeField] Button[] grenadeAbilityButton;
    WeaponGrenade weaponGrenade;

    private void Awake()
    {
        weaponGrenade = GetComponent<WeaponGrenade>(); 

        for (int i = 0; i < grenadeAbilityButton.Length; i++) grenadeAbilityButton[i].onClick.AddListener(() => GrenadeChange(grenadeAbilityButton[i].gameObject.name));
    }

    void GrenadeChange(string buttonName)
    {
        if (buttonName == GrenadeType.None.ToString()) weaponGrenade.grenadeType = GrenadeType.None;
        else if (buttonName == GrenadeType.Air.ToString()) weaponGrenade.grenadeType = GrenadeType.Air;
        else if (buttonName == GrenadeType.Water.ToString()) weaponGrenade.grenadeType = GrenadeType.Water;
    }

    public override void StartWeaponAction()
    {
    }
}
