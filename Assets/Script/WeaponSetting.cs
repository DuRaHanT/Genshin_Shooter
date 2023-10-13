
public enum WeaponName { AssaultRifle = 0, Revolver, Cobatknife, HandGrenade }

[System.Serializable]
public struct WeaponSetting
{
    public WeaponName weaponName;   // �����̸�
    public int damage;              // ���� ���ݷ�
    public int currentMagazine;     // ���� źâ ��
    public int maxMagazine;         // �ִ� źâ ��
    public int currentAmmo;         // ���� ź�� ��
    public int maxAmmo;             // �ִ� ź�� ��
    public float attackRate;        // ���� �ӵ�
    public float attackDistance;    // ���� ��Ÿ�
    public bool isAutomaticAttack;  // ���� ���� ����
}
