using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] CharacterController controller;
    [SerializeField] float speed = 11f;

    [SerializeField] float jumpLowHeight = 1.5f;
    [SerializeField] float jumpMediumHeight = 3f;
    [SerializeField] float jumpHighHeight = 4.5f;
    bool jumpLow;
    bool jumpMedium;
    bool jumpHigh;

    [SerializeField] float gravity = -9.81f; // -9.81
    Vector3 verticalVelocity = Vector3.zero;
    [SerializeField] LayerMask groundMask;
    bool isGrounded;

    Vector2 horizontalInput;

    private void Update()
    {
        isGrounded = Physics.CheckSphere(transform.position, 0.1f, groundMask);
        if (isGrounded)
        {
            verticalVelocity.y = 0;
        }

        Vector3 horizontalVelocity = (Vector3.right * horizontalInput.x + Vector3.forward * horizontalInput.y) * speed;
        controller.Move(horizontalVelocity * Time.deltaTime);

        if (jumpLow)
        {
            if (isGrounded)
            {
                verticalVelocity.y = Mathf.Sqrt(jumpLowHeight * -2f * gravity);
            }
            jumpLow = false;
        }

        if (jumpMedium)
        {
            if (isGrounded)
            {
                verticalVelocity.y = Mathf.Sqrt(jumpMediumHeight * -2f * gravity);
            }
            jumpMedium = false;
        }

        if (jumpHigh)
        {
            if (isGrounded)
            {
                verticalVelocity.y = Mathf.Sqrt(jumpHighHeight * -2f * gravity);
            }
            jumpHigh = false;
        }

        verticalVelocity.y += gravity * Time.deltaTime;
        controller.Move(verticalVelocity * Time.deltaTime);
    }

    public void ReceiveInput(Vector2 input)
    {
        horizontalInput = input;
    }

    public void OnJumpLowPressed()
    {
        jumpLow = true;
    }

    public void OnJumpMediumPressed()
    {
        jumpMedium = true;
    }

    public void OnJumpHighPressed()
    {
        jumpHigh = true;
    }
}
