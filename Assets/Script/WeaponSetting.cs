
public enum WeaponName { AssaultRifle = 0, Revolver, Cobatknife, HandGrenade }

[System.Serializable]
public struct WeaponSetting
{
    public WeaponName weaponName;                       // �����̸�
    public int baseDamage;                              // ���� ���� ���ݷ�
    public int Level;                                   // ���̵� ����
    public int damage => baseDamage * Level;            // ���� �� ���ݷ�
    public int currentAmmo;                             // ���� ź�� ��
    public int possessionAmmo;                          // �������� ź�� ��
    public int maxAmmo;                                 // �ִ� ź�� ��
    public int currentGrenade;                          // ���� ����ź ��
    public int maxGrenade;                              // �ִ� ����ź ��
    public float attackRate;                            // ���� �ӵ�
    public float attackDistance;                        // ���� ��Ÿ�
    public bool isAutomaticAttack;                      // ���� ���� ����
}
