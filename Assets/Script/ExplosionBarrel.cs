using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionBarrel : InteractionObject
{
    [Header("Explosion Barrl")]
    [SerializeField] GameObject explosionPrefab;
    float explosionDelayTime => 0.3f;
    float explosionRadius => 10.0f;
    float explosionForce => 1000.0f;

    bool isExplode = false;

    public override void TakeDamage(int damage)
    {
        currentHP -= damage;

        if (currentHP <= 0 && isExplode == false) StartCoroutine("ExplodeBarrel");
    }

    IEnumerator ExplodeBarrel()
    {
        yield return new WaitForSeconds(explosionDelayTime);

        isExplode = true;

        Bounds bounds = GetComponent<Collider>().bounds;
        Instantiate(explosionPrefab, new Vector3(bounds.center.x, bounds.min.y, bounds.center.z), transform.rotation);

        Collider[] colliders = Physics.OverlapSphere(transform.position, explosionRadius);
        foreach(Collider hit in colliders)
        {
            PlayerController player = hit.GetComponent<PlayerController>();
            if(player != null)
            {
                player.TakeDamage(50);
                player.GetComponent<DebuffBase>().debuffSetting.isBurn = true;
                continue;
            }

            EnemyFSM enemy = hit.GetComponent<EnemyFSM>();
            if(enemy != null)
            {
                enemy.TakeDamage(300);
                enemy.GetComponent<DebuffBase>().debuffSetting.isBurn = true;
                continue;
            }

            InteractionObject interaction = hit.GetComponent<InteractionObject>();
            if (interaction != null) interaction.TakeDamage(300);

            Rigidbody rigidbody = hit.GetComponent<Rigidbody>();
            if (rigidbody != null) rigidbody.AddExplosionForce(explosionForce, transform.position, explosionRadius);
        }

        Destroy(gameObject);
    }
}
