
public enum DebuffType { Burn, Frezzing, Lightning, Air, Water, }

[System.Serializable]
public struct DebuffSetting
{
    public DebuffType debuffType;
    public bool isBurn;
    public bool isAir;
    public bool isLightning;
    public bool isFreezing;
    public bool isWater;
}
