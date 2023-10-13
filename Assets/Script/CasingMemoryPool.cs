using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CasingMemoryPool : MonoBehaviour
{
    [SerializeField] GameObject casingPrefab;
    MemoryPool memoryPool;

    void Awake() => memoryPool = new MemoryPool(casingPrefab);

    public void SpawnCasing(Vector3 position, Vector3 direction)
    {
        GameObject item = memoryPool.ActivatePoolItem();
        item.transform.position = position;
        item.transform.rotation = Random.rotation;
        item.GetComponent<Casing>().Setup(memoryPool, direction);
    }
}
