using UnityEngine;

public class HazardZone : MonoBehaviour
{
    public GameManager gameManager;
    public Transform resetPoint;

    void OnTriggerEnter(Collider other)
    {


        //player fall off
        if (other.CompareTag("Player"))
        {
            Debug.Log("Player Fell Off!");

            gameManager.LoseAttempt();

            if (gameManager.isPlaying && resetPoint != null)
            {
                Rigidbody rb = other.GetComponent<Rigidbody>();

                if (rb != null)
                {
                    rb.linearVelocity = Vector3.zero;
                    rb.angularVelocity = Vector3.zero;
                    rb.position = resetPoint.position;
                }
                else
                {
                    other.transform.position = resetPoint.position;
                }
            }
        }
        //ball fall off
        if (other.CompareTag("DeliveryObject"))
        {
            Debug.Log("Delivery Failed!");

            gameManager.LoseAttempt();

            DeliveryObject delivery =
                 other.GetComponent<DeliveryObject>();

            if (delivery != null &&
                 gameManager.isPlaying)
            {
                delivery.ResetDelivery();
            }
        }
    }
}
