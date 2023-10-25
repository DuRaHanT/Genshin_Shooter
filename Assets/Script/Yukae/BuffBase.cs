using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuffBase : MonoBehaviour
{
    public BuffSetting buffSetting;

    public void DamageUP(int damage)
    {
        damage = buffSetting.damageUP + damage;
    }
}
