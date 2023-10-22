using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : BulletBase
{
    public int BulletDamege => bulletSetting.bulletDamage;
    public int currentBullet => bulletSetting.currentBullet;
    public int possessionBullet => bulletSetting.possessionBullet;
}
