using UnityEngine;

public class FloatingCoin : MonoBehaviour
{
    //declaring public values for rotating and bobbing.
    public float rotationSpeed = 150f;
    public float bobHeight = 0.25f;
    public float bobSpeed = 2f;

    private Vector3 startPosition;

    void Start()
    {
        //holding start position
        startPosition = transform.position;
    }

    void Update()
    {
        //function used from class
        //space.self tells the engine to rotate the object using its own local axes.
        //product of being mad at unity for 30 minutes.
        transform.Rotate(rotationSpeed * Time.deltaTime,0f,0f,Space.Self);

        //Bobbing slightly up and down
        //google helped with this I don't really know much about this function with .Sin
        float newY = startPosition.y + Mathf.Sin(Time.time * bobSpeed) * bobHeight;

        transform.position = new Vector3(startPosition.x,newY,startPosition.z);
    }
}
