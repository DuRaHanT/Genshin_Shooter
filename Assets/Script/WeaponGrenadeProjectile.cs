using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponGrenadeProjectile : MonoBehaviour
{
    [Header("Explosion Barrel")]
    [SerializeField] GameObject explosionPrefab;
    float explosionRadius => 10.0f;
    float explosionForce => 500.0f;
    float throwForce => 1000.0f;

    int explosionDamage;
    new Rigidbody rigidbody;

    GrenadeType grenadeType;

    public void Setup(int damage, Vector3 rotation, GrenadeType type)
    {
        rigidbody = GetComponent<Rigidbody>();
        rigidbody.AddForce(rotation * throwForce);

        explosionDamage = damage;
        grenadeType = type;
    }

    void OnCollisionEnter(Collision collision)
    {
        Instantiate(explosionPrefab, transform.position, transform.rotation);

        Collider[] colliders = Physics.OverlapSphere(transform.position, explosionRadius);

        foreach(Collider hit in colliders)
        {
            PlayerController player = hit.GetComponent<PlayerController>();
            if(player != null)
            {
                player.TakeDamage((int)(explosionDamage * 0.2f));
                player.GrenadeReaction(grenadeType);
                continue;
            }

            EnemyFSM enemy = hit.GetComponentInParent<EnemyFSM>();
            if(enemy != null)
            {
                enemy.TakeDamage(explosionDamage);
                enemy.GrenadeReaction(grenadeType);
                continue;
            }

            InteractionObject interaction = hit.GetComponent<InteractionObject>();
            if (interaction != null) interaction.TakeDamage(explosionDamage);

            Rigidbody rigidbody = hit.GetComponent<Rigidbody>();
            if(rigidbody != null) rigidbody.AddExplosionForce(explosionForce, transform.position, explosionRadius);

        }

        Destroy(gameObject);
    }
}
