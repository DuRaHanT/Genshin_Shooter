using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemMagazine : ItemBase
{
    [SerializeField] GameObject magazineEffectPrefab;
    int increaseMagazine => 2;
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
        entity.GetComponentInChildren<WeaponSwitchSystem>().IncreasesMagazine(WeaponType.Main, increaseMagazine);

        Instantiate(magazineEffectPrefab, transform.position, Quaternion.identity);

        Destroy(gameObject);
    }
}
