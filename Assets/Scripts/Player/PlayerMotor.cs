using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMotor : MonoBehaviour
{
    CharacterController controller;
    Vector3 playerVelocity;
    bool isGrounded;
    bool crouching;
    bool lerpCrouch;
    bool sprinting;

    float crouchTimer;
    float speed = 5f;
    float gravity => -9.8f;
    float jumpHeight => 3f;

    void Awake() => controller = GetComponent<CharacterController>();

    void FixedUpdate()
    {
        isGrounded = controller.isGrounded;    
        if(lerpCrouch)
        {
            crouchTimer += Time.deltaTime;
            float p = crouchTimer / 1;
            p *= p;
            if (crouching) controller.height = Mathf.Lerp(controller.height, 1, p);
            else controller.height = Mathf.Lerp(controller.height, 2, p);

            if(p > 1)
            {
                lerpCrouch = false;
                crouchTimer = 0f;
            }
        }
    }

    public void ProcessMove(Vector2 input)
    {
        Vector3 moveDirection = Vector3.zero;
        moveDirection.x = input.x;
        moveDirection.z = input.y;
        controller.Move(transform.TransformDirection(moveDirection) * speed * Time.deltaTime);
        playerVelocity.y += gravity * Time.deltaTime;
        if (isGrounded && playerVelocity.y < 0) playerVelocity.y = -2f;
        controller.Move(playerVelocity * Time.deltaTime);
    }

    public void Jump()
    {
        if(isGrounded)
        {
            playerVelocity.y = Mathf.Sqrt(jumpHeight * -3.0f * gravity);
        }
    }

    public void Crouch()
    {
        crouching = !crouching;
        crouchTimer = 0;
        lerpCrouch = true;
    }

    public void Sprint()
    {
        sprinting = !sprinting;
        if (sprinting) speed = 8;
        else speed = 5;
    }
}
