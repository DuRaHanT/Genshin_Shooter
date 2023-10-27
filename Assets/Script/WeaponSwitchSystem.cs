using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSwitchSystem : MonoBehaviour
{
    [SerializeField] PlayerController playerController;
    [SerializeField] PlayerHUD playerHUD;

    [SerializeField] WeaponBase[] weapons;

    WeaponBase currentWeapon;
    WeaponBase previousWeapon;

    void Awake()
    {
        playerHUD.SetupAllWeapon(weapons);
        
        for(int i = 0; i < weapons.Length; ++i)
        {
            if (weapons[i].gameObject != null) weapons[i].gameObject.SetActive(false);
        }

        SwithingWeapon(WeaponType.Main);
    }

    void Update() => UpdateSwitch();

    void UpdateSwitch()
    { 
        if (!Input.anyKeyDown) return;

        int inputIndex = 0;
        if (int.TryParse(Input.inputString, out inputIndex) && (inputIndex > 0 && inputIndex < 5)) SwithingWeapon((WeaponType)(inputIndex - 1));
    }

    void SwithingWeapon(WeaponType weaponType)
    {
        if (weapons[(int)weaponType] == null) return;

        if (currentWeapon != null) previousWeapon = currentWeapon;

        currentWeapon = weapons[(int)weaponType];

        if (currentWeapon == previousWeapon) return;

        playerController.SwitchingWeapon(currentWeapon);
        playerHUD.SwitchingWeapon(currentWeapon);

        if (previousWeapon != null) previousWeapon.gameObject.SetActive(false);

        currentWeapon.gameObject.SetActive(true);
    }

    public void IncreasespossessionAmmo(WeaponType weaponType, int Ammo)
    {
        if (weapons[(int)weaponType] != null) weapons[(int)weaponType].IncreaseMaxAmmo(Ammo);
    }

    public void IncreasespossessionAmmo(int Ammo)
    {
        for (int i = 0; i < weapons.Length; ++i)
        {
            if (weapons[i] != null) weapons[i].IncreaseMaxAmmo(Ammo);
        }
    }
}
