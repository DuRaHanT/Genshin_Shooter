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
        int shield = buff.buffSetting.shield;

        int totalDamage = (int)(buff.buffSetting.resistance * damage) + additional_Damage;

        if (shield > 0)
        {
            if (shield - totalDamage > 0) shield -= totalDamage;
            if (shield - totalDamage <= 0)
            {
                shield = 0;
                currentHP = currentHP + shield - totalDamage;
            }
        }

        else if(shield <= 0) currentHP = currentHP - totalDamage > 0 ? currentHP - totalDamage : 0;

        onHPEvent.Invoke(currentHP, currentHP);

        if (currentHP == 0) return true;

        return false;
    }

    public int AdditionalDamageChack() => additional_Damage;

    public void SpeedUP()
    {
        walkSpeed *= buff.buffSetting.speedUp;
        runSpeed *= buff.buffSetting.speedUp;
    }

    public void IncreaseHP(int hp)
    {
        currentHP = currentHP + hp > maxHP ? maxHP : currentHP + hp;

        onHPEvent.Invoke(currentHP, currentHP);
    }
}
