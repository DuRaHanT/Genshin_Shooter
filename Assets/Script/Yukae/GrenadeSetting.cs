public enum GrenadeName { Air, Water, None }

[System.Serializable]
public class GrenadeSetting 
{
    public GrenadeName ability;
    public int grenadeDamage;
    public int currentGrenade;
    public int possessionGrenade;
}
