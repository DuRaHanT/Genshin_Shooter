using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponKnife : WeaponBase
{
    [SerializeField] WeaponKnifeCollider weaponKnifecollider;

    void OnEnable() => isAttack = false;

    void Awake() => base.Setup();

    public override void StartWeaponAction(int type = 0)
    {
        if (isAttack == true) return;

        if (weaponSetting.isAutomaticAttack == true) StartCoroutine("OnAttackLoop", type);
        else StartCoroutine("OnAttack", type);
    }

    public override void StopWeaponAction(int type = 0)
    {
        isAttack = false;
        StopCoroutine("OnAttackLoop");
    }

    public override void StartReload()
    {
    }

    IEnumerator OnAttackLoop(int type)
    {
        while(true) yield return StartCoroutine("OnAttack", type);
    }

    IEnumerator OnAttack(int type)
    {
        isAttack = true;

        animator.SetFloat("attackType", type);
        animator.Play("Fire", -1, 0);

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

    public void StartWeaponKnifeCollider() => weaponKnifecollider.StartCollider(weaponSetting.damage);
}
