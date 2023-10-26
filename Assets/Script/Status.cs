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
    [SerializeField] int maxHP;
    int currentHP;

    public int CurrentHP => currentHP;
    public int MaxHP => maxHP;

    void Awake() => currentHP = maxHP;
    
    public bool DecreaseHp(int damage)
    {
        int previousHP = currentHP;

        currentHP = currentHP - damage > 0 ? currentHP - damage : 0;

        onHPEvent.Invoke(previousHP, currentHP);

        if (currentHP == 0) return true;

        return false;
    }

    public void IncreaseHP(int hp)
    {
        int previousHP = currentHP;

        currentHP = currentHP + hp > maxHP ? maxHP : currentHP + hp;

        onHPEvent.Invoke(previousHP, currentHP);
    }
}
