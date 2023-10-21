using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponGrenade : GrenadeBase
{
    [Header("Audio Clips")]
    [SerializeField] AudioClip audioClipFire;

    [Header("Grenade")]
    [SerializeField] GameObject grenadePrefab;
    [SerializeField] Transform grenadeSpawnPoint;

    InventotyGrenade inventotyGrenade;

    void OnEnable()
    {
        onGrenadeEvent.Invoke(grenadeSetting.currentGrenade, grenadeSetting.possessionGrenade);
    }

    void Awake()
    {
        base.Setup();
        grenadeSetting.currentGrenade = grenadeSetting.possessionGrenade;
        inventotyGrenade = FindObjectOfType<InventotyGrenade>();
    }

    public override void StartWeaponAction()
    {
        if (inventotyGrenade.inventory.activeSelf == true) return;

        if (isAttack == false && grenadeSetting.currentGrenade > 0) StartCoroutine("OnAttack");
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
        grenadeClone.GetComponent<WeaponGrenadeProjectile>().Setup(grenadeSetting.grenadeDamage, transform.parent.forward);

        grenadeSetting.currentGrenade--;
        onGrenadeEvent.Invoke(grenadeSetting.currentGrenade, grenadeSetting.possessionGrenade);
    }


    //수류탄 리필은 없을 예정
    //public override void IncreaseMaxAmmo(int ammo)
    //{
    //    weaponSetting.currentAmmo = weaponSetting.currentAmmo + ammo > weaponSetting.maxAmmo ? weaponSetting.maxAmmo : weaponSetting.currentAmmo + ammo;
    //    onAmmoEvent.Invoke(weaponSetting.currentAmmo, weaponSetting.maxAmmo);
    //}
}
