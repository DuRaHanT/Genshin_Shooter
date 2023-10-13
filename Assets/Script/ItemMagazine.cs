using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemMagazine : ItemBase
{
    [SerializeField] GameObject magazineEffectPrefab;
    [SerializeField] int increasePossessionAmmo;
    float rotateSpeed => 50;

    IEnumerator Start()
    {
        while(true)
        {
            transform.Rotate(Vector3.up * rotateSpeed * Time.deltaTime);

            yield return null;
        }
    }

    public override void Use(GameObject entity)
    {
        entity.GetComponentInChildren<WeaponSwitchSystem>().IncreasespossessionAmmo(WeaponType.Main, increasePossessionAmmo);

        Instantiate(magazineEffectPrefab, transform.position, Quaternion.identity);

        Destroy(gameObject);
    }

    public override void StartWeaponAction(int type = 0)
    {
    }

    public override void StopWeaponAction(int type = 0)
    {
    }

    public override void StartReload()
    {
    }
}
