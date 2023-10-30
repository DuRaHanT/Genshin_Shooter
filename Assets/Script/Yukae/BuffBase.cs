using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuffBase : MonoBehaviour
{
    public BuffSetting buffSetting;
    float resistanceDownValue => 0.25f;

    public void DamageUP(int damage) => _ = buffSetting.damageUP;

    public void ResistanceDown() => buffSetting.resistance /= resistanceDownValue;

    public void Imma(ResistanceType type) => buffSetting.typeImmune[(int)type] = true;

    public void AddShield(int shield) => buffSetting.shield = shield;
}
