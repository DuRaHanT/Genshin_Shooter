using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MapManager : MonoBehaviour
{
    [SerializeField] GameObject EnemyParent;
    [SerializeField] TextMeshProUGUI leftEnemyText;

    private void Update() => EnemyCheck();

    void EnemyCheck()
    {
        int index = 0;

        for(int i = 0; i < EnemyParent.transform.childCount; i++)
        {
            if (EnemyParent.transform.GetChild(i).gameObject.activeSelf == true) index++; 
        }

        leftEnemyText.text = "³²ÀºÀû : " + index;
    }

}
