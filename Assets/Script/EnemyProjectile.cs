using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum PlayType { Burn, Air, Lightning, Freezing, Water, }

public class EnemyProjectile : MonoBehaviour
{
    MovementTransform movement;
    float projectileDistance => 30;
    [SerializeField] int damage = 5;
    PlayType playType;

    public void Setup(Vector3 position)
    {
        movement = GetComponent<MovementTransform>();

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
            //Debug.Log("Player Hit");
            other.GetComponent<PlayerController>().TakeDamage(damage);
            other.GetComponent<PlayerController>().EnemyReaction(playType);
            Destroy(gameObject);
        }
    }
}
