using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public GameManager gameManager;

    public float moveSpeed = 5f;
    public float rotationSpeed = 10f;

    private Rigidbody rb;
    private Vector2 moveInput;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (!gameManager.isPlaying)
        {
            moveInput = Vector2.zero;
            return;
        }

        float horizontal = 0f;
        float vertical = 0f;

        if (Keyboard.current.aKey.isPressed)
            horizontal = -1f;

        if (Keyboard.current.dKey.isPressed)
            horizontal = 1f;

        if (Keyboard.current.sKey.isPressed)
            vertical = -1f;

        if (Keyboard.current.wKey.isPressed)
            vertical = 1f;

        moveInput = new Vector2(horizontal, vertical);
    }

    void FixedUpdate()
    {
        if (!gameManager.isPlaying)
            return;

        Vector3 movement = new Vector3(
            moveInput.x,
            0f,
            moveInput.y
        ).normalized;

        // Move the player
        rb.MovePosition(
            rb.position +
            movement * moveSpeed * Time.fixedDeltaTime
        );

        // Face the direction of movement
        FaceMovementDirection(movement);
    }

    void FaceMovementDirection(Vector3 moveDirection)
    {
        if (moveDirection.sqrMagnitude > 0.001f)
        {
            // Calculate the direction the player is moving
            Quaternion targetRotation =
                Quaternion.LookRotation(moveDirection);

            // Rotate 180 degrees to correct backward-facing astronaut
            targetRotation *= Quaternion.Euler(0f, 180f, 0f);

            // Smoothly rotate the player
            Quaternion smoothRotation =
                Quaternion.Slerp(
                    rb.rotation,
                    targetRotation,
                    rotationSpeed * Time.fixedDeltaTime
                );

            rb.MoveRotation(smoothRotation);
        }
    }
}