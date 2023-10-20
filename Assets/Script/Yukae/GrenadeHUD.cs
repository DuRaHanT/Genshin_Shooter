using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GrenadeHUD : MonoBehaviour
{
    public GrenadeBase[] grenades;

    [SerializeField] TextMeshProUGUI[] grenadeTextes;

    public void SetupAllGrenade(GrenadeBase[] grenades)
    {
        for (int i = 0; i < grenades.Length; i++) UpdateGrenade(grenades[i].CurrentGrenade);
    }

    void UpdateGrenade(int currentGrenade)
    {
        for (int i = 0; i < grenadeTextes.Length; i++) grenadeTextes[i].text = $"<size=40>{currentGrenade}";
    }
}
