using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class BulletHUD : MonoBehaviour
{
    public BulletBase[] bulletes;

    [SerializeField] TextMeshProUGUI[] bulletTextes;

    public void SetupAllBullet(BulletBase[] bullets)
    {
        for (int i = 0; i < bullets.Length; i++) bulletTextes[i].text = $"<size=40>{bullets[i].CurrentBullet}/</size>{ bullets[i].CurrentpossessionBullet}";
    }
}
