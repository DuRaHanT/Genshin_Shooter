using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum WeaponType { Main = 0, Sub, Melee, Throw, }

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
    }

    public virtual void IncreaseMaxAmmo(int Ammo)
    {
        weaponSetting.possessionAmmo = CurrentpossessionAmmo + Ammo > MaxAmmo ? MaxAmmo : CurrentpossessionAmmo + Ammo;

        onAmmoEvent.Invoke(weaponSetting.currentAmmo ,CurrentpossessionAmmo);
    }
}
