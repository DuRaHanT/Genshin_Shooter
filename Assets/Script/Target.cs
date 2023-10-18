using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : InteractionObject
{
    [SerializeField] AudioClip clipTargetUp;
    [SerializeField] AudioClip clipTargetDown;
    float targetUpDelayTime => 2.5f;

    AudioSource audioSource;
    bool isPossibleHit = true;

    [SerializeField] GameObject Hpbar;

    void Awake() => audioSource = GetComponent<AudioSource>();

    void Update()
    {
        float normalizedHP = currentHP / maxHP;
        Hpbar.transform.localScale = new Vector3(normalizedHP, 0.1f, 0.1f);
        Hpbar.GetComponent<Renderer>().material.color = Color.Lerp(Color.red, Color.green, normalizedHP);

        Hpbar.transform.LookAt(transform.position + Camera.main.transform.forward);
    }

    public override void TakeDamage(int damage)
    {
        currentHP -= damage;

        if (currentHP <=0 && isPossibleHit == true)
        {
            isPossibleHit = false;
            Hpbar.SetActive(false);
            StartCoroutine("OnTargetDown");
        }
    }

    IEnumerator OnTargetDown()
    {
        audioSource.clip = clipTargetDown;
        audioSource.Play();

        yield return StartCoroutine(OnAnimation(0, 90));

        StartCoroutine("OnTargetUp");
    }

    IEnumerator OnTargetUp()
    {
        yield return new WaitForSeconds(targetUpDelayTime);

        audioSource.clip = clipTargetUp;
        audioSource.Play();

        yield return StartCoroutine(OnAnimation(90, 0));

        currentHP = maxHP;
        Hpbar.transform.localRotation = Quaternion.identity;
        Hpbar.SetActive(true);
        isPossibleHit = true;
        
    }

    IEnumerator OnAnimation(float start, float end)
    {
        float perent = 0;
        float current = 0;
        float time = 1;

        while(perent < 1)
        {
            current += Time.deltaTime;
            perent = current / time;

            transform.rotation = Quaternion.Slerp(Quaternion.Euler(start, 0, 0), Quaternion.Euler(end, 0, 0), perent);

            yield return null;
        }
    }
}
