using UnityEngine;

public class MovingObstacle : MonoBehaviour
{
    //creating varibles for the distance and speed
    public float moveDistance = 5f;
    public float moveSpeed = 3f;
    //start position 
    private Vector3 startPosition;

    void Start()
    {
        //bounding to each position
        startPosition = transform.position;
    }

    void FixedUpdate()
    {   
        //using a pingpong function via google to have the obstacle bound back and fourth 
        float offset = Mathf.PingPong(
            Time.time * moveSpeed,
            moveDistance * 2f
        ) - moveDistance;
        //I used the internet for this line.
        Vector3 newPosition = startPosition + Vector3.right * offset;

        transform.position = newPosition;
    }
}