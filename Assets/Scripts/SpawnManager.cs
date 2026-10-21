using UnityEngine;

using UnityEngine.InputSystem;



public class SpawnManager : MonoBehaviour

{

    public GameObject objectPrefab;

    public Transform[] spawnPoints;

    public float spawnInterval = 5f;
    public int maxEnemies = 2;


    void Update()

    {

        // Testing only 

        if (Keyboard.current.pKey.wasPressedThisFrame)

        {

            SpawnObject();

        }

    }



    public void SpawnObject()

    {

        if (objectPrefab == null)

        {

            Debug.Log("No prefab assigned.");

            return;

        }



        if (spawnPoints.Length == 0)

        {

            Debug.Log("No spawn points assigned.");

            return;

        }



        int randomIndex =

            Random.Range(0, spawnPoints.Length);



        Transform selectedSpawnPoint =

            spawnPoints[randomIndex];


        //new addition that keeps the max at two enemies for first level.
        GameObject[] enemies =
    GameObject.FindGameObjectsWithTag("Enemy");

        if (enemies.Length >= 2)
        {
            return;
        }

        Instantiate(

            objectPrefab,

            selectedSpawnPoint.position,

            selectedSpawnPoint.rotation

        );




        Debug.Log("Object Spawned!");

    }

}
