using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleAutoDestroyerByTime : MonoBehaviour
{
    ParticleSystem particle;

    void Awake() => particle = GetComponent<ParticleSystem>();

    void Update()
    {
        if (particle.isPlaying == false) Destroy(gameObject);   
    }
}
