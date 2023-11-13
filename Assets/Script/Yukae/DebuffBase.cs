using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DebuffBase : MonoBehaviour
{
    public DebuffSetting debuffSetting;

    [SerializeField] Sprite[] debuffIconImages;
    [SerializeField] Image debuffIcon;

    bool isState = true;
    bool isSlow;
    float delayTime => 3.0f;
    float slowSpeed => 0.5f;
    float maxHealthProportion => 0.1f; // 최대 체력 비례
    float zero => 0;
    float one => 1;
    float two => 2;
    float detectionRange => 10f;
    int splashDamage => 20;
    int additional_Damage => 25;

    float thisRunSpeed;
    float thiswalkSpeed;
    float Timer;

    Status status;

    void Awake()
    {
        status = this.GetComponent<Status>();

        thisRunSpeed = status.runSpeed;
        thiswalkSpeed = status.walkSpeed;

        ResetDebuff();
    }

    public void UpdateReaction()
    {
        if (debuffSetting.isBurn == isState && debuffSetting.isFreezing == isState) BurnFreezingReaction();
        else if (debuffSetting.isBurn == isState && debuffSetting.isLightning == isState) BurnLightningReaction();
        else if (debuffSetting.isBurn == isState && debuffSetting.isAir == isState) BurnAirReaction();
        else if (debuffSetting.isBurn == isState && debuffSetting.isWater == isState) BurnWaterReaction();
        else if (debuffSetting.isAir == isState && debuffSetting.isFreezing == isState) AirFreezingReaction();
        else if (debuffSetting.isAir == isState && debuffSetting.isLightning == isState) AirLightningReaction();
        else if (debuffSetting.isAir == isState && debuffSetting.isWater == isState) AirWaterReaction();
        else if (debuffSetting.isLightning == isState && debuffSetting.isFreezing == isState) LightningFreezingReaction();
        else if (debuffSetting.isLightning == isState && debuffSetting.isWater == isState) LightningWaterReaction();
        else if (debuffSetting.isFreezing == isState && debuffSetting.isWater == isState) FreezingWaterReaction();
        
    }

    void BurnFreezingReaction()
    {
        status.buff.buffSetting.resistance = two;

        ResetDebuff();
    }

    void BurnLightningReaction()
    {
        Vector3 thisObjectPosition = transform.position;

        Collider[] colliders = Physics.OverlapSphere(thisObjectPosition, detectionRange);

        foreach (Collider hit in colliders)
        {
            PlayerController player = hit.GetComponent<PlayerController>();
            if (player != null)
            {
                player.TakeDamage(splashDamage);
                continue;
            }

            EnemyFSM enemy = hit.GetComponent<EnemyFSM>();
            if (enemy != null)
            {
                enemy.TakeDamage(splashDamage);
                continue;
            }

            InteractionObject interaction = hit.GetComponent<InteractionObject>();
            if (interaction != null) interaction.TakeDamage(splashDamage);
        }
        ResetDebuff();
    }

    void BurnAirReaction()
    {
        Vector3 thisObjectPosition = transform.position;

        Collider[] colliders = Physics.OverlapSphere(thisObjectPosition, detectionRange);

        for (int i = 0; i < colliders.Length; i++)
        {
            if (Vector3.Distance(thisObjectPosition, colliders[i].transform.position) <= detectionRange)
            {
                colliders[i].GetComponent<DebuffBase>().debuffSetting.isBurn = isState;
            }
        }
    }

    void BurnWaterReaction()
    {
        status.additional_Damage = additional_Damage;

        ResetDebuff();
    }

    void AirFreezingReaction()
    {
        Vector3 thisObjectPosition = transform.position;

        Collider[] colliders = Physics.OverlapSphere(thisObjectPosition, detectionRange);

        for (int i = 0; i < colliders.Length; i++)
        {
            if (Vector3.Distance(thisObjectPosition, colliders[i].transform.position) <= detectionRange)
            {
                colliders[i].GetComponent<DebuffBase>().debuffSetting.isFreezing = isState;
            }
        }
    }

    void AirLightningReaction()
    {
        Vector3 thisObjectPosition = transform.position;

        Collider[] colliders = Physics.OverlapSphere(thisObjectPosition, detectionRange);

        for (int i = 0; i < colliders.Length; i++)
        {
            if (Vector3.Distance(thisObjectPosition, colliders[i].transform.position) <= detectionRange)
            {
                colliders[i].GetComponent<DebuffBase>().debuffSetting.isLightning = isState;
            }
        }
    }

    void AirWaterReaction()
    {
        Vector3 thisObjectPosition = transform.position;

        Collider[] colliders = Physics.OverlapSphere(thisObjectPosition, detectionRange);

        for (int i = 0; i < colliders.Length; i++)
        {
            if (Vector3.Distance(thisObjectPosition, colliders[i].transform.position) <= detectionRange)
            {
                colliders[i].GetComponent<DebuffBase>().debuffSetting.isWater = isState;
            }
        }
    }

    void LightningFreezingReaction()
    {
        status.buff.ResistanceDown();

        StartCoroutine("DelayTime");
    }

    void LightningWaterReaction()
    {
        Vector3 thisObjectPosition = transform.position;

        Collider[] colliders = Physics.OverlapSphere(thisObjectPosition, detectionRange);

        for (int i = 0; i < colliders.Length; i++)
        {
            if (Vector3.Distance(thisObjectPosition, colliders[i].transform.position) <= detectionRange && colliders[i].GetComponent<DebuffBase>().debuffSetting.isWater == isState)
            {
                colliders[i].GetComponent<DebuffBase>().debuffSetting.isLightning = isState;
            }
        }

        StartCoroutine("DelayTime");
    }

    void FreezingWaterReaction()
    {
        Debug.Log("freezing & water");
        status.runSpeed = zero;
        status.walkSpeed = zero;

        StartCoroutine("DelayTime");
    }

    IEnumerator DelayTime()
    {
        yield return new WaitForSeconds(delayTime);

        ResetDebuff();
        ResetState();
    }

    void ResetDebuff()
    {
        debuffSetting.isBurn = !isState;
        debuffSetting.isFreezing = !isState;
        debuffSetting.isLightning = !isState;
        debuffSetting.isAir = !isState;
        debuffSetting.isWater = !isState;
        isSlow = !isState;
        if(CompareTag("Player")) debuffIcon.color = new Color(debuffIcon.color.r, debuffIcon.color.g, debuffIcon.color.b, zero);
    }

    void ResetState()
    {
        status.runSpeed = thisRunSpeed;
        status.walkSpeed = thiswalkSpeed;
    }

    public void Debuff()
    {
        if (debuffSetting.isBurn) Burn();
        else if (debuffSetting.isFreezing) Freezing();
        else if (debuffSetting.isAir) Air();
        else if (debuffSetting.isLightning) Lightning();
        else if (debuffSetting.isWater) Water();
    }

    void Burn()
    {
        debuffIcon.color = new Color(debuffIcon.color.r, debuffIcon.color.g, debuffIcon.color.b, one);
        debuffIcon.sprite = debuffIconImages[(int)DebuffType.Burn];

        if (status.currentHP <= zero) return;

        int dotDeal = (int)((float)status.currentHP * maxHealthProportion);

        Timer += Time.deltaTime;

        if(Timer >= one)
        {
            if (dotDeal < one) dotDeal = (int)one;

            status.DecreaseHp(dotDeal);

            Timer = zero;
        }

        StartCoroutine("DelayTime");
    }

    void Freezing()
    {
        debuffIcon.color = new Color(debuffIcon.color.r, debuffIcon.color.g, debuffIcon.color.b, one);
        debuffIcon.sprite = debuffIconImages[(int)DebuffType.Frezzing];

        if (!isSlow)
        {
            status.runSpeed = status.runSpeed * slowSpeed;
            status.walkSpeed = status.walkSpeed * slowSpeed;

            isSlow = isState;
        }

        StartCoroutine("DelayTime");
    }

    void Air()
    {
        debuffIcon.color = new Color(debuffIcon.color.r, debuffIcon.color.g, debuffIcon.color.b, one);
        debuffIcon.sprite = debuffIconImages[(int)DebuffType.Air];

        StartCoroutine("DelayTime");
    }

    void Lightning()
    {
        int randomDeal = (int)UnityEngine.Random.Range(one, splashDamage);

        debuffIcon.color = new Color(debuffIcon.color.r, debuffIcon.color.g, debuffIcon.color.b, one);
        debuffIcon.sprite = debuffIconImages[(int)DebuffType.Lightning];

        Timer += Time.deltaTime;

        if (Timer >= one)
        {
            status.runSpeed = zero;
            status.walkSpeed = zero;

            status.DecreaseHp(randomDeal);

            Timer = zero;
        }

        StartCoroutine("DelayTime");
    }

    void Water()
    {
        debuffIcon.color = new Color(debuffIcon.color.r, debuffIcon.color.g, debuffIcon.color.b, one);
        debuffIcon.sprite = debuffIconImages[(int)DebuffType.Water];

        StartCoroutine("DelayTime");
    }
}
