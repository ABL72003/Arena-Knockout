//OpenAI Credit
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public float moveSpeed = 2f;
    public float stoppingDistance = 1.2f;

    private Transform player;
    private Rigidbody rb;

    void Start()
    {
        GameObject playerObject =
            GameObject.FindGameObjectWithTag("Player");

        if (playerObject != null)
        {
            player = playerObject.transform;
        }

        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        if (player == null || rb == null)
            return;

        // Calculate direction toward player
        Vector3 direction =
            player.position - transform.position;

        // Keep movement horizontal
        direction.y = 0f;

        // Stop moving when close to player
        if (direction.magnitude <= stoppingDistance)
            return;

        direction.Normalize();

        // Move toward player using physics
        Vector3 newPosition =
            rb.position + direction * moveSpeed * Time.fixedDeltaTime;

        rb.MovePosition(newPosition);
    }
}
