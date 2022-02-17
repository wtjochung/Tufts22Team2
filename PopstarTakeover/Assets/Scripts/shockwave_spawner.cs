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
    [Tooltip("Smaller value = faster spawn")]
    public float spawnRate = 0.05f;
    private float lastSpawned = Mathf.NegativeInfinity;
    //public float scale = 1;
  
    [Tooltip("Default = 0,0,0; To flatten: from y=0 to y=-0.9")]
    public Vector3 sizeChange;
    //public GameObject scaleObject = null;
    //private GameObject scaleGameObject;

    //micListener ml = new micListener(); TODO delete


    // Start is called before the first frame update
    void Start()
    {
        //scaleGameObject = Instantiate(scaleObject, transform.position, transform.rotation, null);
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

            GameObject waveholder = new GameObject();
            waveholder.AddComponent<TimedObjectDestroyer>();
           
            //TODO: Get microphone input through MicListener script and adjust y accordingly (from 0 to -0.9)
            waveholder.transform.localScale = waveholder.transform.localScale + (1 * sizeChange);
            GameObject newGameObject = Instantiate(objectPrefab, transform.position, transform.rotation, waveholder.transform);

        }
    }
}
