using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class waveSpawner : MonoBehaviour
{

    public GameObject objectPrefab = null;
    [Tooltip("Smaller value = faster spawn")]
    public float spawnChance = 0.5f;
    public float spawnRate = 10f;

 

    [Header("Spawn Position")]
    [Tooltip("The distance within which enemies can spawn in the X direction")]
    [Min(0)]
    public float spawnRangeX = 1.0f;
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
            for (int i = 0; i < 7; i++) SpawnObject();

            lastSpawned = Time.timeSinceLevelLoad;
            //  }
        }

    }

    public void SpawnObject()
    {
        if (objectPrefab != null)
        {
            // GameObject waveholder = new GameObject();
            // waveholder.AddComponent<TimedObjectDestroyer>();

            // waveholder.transform.localScale = waveholder.transform.localScale + (1 * sizeChange);

            Quaternion q = objectPrefab.transform.rotation;
            // q = Quaternion.AngleAxis(90f, transform.forward) * q;
            GameObject newGameObject = Instantiate(objectPrefab, GetSpawnLocation(), q, null);
        }
    }

    public void changeSpawnRate(float newRate)
    {
        spawnRate = newRate;
    }

    protected virtual Vector3 GetSpawnLocation()
    {
        // Get random coordinates
        float x = Random.Range(0 - spawnRangeX, spawnRangeX);
        float y = Random.Range(0 - spawnRangeY, spawnRangeY);
        // Return the coordinates as a vector
        return new Vector3(transform.position.x + x, transform.position.y + y, 0);
    }

}
