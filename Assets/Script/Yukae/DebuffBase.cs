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
        Debug.Log("burn & freezing");

    }

    void BurnLightningReaction()
    {
        Debug.Log("burn & lightning");

    }

    void BurnAirReaction()
    {
        Debug.Log("burn & air");

    }

    void BurnWaterReaction()
    {
        Debug.Log("burn & water");

    }

    void AirFreezingReaction()
    {
        Debug.Log("air & freezing");

    }

    void AirLightningReaction()
    {
        Debug.Log("air & lightning");

    }

    void AirWaterReaction()
    {
        Debug.Log("air & water");

    }

    void LightningFreezingReaction()
    {
        Debug.Log("lightning & freezing");

    }

    void LightningWaterReaction()
    {
        Debug.Log("lightning & water");

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
        debuffIcon.color = new Color(debuffIcon.color.r, debuffIcon.color.g, debuffIcon.color.b, zero);
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
        debuffIcon.color = new Color(debuffIcon.color.r, debuffIcon.color.g, debuffIcon.color.b, one);
        debuffIcon.sprite = debuffIconImages[(int)DebuffType.Lightning];

        StartCoroutine("DelayTime");
    }

    void Water()
    {
        debuffIcon.color = new Color(debuffIcon.color.r, debuffIcon.color.g, debuffIcon.color.b, one);
        debuffIcon.sprite = debuffIconImages[(int)DebuffType.Water];

        StartCoroutine("DelayTime");
    }
}
