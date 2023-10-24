using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponGrenade : WeaponBase
{
    [Header("Audio Clips")]
    [SerializeField] AudioClip audioClipFire;

    [Header("Grenade")]
    [SerializeField] GameObject grenadePrefab;
    [SerializeField] Transform grenadeSpawnPoint;
    [SerializeField] Grenade[] grenade;
    [SerializeField] InventotyGrenade inventotyGrenade;
    [SerializeField] MainGrenadeType mainGrenadeType;

    void OnEnable()
    {
        onAmmoEvent.Invoke(mainGrenadeType.grenadeSetting.currentGrenade, mainGrenadeType.grenadeSetting.possessionGrenade);
    }

    void Awake()
    {
        base.Setup();
        weaponSetting.currentAmmo = mainGrenadeType.grenadeSetting.currentGrenade; // 아마 지워도 될듯
    }

    public override void StartWeaponAction(int type = 0)
    {
        if (inventotyGrenade.inventory.activeSelf == true) return;

        if (isAttack == false) StartCoroutine("OnAttack");
    }

    IEnumerator OnAttack()
    {
        isAttack = true;

        animator.Play("Fire", -1, 0);
        PlaySound(audioClipFire);

        yield return new WaitForEndOfFrame();

        while(true)
        {
            if(animator.CurrentAnimationIs("Movement"))
            {
                isAttack = false;

                yield break;
            }

            yield return null;
        }
    }

    public void SpawnGrenadeProjectile()
    {
        switch(mainGrenadeType.grenadeType)
        {
            case GrenadeType.None:
                if (grenade[(int)GrenadeType.None].grenadeSetting.currentGrenade <= 0) return;
                break;
            case GrenadeType.Air:
                if (grenade[(int)GrenadeType.Air].grenadeSetting.currentGrenade <= 0) return;
                break;
            case GrenadeType.Water:
                if (grenade[(int)GrenadeType.Water].grenadeSetting.currentGrenade <= 0) return;
                break;
        }

        GameObject grenadeClone = Instantiate(grenadePrefab, grenadeSpawnPoint.position, Random.rotation);

        switch(mainGrenadeType.grenadeType)
        {
            case GrenadeType.None:
                grenadeClone.GetComponent<WeaponGrenadeProjectile>().Setup(grenade[(int)GrenadeType.None].grenadeSetting.grenadeDamage, transform.parent.forward);
                grenade[(int)GrenadeType.None].grenadeSetting.currentGrenade--;
                onAmmoEvent.Invoke(grenade[(int)GrenadeType.None].grenadeSetting.currentGrenade, (int)grenade[(int)GrenadeType.None].grenadeSetting.possessionGrenade);
                break;
            case GrenadeType.Air:
                grenadeClone.GetComponent<WeaponGrenadeProjectile>().Setup(grenade[(int)GrenadeType.Air].grenadeSetting.grenadeDamage, transform.parent.forward);
                grenade[(int)GrenadeType.Air].grenadeSetting.currentGrenade--;
                onAmmoEvent.Invoke(grenade[(int)GrenadeType.Air].grenadeSetting.currentGrenade, (int)grenade[(int)GrenadeType.Air].grenadeSetting.possessionGrenade);
                break;
            case GrenadeType.Water:
                grenadeClone.GetComponent<WeaponGrenadeProjectile>().Setup(grenade[(int)GrenadeType.Water].grenadeSetting.grenadeDamage, transform.parent.forward);
                grenade[(int)GrenadeType.Water].grenadeSetting.currentGrenade--;
                onAmmoEvent.Invoke(grenade[(int)GrenadeType.Water].grenadeSetting.currentGrenade, (int)grenade[(int)GrenadeType.Water].grenadeSetting.possessionGrenade);
                break;
        }
        
    }

    public override void StopWeaponAction(int type = 0)
    {
    }

    public override void StartReload()
    {
    }


    //수류탄 리필은 없을 예정
    //public override void IncreaseMaxAmmo(int ammo)
    //{
    //    weaponSetting.currentAmmo = weaponSetting.currentAmmo + ammo > weaponSetting.maxAmmo ? weaponSetting.maxAmmo : weaponSetting.currentAmmo + ammo;
    //    onAmmoEvent.Invoke(weaponSetting.currentAmmo, weaponSetting.maxAmmo);
    //}
}
