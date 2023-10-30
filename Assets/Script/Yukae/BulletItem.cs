using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletItem : BulletBase
{
    [SerializeField] GameObject magazineEffectPrefab;
    [SerializeField] int increasePossessionAmmo;
    float rotateSpeed => 50;

    IEnumerator Start()
    {
        while (true)
        {
            transform.Rotate(Vector3.up * rotateSpeed * Time.deltaTime);

            yield return null;
        }
    }

    public void Use(GameObject entity)
    {
        entity.GetComponentInChildren<BulletSwitch>().IncreasespossessionAmmo(BulletType, increasePossessionAmmo);

        Instantiate(magazineEffectPrefab, transform.position, Quaternion.identity);

        Destroy(gameObject);
    }
}
