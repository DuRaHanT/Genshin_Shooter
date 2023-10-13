using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponRevolver : WeaponBase
{
    [Header("Fire Effects")]
    [SerializeField] GameObject muzzleFlashEffect;

    [Header("Spawn Points")]
    [SerializeField] Transform bulletSpawnPoint;

    [Header("Audio Clips")]
    [SerializeField] AudioClip audioClipFire;
    [SerializeField] AudioClip audioClipReload;

    ImpactMemoryPool impactMemoryPool;
    Camera mainCamera;

    void OnEnable()
    {
        muzzleFlashEffect.SetActive(false);

        onAmmoEvent.Invoke(weaponSetting.currentAmmo, weaponSetting.maxAmmo);

        ResetVariables();
    }

    void Awake()
    {
        base.Setup();

        impactMemoryPool = GetComponent<ImpactMemoryPool>();
        mainCamera = Camera.main;

        weaponSetting.currentAmmo = weaponSetting.maxAmmo;
    }

    public override void StartWeaponAction(int type = 0)
    {
        if (type == 0 && isAttack == false && isReload == false) OnAttack();
    }

    public override void StopWeaponAction(int type = 0) => isAttack = false;
    
    public override void StartReload()
    {
        if (isReload == true || weaponSetting.possessionAmmo <= 0) return;

        StopWeaponAction();

        StartCoroutine("OnReload");
    }

    public void OnAttack()
    {
        if(Time.time - lastAttackTime > weaponSetting.attackRate)
        {
            if (animator.MoveSpeed > 0.5f) return;

            lastAttackTime = Time.time;

            if (weaponSetting.currentAmmo <= 0) return;

            weaponSetting.currentAmmo--;
            onAmmoEvent.Invoke(weaponSetting.currentAmmo, weaponSetting.maxAmmo);

            animator.Play("Fire", -1, 0);

            StartCoroutine("OnMuzzleFlashEffect");

            PlaySound(audioClipFire);

            TwoStepRaycast();
        }
    }

    IEnumerator OnMuzzleFlashEffect()
    {
        muzzleFlashEffect.SetActive(true);

        yield return new WaitForSeconds(weaponSetting.attackRate * 0.3f);

        muzzleFlashEffect.SetActive(false);
    }

    IEnumerator OnReload()
    {
        isReload = true;

        animator.OnReload();
        PlaySound(audioClipReload);

        while (true)
        {
            if (audioSource.isPlaying == false && animator.CurrentAnimationIs("Movement"))
            {
                isReload = false;

                AmmoCheak();

                yield break;
            }

            yield return null;
        }
    }

    void AmmoCheak()
    {
        if (CurrentpossessionAmmo <= 0) return;

        int ammoToAdd = Mathf.Min(weaponSetting.maxAmmo - weaponSetting.currentAmmo, weaponSetting.possessionAmmo);
        weaponSetting.currentAmmo += ammoToAdd;
        weaponSetting.possessionAmmo -= ammoToAdd;

        onAmmoEvent.Invoke(weaponSetting.maxAmmo, weaponSetting.possessionAmmo);
    }

    void TwoStepRaycast()
    {
        Ray ray;
        RaycastHit hit;
        Vector3 targetPoint = Vector3.zero;

        ray = mainCamera.ViewportPointToRay(Vector2.one * 0.5f);

        if (Physics.Raycast(ray, out hit, weaponSetting.attackDistance)) targetPoint = hit.point;
        else targetPoint = ray.origin + ray.direction * weaponSetting.attackDistance;

        Debug.DrawRay(ray.origin, ray.direction * weaponSetting.attackDistance, Color.red);

        Vector3 attackDirection = (targetPoint - bulletSpawnPoint.position).normalized;
        if (Physics.Raycast(bulletSpawnPoint.position, attackDirection, out hit, weaponSetting.attackDistance))
        {
            impactMemoryPool.SpawnImpact(hit);

            if (hit.transform.CompareTag("ImpactEnemy")) hit.transform.GetComponent<EnemyFSM>().TakeDamage(weaponSetting.damage);
            else if (hit.transform.CompareTag("InteractionObject")) hit.transform.GetComponent<InteractionObject>().TakeDamage(weaponSetting.damage);
        }

        Debug.DrawRay(bulletSpawnPoint.position, attackDirection * weaponSetting.attackDistance, Color.blue);
    }

    void ResetVariables()
    {
        isReload = false;
        isAttack = false;
    }
}
