using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponKnifeCollider : MonoBehaviour
{
    [SerializeField] ImpactMemoryPool impactMemoryPool;
    [SerializeField] Transform knifeTransform;

    new Collider collider;
    int damage;

    void Awake()
    {
        collider = GetComponent<Collider>();
        collider.enabled = false;
    }

    public void StartCollider(int damage)
    {
        this.damage = damage;
        collider.enabled = true;

        StartCoroutine("DisablebyTime", 0.1f);
    }

    IEnumerator DisablebyTime(float time)
    {
        yield return new WaitForSeconds(time);

        collider.enabled = false;
    }

    void OnTriggerEnter(Collider other)
    {
        impactMemoryPool.SpawnImpact(other, knifeTransform);

        if (other.CompareTag("ImpactEnemy")) other.GetComponentInParent<EnemyFSM>().TakeDamage(damage);
        else if (other.CompareTag("InteractionObject")) other.GetComponent<InteractionObject>().TakeDamage(damage);
    }
}
