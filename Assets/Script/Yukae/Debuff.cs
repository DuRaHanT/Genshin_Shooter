using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Debuff : MonoBehaviour
{
    DebuffSetting debuffSetting;

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("ImpactEnemy"))
        {
            other.GetComponent<GameObject>().SetActive(true);
        }
    }
}
