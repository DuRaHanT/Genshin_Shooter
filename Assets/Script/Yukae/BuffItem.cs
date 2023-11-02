using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuffItem : BuffBase
{
    [SerializeField] int shiled;
    [SerializeField] int damageUP;
    [SerializeField] float speedUp;

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<PlayerController>() == null) return;

        if(other.GetComponent<Status>() != null)
        {
            if (buffSetting.maxShield < other.GetComponent<BuffBase>().buffSetting.shield + shiled) other.GetComponent<BuffBase>().buffSetting.shield = buffSetting.maxShield;
            else AddShield(shiled);
            DamageUP(damageUP);
            StartCoroutine(DelayTime(speedUp, other.GetComponent<Status>().walkSpeed, other.GetComponent<Status>().runSpeed));
        }
    }
}
