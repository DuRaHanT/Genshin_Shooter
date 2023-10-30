using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuffBase : MonoBehaviour
{
    public BuffSetting buffSetting;
    float resistanceDownValue => 0.25f;

    public void DamageUP(int damage) => damage = buffSetting.damageUP;

    public void ResistanceDown() => buffSetting.resistance = buffSetting.resistance / resistanceDownValue;
}
