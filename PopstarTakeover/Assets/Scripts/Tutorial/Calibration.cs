using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Calibration : MonoBehaviour
{
    Animator anim;
    GameObject player;
   // public GameObject listener;
    //shockwave_spawner spawner;

    float[] voiceVolumeList;
    float voiceVolumeAvg;
    int count;
    bool start;
    
    bool startEnvironVolume;

    float[] enviroVolumeList;
    float enviroVolumeAvg;

    public int calibrationLength;

    Queue volumeBuffer;

    float startCalibTimeEnv;
    float startCalibTimeVoice;


    // Start is called before the first frame update
    void Start()
    {
        //spawner = new shockwave_spawner();
        
        anim = GetComponent<Animator>();
        /*
        count = 0;
        start = false;
       anim.SetFloat("calibration_speed", 1.5f);
        volumeBuffer = new Queue();

        voiceVolumeList = new float[calibrationLength + 10];
        enviroVolumeList = new float[calibrationLength + 10];
        for (int i = 0; i < calibrationLength + 10; i++)
        {
            enviroVolumeList[i] = -210;
        }
        */

    }

    public void startCalibration()
    {
        start = true;
        startCalibTimeVoice = Time.unscaledTime;
        count = 0;
        startEnvironVolume = false;
        anim.SetBool("calibration_start", start);

        volumeBuffer = new Queue();

        voiceVolumeList = new float[1024];
        enviroVolumeList = new float[1024];
        for (int i = 0; i < 1024; i++)
        {
            enviroVolumeList[i] = -210;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
        if (start)
        {
           
            startListening();
            Debug.Log("calibration start");
        } else if (startEnvironVolume)
        {
            startCalibTimeEnv = Time.unscaledTime;
            startListeningEnviro();
        }
       
    }

    void startListening()
    {
#if !UNITY_WEBGL
        float timeLength = Time.unscaledTime - startCalibTimeVoice;
        Debug.Log("curr time :" + Time.unscaledTime);
        Debug.Log("start time: " + startCalibTimeVoice);
        if (timeLength < calibrationLength && count < 1024)
        {
            timeLength = Time.unscaledTime - startCalibTimeVoice;
            float currVolume = MicInput.MicLoudnessinDecibels;
            Debug.Log("voice length :" + timeLength);
          

            voiceVolumeList[count] = averageMicLevel(currVolume);

            count++;
            Debug.Log("calibrating voice level: " + count);
        }
        else
        {
            Debug.Log("finished calibrating voice");
            start = false;
            startEnvironVolume = true;

            voiceVolumeAvg = getAverage(voiceVolumeList);
            count = 0;
            startListeningEnviro();
            volumeBuffer.Clear();


        }
#endif
    }

    void startListeningEnviro()
    {
#if !UNITY_WEBGL
       
        Debug.Log("at listening enviro");
    
    count++;
        float currDuration = Time.unscaledTime - startCalibTimeEnv;
        if (count > 10 &&  count < 1024)
        {
            float currVolume = MicInput.MicLoudnessinDecibels;
            while (currDuration < calibrationLength)
            {
                currDuration = Time.unscaledTime - startCalibTimeEnv;
                enviroVolumeList[count] = averageMicLevel(currVolume);
                //count++;
                Debug.Log("calibrating enviro: " + count);
            }
        }
           
        else if (count >= 1023)
        {
            startEnvironVolume = false;
            enviroVolumeAvg = getAverage(enviroVolumeList);
            Debug.Log("voice " + voiceVolumeAvg + ", enviro: " + enviroVolumeAvg);
            GameHandler.updateBaselineVolume(enviroVolumeAvg, voiceVolumeAvg);
            anim.SetBool("calibration_start", false);
            count = 0;
        }
#endif
    }

    float getAverage(float[] volumeList)
    {
        
        float total = 0;
        foreach(float volume in volumeList)
        {
            total += volume;
        }
        total /= volumeList.Length;
        return total;
    }

    float getHighest(float[] volumeList)
    {
        float highestVol = -300;
       

        foreach (float volume in volumeList)
        { 
            if (highestVol < volume)
            {
                highestVol = volume;
            }
        }
        /*
        var secondHighest =
    volumeList
    .Distinct()
    .OrderByDescending(i => i);
    .Skip(1)
    .First();
        */
        return highestVol;

    }

    public float averageMicLevel(float currVolume)
    {

        
        int volumeSmooth = 5;
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

        //Debug.Log("calibration average volume: " + average);
        return average;
    }



}
