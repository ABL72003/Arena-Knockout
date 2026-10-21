//OpenAI
using UnityEngine;

public class EnemyPush : MonoBehaviour
{
    public float pushForce = 8f;
    public float pushCooldown = 1.5f;

    private float nextPushTime = 0f;

    void OnCollisionStay(Collision collision)
    {
        // Only push the player
        if (!collision.gameObject.CompareTag("Player"))
            return;

        // Check cooldown
        if (Time.time < nextPushTime)
            return;

        Rigidbody playerRb =
            collision.gameObject.GetComponent<Rigidbody>();

        if (playerRb == null)
            return;

        // Calculate direction away from enemy
        Vector3 direction =
            playerRb.position - transform.position;

        direction.y = 0f;
        direction.Normalize();

        // Push player backward
        playerRb.AddForce(
            direction * pushForce,
            ForceMode.Impulse
        );

        nextPushTime = Time.time + pushCooldown;

        Debug.Log("Enemy pushed player!");
    }
}