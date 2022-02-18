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
    [Tooltip("Smaller value = faster spawn")]
    public float spawnRate = 0.05f;
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
            SpawnObject();
            lastSpawned = Time.timeSinceLevelLoad;
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
            GameObject newGameObject = Instantiate(objectPrefab, transform.position, q, null);
        }
    }


}
