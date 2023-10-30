
public enum ResistanceType { Nomal, Burn, Lightning, Freezing, Air, Water }

public class BuffSetting
{
    public ResistanceType resistanceType;
    public float resistance;
    public bool nomalImmune;
    public bool burnImmune;
    public bool lightningimmune;
    public bool freezingimmune;
    public bool airimmune;
    public bool waterimmune;
    public int shield;
    public int maxHpUP;
    public int damageUP;
}