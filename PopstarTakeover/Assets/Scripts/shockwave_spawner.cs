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

    //public float holdTime = 0.1f;
    /*
    public GameObject briefTap;
    public GameObject shortHold;
    public GameObject medHold;
    public GameObject longHold;
    public GameObject veryLongHold;
    */
    public GameObject[] projectileList;

    private float lastSpawned = Mathf.NegativeInfinity;

    //public float maxLevel;
    //public float minLevel = -100;
    //public float scale = 1;

    public bool micInput;
    public bool keyboardInput;
    private bool keydown = false;
    private float keydownTime;
    private float keyupTime;
    //private bool isWebGL = false;
  
    [Tooltip("Default = 0,0,0; To flatten: from y=0 to y=-0.9")]
    public Vector3 sizeChange;
    //public GameObject scaleObject = null;
    //private GameObject scaleGameObject;

    //micListener ml = new micListener(); TODO delete


    // Start is called before the first frame update
    void Start()
    {
        

#if UNITY_WEBGL
        isWebGL = true;
#endif
    }

    // Update is called once per frame
    void Update()
    {
        if (keyboardInput)
        {
            if (Input.GetButtonDown("Jump"))
            {
                if (keydown == false)
                {
                    keydownTime = Time.timeSinceLevelLoad;
                    keydown = true;
                }

            }

            if (Input.GetButtonUp("Jump"))
            {
                keydown = false;
                keyupTime = Time.timeSinceLevelLoad;

                // if (SpawnOrNot())
                // {
                Spawn();
                // }
            }


        }
#if !UNITY_WEBGL
        if (micInput && MicInput.MicLoudnessinDecibels > -60)
        {
            keydownTime = Time.timeSinceLevelLoad;
            keydown = true;
            
        } else if (micInput && keydown == true)
            {
                keyupTime = Time.timeSinceLevelLoad;
                keydown = false;

                Spawn();
            }
        
#endif
    }

        float getTimePressed()
    {
        //Debug.Log("timepressed: " + (keyupTime - keydownTime));
        return (keyupTime - keydownTime);
    }


    public void Spawn()
    {
       // float timePressed = keydownTime - keyupTime;
      //  if ((getTimePressed()) > spawnRate)
       // {
            int index = (int)(getTimePressed() / spawnRate);
            if (index < 1)
            {
                index = 0;
            } else if (index > projectileList.Length - 1)
            {
                index = projectileList.Length - 1;
            }
            Debug.Log("index: " + index);
            SpawnObject(projectileList[index]);
            lastSpawned = Time.timeSinceLevelLoad;
       // }
    }

    public void SpawnObject(GameObject projectile)
    {
        if (projectile != null)
        {
            GameObject waveholder = new GameObject();
                waveholder.AddComponent<TimedObjectDestroyer>();

            //TODO: Get microphone input through MicListener script and adjust y accordingly (from 0 to -0.9)
           // Vector3 temp = transform.position;
            //float t = micVolume();
            //temp.y += t;
            // waveholder.transform.localScale = temp;
           // Debug.Log("getVolume: "+ getVolume());
                //sizeChange.y += 1.0f;
              //  waveholder.transform.localScale = waveholder.transform.localScale + (1 * sizeChange);
            waveholder.transform.localScale = waveholder.transform.localScale + (1 * sizeChange);
            GameObject newGameObject = Instantiate(projectile, transform.position, transform.rotation, waveholder.transform);

    }
}


    /*
    private float getVolume()
    {
        //Debug.Log("volume: " + MicInput.MicLoudnessinDecibels);
        Debug.Log("max: " + MicInput.MicMaxLoudnessinDecibels);
        return (MicInput.MicLoudnessinDecibels / MicInput.MicMaxLoudnessinDecibels);
    }
    */

    private bool SpawnOrNot()
    {
#if !UNITY_WEBGL
        if (micInput && MicInput.MicLoudnessinDecibels > -60)
        {
            return true;
        } else if (keyboardInput && keydown)
        {
            return true;
        }
        return false;
#endif
#if UNITY_WEBGL
        if (keyboardInput && keydown)
        {
            return true;
        }
        return false;
#endif


    }

    private float micVolume()
    {
#if !UNITY_WEBGL
        return (MicInput.MicLoudnessinDecibels / -100);
#endif

#if UNITY_WEBGL
        return (8f);
#endif
    }
}
