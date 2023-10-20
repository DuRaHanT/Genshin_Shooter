using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class BulletEvent : UnityEngine.Events.UnityEvent<int, int> { }

public enum BulletType { Nomal, Burn, Lightning, Freezing, }


public class BulletBase : MonoBehaviour
{
    [Header("BulletBase")]
    [SerializeField] protected BulletSetting bulletSetting;

    protected int maxBullet => 999;

    protected BulletType BulletType;
    public BulletName BulletName => bulletSetting.ability;
    public int CurrentBullet => bulletSetting.currentBullet;
    public int CurrentpossessionBullet => bulletSetting.possessionBullet;

    [HideInInspector] public BulletEvent onBulletEvent = new BulletEvent();

    public virtual void IncreaseMaxAmmo(int Bullet)
    {
        bulletSetting.possessionBullet = CurrentpossessionBullet + Bullet > maxBullet ? maxBullet : CurrentpossessionBullet + Bullet;

        onBulletEvent.Invoke(bulletSetting.currentBullet, CurrentpossessionBullet);
    }
}
