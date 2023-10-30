using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class HPEvent : UnityEngine.Events.UnityEvent<int, int> { }

public class Status : MonoBehaviour
{
    [HideInInspector] public HPEvent onHPEvent = new HPEvent();
    [HideInInspector] public BuffBase buff;

    [Header("Walk, Run Speed")]
    public float walkSpeed;
    public float runSpeed;

    [Header("HP")]
    public int maxHP;
    public int currentHP;

    public int additional_Damage;

    void Awake()
    {
        currentHP = maxHP;
        buff = GetComponent<BuffBase>();
    }
    
    public bool DecreaseHp(int damage)
    {
        currentHP = currentHP - (int)(buff.buffSetting.resistance * damage) + additional_Damage > 0 ? currentHP - (int)(buff.buffSetting.resistance * damage) + additional_Damage : 0;

        onHPEvent.Invoke(currentHP, currentHP);

        if (currentHP == 0) return true;

        return false;
    }

    public int AdditionalDamageChack() => additional_Damage;

    public void IncreaseHP(int hp)
    {
        currentHP = currentHP + hp > maxHP ? maxHP : currentHP + hp;

        onHPEvent.Invoke(currentHP, currentHP);
    }
}
