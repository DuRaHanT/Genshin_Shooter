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
        for (int i = 0; i < grenades.Length; i++) grenadeTextes[i].text = $"<size=40>{grenades[i].CurrentGrenade}";
    }
}
