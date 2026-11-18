using UnityEngine;

// OpenAI Credit
public class UFO : MonoBehaviour
{
    [Header("Flight Settings")]
    public float flightSpeed = 3f;
    public float flightDistance = 15f;
    public float hoverHeight = 0.5f;
    public float hoverSpeed = 1.5f;

    [Header("Rotation Settings")]
    public float rotationSpeed = 45f;

    [Header("Observation Settings")]
    public float minFlightTime = 4f;
    public float maxFlightTime = 8f;
    public float minObserveTime = 2f;
    public float maxObserveTime = 5f;

    private Vector3 startingPosition;
    private float targetX;
    private float stateTimer;
    private bool observing = false;

    void Start()
    {
        startingPosition = transform.position;

        // Start flying toward the right
        targetX = startingPosition.x + flightDistance;

        SetFlightTimer();
    }

    void Update()
    {
        // Always rotate, even when observing
        transform.Rotate(
            Vector3.up,
            rotationSpeed * Time.deltaTime,
            Space.Self
        );

        // Gentle hovering animation
        Vector3 position = transform.position;

        position.y = startingPosition.y +
            Mathf.Sin(Time.time * hoverSpeed) * hoverHeight;

        stateTimer -= Time.deltaTime;

        if (observing)
        {
            // Stay in place while observing
            transform.position = position;

            if (stateTimer <= 0f)
            {
                observing = false;
                SetFlightTimer();
            }

            return;
        }

        // Move horizontally toward the target
        position.x = Mathf.MoveTowards(
            position.x,
            targetX,
            flightSpeed * Time.deltaTime
        );

        transform.position = position;

        // Reverse direction at patrol boundaries
        if (Mathf.Abs(position.x - targetX) < 0.05f)
        {
            targetX = targetX >
                startingPosition.x
                ? startingPosition.x - flightDistance
                : startingPosition.x + flightDistance;
        }

        // Occasionally stop to observe
        if (stateTimer <= 0f)
        {
            observing = true;
            SetObserveTimer();
        }
    }

    void SetFlightTimer()
    {
        stateTimer = Random.Range(
            minFlightTime,
            maxFlightTime
        );
    }

    void SetObserveTimer()
    {
        stateTimer = Random.Range(
            minObserveTime,
            maxObserveTime
        );
    }
}