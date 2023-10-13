using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ItemBase : WeaponBase
{
    public abstract void Use(GameObject entity);
}
