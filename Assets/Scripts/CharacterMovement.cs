using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class CharacterMovement : MonoBehaviour
{
    [SerializeField, Range(1, 10)] float playerSpeed = 2;
    [SerializeField, Range(1, 10)] float rotateSpeed = 2;
    [SerializeField, Range(1, 10)] float jumpHeight = 1;
    [SerializeField, Range(1, 10)] float pushPower = 2;
    [SerializeField] Transform view;
    [SerializeField] Animator animator;
    //[SerializeField] Rig rig;

    // New parameters for Speed, YVelocity, and OnGround
    private float Speed => playerSpeed;
    private float YVelocity => playerVelocity.y;
    private bool OnGround => groundedPlayer;

    private CharacterController controller;
    private Vector3 playerVelocity;
    private bool groundedPlayer;
    private float gravityValue = -9.81f;

    // Reference to the Animator component for animations
    private Animator anim; 

    private void Start()
    {
        controller = gameObject.GetComponent<CharacterController>();
        

        // Get the Animator component
        anim = GetComponent<Animator>(); 
    }

    void Update()
    {
        groundedPlayer = controller.isGrounded;
        if (groundedPlayer && playerVelocity.y < 0)
        {
            playerVelocity.y = 0f;
        }

        Vector3 move = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        move = Vector3.ClampMagnitude(move, 1);
        // view space
        move = Quaternion.Euler(0, view.rotation.eulerAngles.y, 0) * move;

        controller.Move(move * Time.deltaTime * playerSpeed);

        if (move != Vector3.zero)
        {
            //gameObject.transform.forward = move;
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(move), Time.deltaTime * 3);
        }

        // Changes the height position of the player..
        if (Input.GetButtonDown("Jump") && groundedPlayer)
        {
            //playerVelocity.y += Mathf.Sqrt(jumpHeight * -3.0f * gravityValue);
            playerVelocity.y += Mathf.Sqrt(jumpHeight * -3.0f * Physics.gravity.y);
            anim.SetBool("OnGround", false);
        }

        if (groundedPlayer)
        {
            // When grounded, set OnGround to true
            anim.SetBool("OnGround", true);
        }

        playerVelocity.y += gravityValue * Time.deltaTime;
        controller.Move(playerVelocity * Time.deltaTime);

        // Update Animator parameters based on movement
        anim.SetFloat("Speed", move.magnitude); // Set Speed parameter based on movement
        anim.SetFloat("YVelocity", playerVelocity.y); // Set YVelocity parameter
    }


}