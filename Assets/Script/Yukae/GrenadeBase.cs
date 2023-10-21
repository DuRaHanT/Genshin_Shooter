using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class GrenadeEvent : UnityEngine.Events.UnityEvent<int, int> { }

public enum GrenadeType { None, Air, Water, }

public abstract class GrenadeBase : MonoBehaviour
{
    [SerializeField] protected GrenadeSetting grenadeSetting;
    public GrenadeType grenadeType;

    protected int maxGrenade => 99;
    protected float lastAttackTime => 20;
    protected bool isReload = false;
    protected bool isAim = false;
    protected bool isAttack = false;
    protected AudioSource audioSource;
    protected PlayerAnimatorController animator;

    public int CurrentGrenade => grenadeSetting.currentGrenade;
    public int CurrentpossessionGrenade => grenadeSetting.possessionGrenade;

    [HideInInspector] public GrenadeEvent onGrenadeEvent = new GrenadeEvent();

    public abstract void StartWeaponAction();

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
}
