using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementTransform : MonoBehaviour
{
    [SerializeField] float moveSpeed = 0.0f;
    [SerializeField] Vector3 moveDirection = Vector3.zero;

    void Update() => transform.position += moveDirection * moveSpeed * Time.deltaTime;

    public void MoveTo(Vector3 direction) => moveDirection = direction;
}
