using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class MovementCharacterController : MonoBehaviour
{
    float moveSpeed;
    Vector3 moveForce;

    float jumpForce => 10;
    float gravity = -20;

    CharacterController characterController;

    public float MoveSpeed
    {
        set => moveSpeed = Mathf.Max(0, value);
        get => moveSpeed;
    }

    void Awake() => characterController = GetComponent<CharacterController>();

    void Update()
    {
        if (!characterController.isGrounded) moveForce.y += gravity * Time.deltaTime;

        characterController.Move(moveForce * Time.deltaTime);
    }
    
    public void MoveTo(Vector3 direction)
    {
        direction = transform.rotation * new Vector3(direction.x, 0, direction.z);

        moveForce = new Vector3(direction.x * moveSpeed, moveForce.y, direction.z * moveSpeed);
    }

    public void Jump()
    {
        if (characterController.isGrounded) moveForce.y = jumpForce;
        
    }
}
