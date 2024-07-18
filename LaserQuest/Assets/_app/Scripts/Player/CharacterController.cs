using System;
using UnityEngine;
using UnityEngine.InputSystem;

namespace _app.Scripts.Player
{
    public class CharacterController : MonoBehaviour
    {
        [Header("Movement Components")]
        public float movementSpeed;
        public Vector2 movementVector;
        public Vector3 jumpForce;
        public bool crouching;

        [Header("Player Components")]
        public Rigidbody rb;
        public Camera playerCamera;
        public PlayerInput pInput;

        [Header("Ground Check Components")]
        public Transform playerFeet;
        public float groundDistance = 0.4f;
        public LayerMask groundMask;

        private bool isGrounded;

        private void Start()
        {
            rb = GetComponent<Rigidbody>();
            rb.freezeRotation = true; // Freeze rotation to prevent falling over
        }

        private void Update()
        {
            // Check if player is grounded
            isGrounded = Physics.CheckSphere(playerFeet.position, groundDistance, groundMask);

            // Handle Jumping
            if (isGrounded && Input.GetKeyDown(KeyCode.Space))
            {
                PlayerJump();
            }

            // Handle Movement
            movementVector.x = Input.GetAxis("Horizontal");
            movementVector.y = Input.GetAxis("Vertical");

            PlayerMovement(movementVector);
        }

        private void PlayerJump()
        {
            rb.AddForce(jumpForce, ForceMode.Impulse);
        }

        private void PlayerMovement(Vector2 movement)
        {
            Vector3 move = transform.right * movement.x + transform.forward * movement.y;
            rb.MovePosition(rb.position + move * movementSpeed * Time.deltaTime);
        }
    }
}