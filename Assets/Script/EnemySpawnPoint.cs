using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnPoint : MonoBehaviour
{
    float fadeSpeed => 4;
    MeshRenderer meshRenderer;

    void Awake() => meshRenderer = GetComponent<MeshRenderer>();

    void OnEnable() => StartCoroutine("OnFadeEffect");

    void OnDisable() => StopCoroutine("OnFadeEffect");

    IEnumerator OnFadeEffect()
    {
        while(true)
        {
            Color color = meshRenderer.material.color;
            color.a = Mathf.Lerp(1, 0, Mathf.PingPong(Time.time * fadeSpeed, 1));
            meshRenderer.material.color = color;

            yield return null;
        }
    }
}
