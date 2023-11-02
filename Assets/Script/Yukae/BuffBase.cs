using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuffBase : MonoBehaviour
{
    public BuffSetting buffSetting;
    float resistanceDownValue => 0.25f;
    float time => 5.0f;

    public void DamageUP(int damage) => _ = buffSetting.damageUP;

    public void ResistanceDown() => buffSetting.resistance /= resistanceDownValue;

    public void Imma(ResistanceType type) => buffSetting.typeImmune[(int)type] = true;

    public void AddShield(int shield) => buffSetting.shield += shield;

    public IEnumerator DelayTime(float speed, float walkSpeed, float runSpeed)
    {
        walkSpeed *= speed;
        runSpeed *= speed;

        yield return new WaitForSeconds(time);

        walkSpeed /= speed;
        runSpeed /= speed;
    }
}
