using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GrenadeSwitch : GrenadeBase
{
    [SerializeField] Button[] grenadeAbilityButton;
    [SerializeField] WeaponGrenade weaponGrenade;


    private void Awake()
    {
        for (int i = 0; i < grenadeAbilityButton.Length; i++) grenadeAbilityButton[i].onClick.AddListener(GrenadeChange);
    }

    void GrenadeChange()
    {
        for (int i = 0; i < grenadeAbilityButton.Length; i++) if (grenadeAbilityButton[i].gameObject.name == GrenadeType.Air.ToString()) weaponGrenade.grenadeType = GrenadeType.Air;
    }

    public override void StartReload()
    {
    }

    public override void StartWeaponAction()
    {
    }

    public override void StopWeaponAction()
    {
    }
}
