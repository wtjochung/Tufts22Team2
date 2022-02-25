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

    public GameObject[] projectileList;

    private float lastSpawned = Mathf.NegativeInfinity;


    public bool micInput;
    public bool keyboardInput;
    private bool inputStart = false;
    private float inputStartTime;
    private float inputEndTime;
 
    Queue volumeBuffer;

    public int volumeSmooth = 5;

    [Tooltip("Default = 0,0,0; To flatten: from y=0 to y=-0.9")]
    public Vector3 sizeChange;
    //public GameObject scaleObject = null;
    //private GameObject scaleGameObject;

    //micListener ml = new micListener(); TODO delete


    // Start is called before the first frame update
    void Start()
    {
        volumeBuffer = new Queue();

       // GameHandler handler = GameObject.FindGameObjectsWithTag("GameController");

        micInput = GameHandler.readInMicInput();
        keyboardInput = GameHandler.readInKeyboardInput();

        Debug.Log("micinput " + micInput);
        Debug.Log("keyboardinput " + keyboardInput);
    }

    // Update is called once per frame
    void Update()
    {
        if (keyboardInput)
        {
            if (Input.GetButtonDown("Jump"))
            {
                //reset timer only if the input button isn't already pressed
                if (inputStart == false)
                {
                    inputStartTime = Time.timeSinceLevelLoad;
                    inputStart = true;
                }
            }

            if (Input.GetButtonUp("Jump"))
            {
                inputStart = false;
                inputEndTime = Time.timeSinceLevelLoad;

                // if (SpawnOrNot())
                // {
                Spawn();
                // }
            }
        }
#if !UNITY_WEBGL
        if (micInput)
        {
            float currVolume = MicInput.MicLoudnessinDecibels;
            Debug.Log("currVolume");

            if  (averageMicLevel(currVolume) > -80)
            {
                if (inputStart == false)
                {
                    inputStartTime = Time.timeSinceLevelLoad;
                    inputStart = true;
                    Debug.Log("sound detected");
                }
            }
            if (inputStart)
            {
                if (averageMicLevel(currVolume) <= -80 && averageMicLevel(currVolume) > -200)
                {
                    inputEndTime = Time.timeSinceLevelLoad;
                    inputStart = false;
                    Debug.Log("sound ended");
                    Spawn();
                }
            }
        }
#endif
    }

    private float averageMicLevel(float currVolume)
    {
        
        volumeBuffer.Enqueue(currVolume);
        if (volumeBuffer.Count > volumeSmooth)
        {
            volumeBuffer.Dequeue();
        }
        float average = 0;
        foreach (float volume in volumeBuffer)
        {
            average += volume;
        }
        average /= volumeBuffer.Count;

        Debug.Log("average volume: " + average);
        return average;
    }

    

        float getTimePressed()
    {
        //Debug.Log("timepressed: " + (inputEndTime - keydownTime));
            return (inputEndTime - inputStartTime);
    }


    public void Spawn()
    {
       // float timePressed = inputStartTime - inputEndTime;
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
            //Plays pew sound of uploaded audio
            gameObject.GetComponent<AudioSource>().Play();

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
        } else if (keyboardInput && inputStart)
        {
            return true;
        }
        return false;
#endif
#if UNITY_WEBGL
        if (keyboardInput && inputStart)
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
