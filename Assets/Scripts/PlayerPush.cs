//credit OPENAI 
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerPush : MonoBehaviour
{
    public float pushForce = 15f;
    public float pushRange = 3f;
    public float pushCooldown = 1f;

    private float nextPushTime = 0f;

    void Update()
    {
        // Press F to push enemies
        if (Keyboard.current != null &&
            Keyboard.current.fKey.wasPressedThisFrame &&
            Time.time >= nextPushTime)
        {
            PushEnemies();
            nextPushTime = Time.time + pushCooldown;
        }
    }

    void PushEnemies()
    {
        Collider[] nearbyEnemies =
            Physics.OverlapSphere(transform.position, pushRange);

        foreach (Collider enemy in nearbyEnemies)
        {
            if (enemy.CompareTag("Enemy"))
            {
                Rigidbody enemyRb =
                    enemy.GetComponentInParent<Rigidbody>();

                if (enemyRb != null)
                {
                    Vector3 pushDirection =
                        enemyRb.position - transform.position;

                    pushDirection.y = 0f;
                    pushDirection.Normalize();

                    enemyRb.AddForce(
                        pushDirection * pushForce,
                        ForceMode.Impulse
                    );

                    Debug.Log("Player pushed enemy!");
                }
            }
        }
    }
}