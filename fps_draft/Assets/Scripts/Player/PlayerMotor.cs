using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlayerMotor : MonoBehaviour
{
    private CharacterController controller;
    private Vector3 playerVelocity;
    public float speed = 5.0f;
    private bool isGrounded;
    public float gravity = -9.8f;
    public float jumpHeight = 1f;

    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    
    public void Update()
    {
        isGrounded = controller.isGrounded;
        
    }

    //receive input from inputmanager.cs and apply them to character controller
    public void ProcessMove(Vector2 input)
    {
        Vector3 moveDirection = Vector3.zero;
        moveDirection.x = input.x;
        moveDirection.z = input.y;
        controller.Move(transform.TransformDirection(moveDirection) * speed * Time.deltaTime);
        playerVelocity.y += gravity * Time.deltaTime;
        if (isGrounded && playerVelocity.y < 0)
        {
            playerVelocity.y = -2f;
        }
        controller.Move(playerVelocity * Time.deltaTime);
        Debug.Log(playerVelocity.y);    
    }

    public void Jump()
    {
        if (isGrounded)
        {
            playerVelocity.y = Mathf.Sqrt(jumpHeight * -1f * gravity);
        }
    }

}
