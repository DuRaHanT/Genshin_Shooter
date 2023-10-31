using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : DebuffBase
{
    private void OnTriggerEnter(Collider other)
    {
        if(other.GetComponent<DebuffBase>() != null)
        {
            switch(debuffSetting.debuffType)
            {
                case DebuffType.Burn:
                    other.GetComponent<DebuffBase>().debuffSetting.isBurn = true;
                    break;
                case DebuffType.Frezzing:
                    other.GetComponent<DebuffBase>().debuffSetting.isBurn = true;
                    break;
                case DebuffType.Lightning:
                    other.GetComponent<DebuffBase>().debuffSetting.isBurn = true;
                    break;
                case DebuffType.Air:
                    other.GetComponent<DebuffBase>().debuffSetting.isBurn = true;
                    break;
                case DebuffType.Water:
                    other.GetComponent<DebuffBase>().debuffSetting.isBurn = true;
                    break;
            }
        }
    }
}
