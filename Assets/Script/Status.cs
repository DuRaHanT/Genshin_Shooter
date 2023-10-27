using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class HPEvent : UnityEngine.Events.UnityEvent<int, int> { }

public class Status : MonoBehaviour
{
    [HideInInspector] public HPEvent onHPEvent = new HPEvent();

    [Header("Walk, Run Speed")]
    public float walkSpeed;
    public float runSpeed;

    [Header("HP")]
    public int maxHP;
    public int currentHP;

    void Awake() => currentHP = maxHP;
    
    public bool DecreaseHp(int damage)
    {
        currentHP = currentHP - damage > 0 ? currentHP - damage : 0;

        onHPEvent.Invoke(currentHP, currentHP);

        if (currentHP == 0) return true;

        return false;
    }

    public void IncreaseHP(int hp)
    {
        currentHP = currentHP + hp > maxHP ? maxHP : currentHP + hp;

        onHPEvent.Invoke(currentHP, currentHP);
    }
}
