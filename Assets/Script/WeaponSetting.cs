
public enum WeaponName { AssaultRifle = 0, Revolver, Cobatknife, HandGrenade }

[System.Serializable]
public struct WeaponSetting
{
    public WeaponName weaponName;                       // 무기이름
    public int damage;                                  // 무기 기초 공격력
    public int currentAmmo;                             // 현재 탄약 수
    public int possessionAmmo;                          // 보유중인 탄약 수
    public int maxAmmo;                                 // 최대 탄약 수
    public float attackRate;                            // 공격 속도
    public float attackDistance;                        // 공격 사거리
    public bool isAutomaticAttack;                      // 연속 공격 여부
}
