public enum BulletName { Nomal, Burn, Lightning, Freezing, Air, Water, None }

[System.Serializable]
public struct BulletSetting
{
    public BulletName ability;
    public int bulletDamage;
    public int currentBullet;
    public int possessionBullet;
    public int maxBullet;
}
