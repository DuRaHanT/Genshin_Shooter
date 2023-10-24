using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DebuffBase : MonoBehaviour
{
    DebuffSetting debuffSetting;

    Dictionary<string, Action> reactions = new Dictionary<string, Action>();

    void Reaction()
    {
        reactions["burn_freezing"] = BurnFreezingReaction;
        reactions["burn_lightning"] = BurnLightningReaction;
        reactions["burn_air"] = BurnAirReaction;
        reactions["burn_water"] = BurnWaterReaction;

        reactions["air_freezing"] = AirFreezingReaction;
        reactions["air_lightning"] = AirLightningReaction;
        reactions["air_water"] = AirWaterReaction;

        reactions["lightning_freezing"] = LightningFreezingReaction;
        reactions["lightning_water"] = lightningWaterReaction;

        reactions["freezing_water"] = freezingWaterReaction;
    }

    public void HandleDebuff(string debuff1, string debuff2)
    {
        string key = debuff1 + "_" + debuff2;
        if (reactions.ContainsKey(key))
        {
            reactions[key].Invoke();
        }
        else
        {
            Debug.LogWarning("해당 디버프 조합에 대한 반응이 없습니다: " + key);
        }
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

    void lightningWaterReaction()
    {
        Debug.Log("lightning & water");
    }

    void freezingWaterReaction()
    {
        Debug.Log("freezing & water");
    }
}
