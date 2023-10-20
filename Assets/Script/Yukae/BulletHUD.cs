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
        for (int i = 0; i < bullets.Length; i++) UpdateBullet(bullets[i].CurrentBullet, bullets[i].CurrentpossessionBullet);
    }

    void UpdateBullet(int currentBullet, int maxBullet )
    {
        for (int i = 0; i < bulletTextes.Length; i++) bulletTextes[i].text = $"<size=40>{currentBullet}/</size>{maxBullet}";
    }
}
