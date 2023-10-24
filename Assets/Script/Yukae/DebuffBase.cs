using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DebuffBase : MonoBehaviour
{
    protected DebuffSetting debuffSetting;
    bool isState = true;

    //Dictionary<string, Action> reactions = new Dictionary<string, Action>();

    //void Reaction()
    //{
    //    reactions["burn_freezing"] = BurnFreezingReaction;
    //    reactions["burn_lightning"] = BurnLightningReaction;
    //    reactions["burn_air"] = BurnAirReaction;
    //    reactions["burn_water"] = BurnWaterReaction;

    //    reactions["air_freezing"] = AirFreezingReaction;
    //    reactions["air_lightning"] = AirLightningReaction;
    //    reactions["air_water"] = AirWaterReaction;

    //    reactions["lightning_freezing"] = LightningFreezingReaction;
    //    reactions["lightning_water"] = lightningWaterReaction;

    //    reactions["freezing_water"] = freezingWaterReaction;
    //}

    //public void HandleDebuff(string debuff1, string debuff2)
    //{
    //    string key = debuff1 + "_" + debuff2;
    //    if (reactions.ContainsKey(key))
    //    {
    //        reactions[key].Invoke();
    //    }
    //    else
    //    {
    //        Debug.LogWarning("해당 디버프 조합에 대한 반응이 없습니다: " + key);
    //    }
    //}

    public void Reaction()
    {
        if (debuffSetting.isBurn == isState && debuffSetting.isFreezing == isState) BurnFreezingReaction();
        else if (debuffSetting.isBurn == isState && debuffSetting.isLightning == isState) BurnLightningReaction();
        else if (debuffSetting.isBurn == isState && debuffSetting.isAur == isState) BurnAirReaction();
        else if (debuffSetting.isBurn == isState && debuffSetting.isWater == isState) BurnWaterReaction();
        else if (debuffSetting.isAur == isState && debuffSetting.isFreezing == isState) AirFreezingReaction();
        else if (debuffSetting.isAur == isState && debuffSetting.isLightning == isState) AirLightningReaction();
        else if (debuffSetting.isAur == isState && debuffSetting.isWater == isState) AirWaterReaction();
        else if (debuffSetting.isLightning == isState && debuffSetting.isFreezing == isState) LightningFreezingReaction();
        else if (debuffSetting.isLightning == isState && debuffSetting.isWater == isState) LightningWaterReaction();
        else if (debuffSetting.isFreezing == isState && debuffSetting.isWater == isState) FreezingWaterReaction();
    }

    void BurnFreezingReaction()
    {
        Debug.Log("burn & freezing");
        ResetDebuff();
    }

    void BurnLightningReaction()
    {
        Debug.Log("burn & lightning");
        ResetDebuff();
    }

    void BurnAirReaction()
    {
        Debug.Log("burn & air");
        ResetDebuff();
    }

    void BurnWaterReaction()
    {
        Debug.Log("burn & water");
        ResetDebuff();
    }

    void AirFreezingReaction()
    {
        Debug.Log("air & freezing");
        ResetDebuff();
    }

    void AirLightningReaction()
    {
        Debug.Log("air & lightning");
        ResetDebuff();
    }

    void AirWaterReaction()
    {
        Debug.Log("air & water");
        ResetDebuff();
    }

    void LightningFreezingReaction()
    {
        Debug.Log("lightning & freezing");
        ResetDebuff();
    }

    void LightningWaterReaction()
    {
        Debug.Log("lightning & water");
        ResetDebuff();
    }

    void FreezingWaterReaction()
    {
        Debug.Log("freezing & water");
        ResetDebuff();
    }

    void ResetDebuff()
    {
        debuffSetting.isBurn = !isState;
        debuffSetting.isFreezing = !isState;
        debuffSetting.isLightning = !isState;
        debuffSetting.isAur = !isState;
        debuffSetting.isWater = !isState;
    }
}
