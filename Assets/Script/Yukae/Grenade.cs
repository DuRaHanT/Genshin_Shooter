using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grenade : GrenadeBase
{
    public int GrenadeDamege => grenadeSetting.grenadeDamage;
    public int currentGrenade => grenadeSetting.currentGrenade;
    public int possessionGrenade => grenadeSetting.possessionGrenade;

    public override void StartWeaponAction()
    {
    }
}
