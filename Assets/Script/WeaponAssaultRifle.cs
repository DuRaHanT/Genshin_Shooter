using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WeaponAssaultRifle : WeaponBase
{

    [Header("Fire Effects")]
    [SerializeField] GameObject muzzleFlashEffect;

    [Header("Spawn Points")]
    [SerializeField] Transform casingSpawnPoint;
    [SerializeField] Transform bulletSpawnPoint;

    [Header("Audio Clips")]
    [SerializeField] AudioClip audioClipTakeOutWeapon;
    [SerializeField] AudioClip audioClipFire;
    [SerializeField] AudioClip audioClipReload;

    [Header("Bullet")]
    public MainWeapon mainWeapon;
    [SerializeField] Bullet[] bullets;
    [SerializeField] InventoryMainWeapon inventory;

    [Header("Aim UI")]
    [SerializeField] Image imageAim;

    bool isModeChange = false;
    float defaultModeFOV = 60;
    float aimModeFOV = 30;

    CasingMemoryPool casingMemoryPool;
    ImpactMemoryPool ImpactMemoryPool;
    Camera mainCamera;

    void Awake()
    {
        base.Setup();

        casingMemoryPool = GetComponent<CasingMemoryPool>();
        ImpactMemoryPool = GetComponent<ImpactMemoryPool>();
        mainCamera = Camera.main;

        weaponSetting.currentAmmo = weaponSetting.maxAmmo;
    }

    void OnEnable()
    {
        PlaySound(audioClipTakeOutWeapon);
        muzzleFlashEffect.SetActive(false);

        onAmmoEvent.Invoke(weaponSetting.currentAmmo, weaponSetting.maxAmmo);

        ResetVariables();
    }

    public override void StartWeaponAction(int type = 0)
    {
        if (isReload == true) return;

        if (isModeChange == true) return;

        if(type == 0)
        {
            if(weaponSetting.isAutomaticAttack == true)
            {
                isAttack = true;
                StartCoroutine("OnAttackLoop");
            }
            else
            {
                OnAttack();
            }
        }

        else
        {
            if (isAttack == true) return;

            StartCoroutine("OnModeChange");
        }
    }

    public override void StopWeaponAction(int type = 0)
    {
        if(type == 0)
        {
            isAttack = false;
            StopCoroutine("OnAttackLoop");
        }
    }

    public override void StartReload()
    {
        if (isReload == true || weaponSetting.possessionAmmo <= 0) return;

        if (isAim == true) return;

        StopWeaponAction();

        StartCoroutine("OnReload");
    }

    IEnumerator OnAttackLoop()
    {
        while(true)
        {
            OnAttack();
            yield return null;
        }
    }

    public void OnAttack()
    {
        if (inventory.inventory.activeSelf == true) return;

        if(Time.time - lastAttackTime > weaponSetting.attackRate)
        {
            if (animator.MoveSpeed > 0.5f)
            {
                return;
            }

            lastAttackTime = Time.time;

            switch(mainWeapon.BulletType)
            {
                case BulletType.Nomal:
                    if (bullets[(int)BulletType.Nomal].bulletSetting.currentBullet <= 0) return;
                    bullets[(int)BulletType.Nomal].bulletSetting.currentBullet--;
                    onAmmoEvent.Invoke(bullets[(int)BulletType.Nomal].bulletSetting.currentBullet, bullets[(int)BulletType.Nomal].bulletSetting.possessionBullet);
                    break;
                case BulletType.Burn:
                    if (bullets[(int)BulletType.Burn].bulletSetting.currentBullet <= 0) return;
                    bullets[(int)BulletType.Burn].bulletSetting.currentBullet--;
                    onAmmoEvent.Invoke(bullets[(int)BulletType.Burn].bulletSetting.currentBullet, bullets[(int)BulletType.Burn].bulletSetting.possessionBullet);
                    break;
                case BulletType.Lightning:
                    if (bullets[(int)BulletType.Lightning].bulletSetting.currentBullet <= 0) return;
                    bullets[(int)BulletType.Lightning].bulletSetting.currentBullet--;
                    onAmmoEvent.Invoke(bullets[(int)BulletType.Lightning].bulletSetting.currentBullet, bullets[(int)BulletType.Lightning].bulletSetting.possessionBullet);
                    break;
                case BulletType.Freezing:
                    if (bullets[(int)BulletType.Freezing].bulletSetting.currentBullet <= 0) return;
                    bullets[(int)BulletType.Freezing].bulletSetting.currentBullet--;
                    onAmmoEvent.Invoke(bullets[(int)BulletType.Freezing].bulletSetting.currentBullet, bullets[(int)BulletType.Freezing].bulletSetting.possessionBullet);
                    break;
            }

            string animation = animator.AimModeIs == true ? "AimFire" : "Fire";
            animator.Play(animation, -1, 0);
            if(animator.AimModeIs == false) StartCoroutine("OnMuzzleFlashEffect");
            PlaySound(audioClipFire);
            casingMemoryPool.SpawnCasing(casingSpawnPoint.position, transform.right);

            TwoStepRaycast();
        }
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
            ImpactMemoryPool.SpawnImpact(hit);

            if (hit.transform.CompareTag("ImpactEnemy"))
            {
                hit.transform.GetComponent<EnemyFSM>().TakeDamage(mainWeapon.bulletSetting.bulletDamage);
                hit.transform.GetComponent<EnemyFSM>().MainWeaponReaction(mainWeapon.BulletType);
            }
            else if (hit.transform.CompareTag("InteractionObject")) hit.transform.GetComponent<InteractionObject>().TakeDamage(mainWeapon.bulletSetting.bulletDamage);
        }

        Debug.DrawRay(bulletSpawnPoint.position, attackDirection * weaponSetting.attackDistance, Color.blue);
    }

    IEnumerator OnModeChange()
    {
        float current = 0;
        float percent = 0;
        float time = 0.35f;

        animator.AimModeIs = !animator.AimModeIs;
        imageAim.enabled = !imageAim.enabled;

        float start = mainCamera.fieldOfView;
        float end = animator.AimModeIs == true ? aimModeFOV : defaultModeFOV;

        isAim = !isAim;

        isModeChange = true;

        while(percent < 1)
        {
            current += Time.deltaTime;
            percent = current / time;

            mainCamera.fieldOfView = Mathf.Lerp(start, end, percent);

            yield return null;
        }

        isModeChange = false;
    }

    void ResetVariables()
    {
        isReload = false;
        isAttack = false;
        isModeChange = false;
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

        while(true)
        {
           if ( audioSource.isPlaying == false && ( animator.CurrentAnimationIs("Movement") || animator.CurrentAnimationIs("AimFirePose")) )
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

        onAmmoEvent.Invoke(weaponSetting.currentAmmo, weaponSetting.possessionAmmo);
    }
}
