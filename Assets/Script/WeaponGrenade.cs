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

    void OnEnable()
    {
        onAmmoEvent.Invoke(weaponSetting.currentGrenade, weaponSetting.maxGrenade);
    }

    void Awake()
    {
        base.Setup();
        weaponSetting.currentAmmo = weaponSetting.maxAmmo;
    }

    public override void StartWeaponAction(int type = 0)
    {
        if (type == 0 && isAttack == false && weaponSetting.currentGrenade > 0) StartCoroutine("OnAttack");
    }

    public override void StopWeaponAction(int type = 0)
    {
    }

    public override void StartReload()
    {
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
        GameObject grenadeClone = Instantiate(grenadePrefab, grenadeSpawnPoint.position, Random.rotation);
        grenadeClone.GetComponent<WeaponGrenadeProjectile>().Setup(weaponSetting.damage, transform.parent.forward);

        weaponSetting.currentGrenade--;
        onAmmoEvent.Invoke(weaponSetting.currentGrenade, weaponSetting.maxGrenade);
    }


    //수류탄 리필은 없을 예정
    //public override void IncreaseMaxAmmo(int ammo)
    //{
    //    weaponSetting.currentAmmo = weaponSetting.currentAmmo + ammo > weaponSetting.maxAmmo ? weaponSetting.maxAmmo : weaponSetting.currentAmmo + ammo;
    //    onAmmoEvent.Invoke(weaponSetting.currentAmmo, weaponSetting.maxAmmo);
    //}
}
