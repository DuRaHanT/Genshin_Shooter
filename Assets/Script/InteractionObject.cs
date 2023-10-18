using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class InteractionObject : MonoBehaviour
{
    [Header("Interaction Object")]
    [SerializeField] protected float maxHP;
    [SerializeField] protected float currentHP;

    void Awake() => currentHP = maxHP;

    public abstract void TakeDamage(int damage);
}
