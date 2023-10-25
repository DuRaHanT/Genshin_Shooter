
public enum ResistanceType { Nomal, Burn, Lightning, Freezing, Air, Water }

public class BuffSetting
{
    public ResistanceType resistanceType;
    public float nomalResistance;
    public float burnResistance;
    public float lightningResistance;
    public float freezingResistance;
    public float airResistance;
    public float waterResistance;
    public int shield;
    public int maxHpUP;
    public int damageUP;
}