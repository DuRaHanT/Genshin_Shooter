using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DebuffBase : MonoBehaviour
{
    public DebuffSetting debuffSetting;
    bool isState = true;

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
        debuffSetting.isAir = !isState;
        debuffSetting.isWater = !isState;
    }
}
