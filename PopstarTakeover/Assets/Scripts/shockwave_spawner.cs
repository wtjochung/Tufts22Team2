using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// A class which continously spawn a given GameObject based on a given rate.
/// Currently does not respond to player input.
/// TODO: Make another script to read player microphone input.
/// TODO: Follow player movement (player's transform)
/// </summary>
public class shockwave_spawner : MonoBehaviour
{

    public GameObject objectPrefab = null;

    public float spawnRate = 0.05f;
    private float lastSpawned = Mathf.NegativeInfinity;
    //micListener ml = new micListener(); TODO delete


    // Start is called before the first frame update
    void Start()
    {
        //ml = new micListener();TODO change to playerInput
    }

    // Update is called once per frame
    void Update()
    {
        
        //bool spawnOrNot = micListener.Spawn();
       // if (ml.Spawn())
        //{
            Spawn();
       // }
        
    }

    public void Spawn()
    {
        if ((Time.timeSinceLevelLoad - lastSpawned) > spawnRate)
        {
            SpawnObject();
            lastSpawned = Time.timeSinceLevelLoad;
        }

        
    }

    public void SpawnObject()
    {
        if (objectPrefab != null)
        {
            GameObject newGameObject = Instantiate(objectPrefab, transform.position, transform.rotation, null);
        }
    }
}
