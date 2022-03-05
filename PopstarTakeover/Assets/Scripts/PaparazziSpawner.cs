using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// A class which continously spawn a given GameObject based on a given rate.
/// Currently does not respond to player input.
/// TODO: Make another script to read player microphone input.
/// TODO: Follow player movement (player's transform)
/// </summary>
public class PaparazziSpawner : MonoBehaviour
{

    public GameObject objectPrefab = null;
    public GameObject objectPrefab2 = null;
    [Tooltip("Smaller value = faster spawn")]
    public float object2SpawnChance = 0.3f;
    public float spawnRate = 0.05f;
    public int rows = 4;

    [Header("Spawn Position")]
    [Tooltip("The distance within which enemies can spawn in the X direction")]
    [Min(0)]
    public float spawnRangeX = 10.0f;
    [Tooltip("The distance within which enemies can spawn in the Y direction")]
    [Min(0)]
    public float spawnRangeY = 10.0f;


    private float lastSpawned = Mathf.NegativeInfinity;
 
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
           Spawn();
        
    }

    public void Spawn()
    {
        if ((Time.timeSinceLevelLoad - lastSpawned) > spawnRate)
        {
           // int random = Random.Range(0, 10);
           // Debug.Log(random);
           // if (random > 5)
            //{
                SpawnObject();
                lastSpawned = Time.timeSinceLevelLoad;
          //  }
        }

    }

    public void SpawnObject()
    {
        if (spawn2OrNot())
        {
            if (objectPrefab2 != null)
            {
                Quaternion q = objectPrefab.transform.rotation;
                GameObject newGO = Instantiate(objectPrefab2, GetSpawnLocation(), q, null);
            }
        } else
        {
            if (objectPrefab != null)
            {
                Quaternion q = objectPrefab.transform.rotation;
                GameObject newGameObject = Instantiate(objectPrefab, GetSpawnLocation(), q, null);
            }
        }
        
    }

    private bool spawn2OrNot()
    {
        int chance = Random.Range(0, 10);
        float x = 10f;
        float chanceFloat = chance / x;
        Debug.Log("chance: " + chanceFloat);
        return (chanceFloat <= object2SpawnChance);
    }

    public void changeSpawnRate(float newRate)
    {
        spawnRate = newRate;
    }

    protected virtual Vector3 GetSpawnLocation()
    {
        // Get random coordinates
        //int x = (int)Random.Range(0 - spawnRangeX, spawnRangeX);
        int x = 0;
        int y = (int)Random.Range(0, rows);
        float interval = spawnRangeY / rows;


        // Return the coordinates as a vector
        return new Vector3(transform.position.x + x, transform.position.y + (y * interval), 0);
    }

}
