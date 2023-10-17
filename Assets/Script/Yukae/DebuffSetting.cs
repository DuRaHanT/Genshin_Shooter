
public enum DebuffName { Defalut, Burn, Air, Lightning, Freezing }

[System.Serializable]
public struct DebuffSetting
{
    public DebuffName debufferName;
    public bool defalut;
    public bool burn;
    public bool Air;
    public bool Lightning;
    public bool Freezing;
}
