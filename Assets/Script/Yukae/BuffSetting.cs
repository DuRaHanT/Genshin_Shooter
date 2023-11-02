
public enum ResistanceType { Nomal, Burn, Lightning, Freezing, Air, Water }

[System.Serializable]
public class BuffSetting
{
    public ResistanceType resistanceType;
    public float resistance;
    public bool[] typeImmune;
    public int shield;
    public int maxShield => 100;
    public float speedUp;
    public int damageUP;
}