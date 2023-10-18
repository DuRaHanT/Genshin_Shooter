using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum WeaponType { Main = 0, Sub, Melee, Throw, Burn = 0, Lightning = 0, Freezing = 0 }

[System.Serializable]
public class AmmoEvent : UnityEngine.Events.UnityEvent<int, int> { }

public abstract class WeaponBase : MonoBehaviour
{
    [Header("WeaponBase")]
    [SerializeField] protected WeaponType weaponType;
    [SerializeField] protected WeaponSetting weaponSetting;

    protected float lastAttackTime = 0;
    protected bool isReload = false;
    protected bool isAttack = false;
    protected bool isAim = false;
    protected AudioSource audioSource;
    protected PlayerAnimatorController animator;

    [HideInInspector] public AmmoEvent onAmmoEvent = new AmmoEvent();

    public PlayerAnimatorController Animator => animator;
    public WeaponName WeaponName => weaponSetting.weaponName;
    public int CurrentpossessionAmmo => weaponSetting.possessionAmmo;
    public int MaxAmmo => 999;

    public abstract void StartWeaponAction(int type = 0);
    public abstract void StopWeaponAction(int type = 0);
    public abstract void StartReload();

    protected void PlaySound(AudioClip clip)
    {
        audioSource.Stop();
        audioSource.clip = clip;
        audioSource.Play();
    }

    protected void Setup()
    {
        audioSource = GetComponent<AudioSource>();
        animator = GetComponent<PlayerAnimatorController>();

        // ex) Tutorial = 100, Easy = 10, Normal = 5, Hard = 1 
        weaponSetting.Level = 100;
    }

    public virtual void IncreaseMaxAmmo(int Ammo)
    {
        weaponSetting.possessionAmmo = CurrentpossessionAmmo + Ammo > MaxAmmo ? MaxAmmo : CurrentpossessionAmmo + Ammo;

        onAmmoEvent.Invoke(weaponSetting.currentAmmo ,CurrentpossessionAmmo);
    }
}
