using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuffItem : BuffBase
{
    [SerializeField] int shiled;
    [SerializeField] int damageUP;
    [SerializeField] float speedUp;
    float moveDistance => 0.2f;
    float pingpongSpeed => 0.5f;
    float rotateSpeed => 50;

    IEnumerator Start()
    {
        float y = transform.position.y;

        while (true)
        {
            transform.Rotate(Vector3.up * rotateSpeed * Time.deltaTime);

            Vector3 position = transform.position;
            position.y = Mathf.Lerp(y, y + moveDistance, Mathf.PingPong(Time.time * pingpongSpeed, 1));
            transform.position = position;

            yield return null;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<PlayerController>() == null) return;

        if(other.GetComponent<Status>() != null)
        {
            if (buffSetting.maxShield < other.GetComponent<BuffBase>().buffSetting.shield + shiled) other.GetComponent<BuffBase>().buffSetting.shield = buffSetting.maxShield;
            else AddShield(shiled);
            DamageUP(damageUP);
            ResistanceUp();
            StartCoroutine(DelayTime(speedUp, other.GetComponent<Status>().walkSpeed, other.GetComponent<Status>().runSpeed));
        }

        this.GetComponent<GameObject>().SetActive(false);
    }
}
