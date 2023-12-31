using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Impact : MonoBehaviour
{
    ParticleSystem particle;
    MemoryPool memoryPool;

    private void Awake()
    {
        particle = GetComponent<ParticleSystem>();
    }

    public void Setup(MemoryPool pool)
    {
        memoryPool = pool;
    }

    void Update()
    {
        if (particle.isPlaying == false) memoryPool.DeactivatePoolItem(gameObject);
    }
}
