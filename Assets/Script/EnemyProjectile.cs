using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyProjectile : MonoBehaviour
{
    MovementTransform movement;
    [SerializeField] float projectileDistance => 30;
    [SerializeField] int damage = 5;
    DebuffType type;

    public void Setup(Vector3 position, DebuffType debuffType)
    {
        movement = GetComponent<MovementTransform>();
        type = debuffType;
        StartCoroutine("OnMove", position);

    }

    IEnumerator OnMove(Vector3 targetPostition)
    {
        Vector3 start = transform.position;

        movement.MoveTo((targetPostition - transform.position).normalized);

        while(true)
        {
            if(Vector3.Distance(transform.position, start) >= projectileDistance)
            {
                Destroy(gameObject);

                yield break;
            }
            yield return null;
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            other.GetComponent<PlayerController>().TakeDamage(damage);
            other.GetComponent<PlayerController>().EnemyReaction(type);
            Destroy(gameObject);
        }
    }
}
