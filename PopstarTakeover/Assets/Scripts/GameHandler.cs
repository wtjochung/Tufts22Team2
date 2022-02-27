using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameHandler : MonoBehaviour
{

    public static int playerStat;
    //public GameObject textGameObject;

    private GameObject player;
    public static int playerHealth = 100;
    public int StartPlayerHealth = 100;
    public GameObject healthText;

    public int seatsAvailable;
    private int currSeats;
    public GameObject seatsText;

    public bool readMicInput;
    public bool readKeyboardInput;
    public static bool micInput;
    public static bool keyboardInput;

    private static float baselineVolume;
    private static float highestVolume;

    public static int fanSaved;
    public static int paparazziSaved;

    public static int fanLost;
    public static int paparazziLost;
    

    public static int gotScore = 0;
    public GameObject scoreText;

    public string sceneToLoad;

   

    public static bool stairCaseUnlocked = false;
    //this is a flag check. Add to other scripts: GameHandler.stairCaseUnlocked = true;

   

    private string sceneName;

    void Start () {
        player = GameObject.FindWithTag("Player");
        sceneName = SceneManager.GetActiveScene().name;
        //if (sceneName=="MainMenu"){ //uncomment these two lines when the MainMenu exists
        playerHealth = StartPlayerHealth;
        //}
        updateStatsDisplay();
        fanSaved = 0;
        paparazziSaved = 0;
        fanLost = 0;
        paparazziLost = 0;

        currSeats = seatsAvailable;
        if (sceneName == "MainMenu")
        {
            gotScore = 0;
        }

        //todo delete - hardcoded stuff
        readMicInput = true;
        readKeyboardInput = false;
        
        micInput = readMicInput;
        keyboardInput = readKeyboardInput;

        baselineVolume = -80;
        highestVolume = -75;
        

        Debug.Log("handler micinput " + readMicInput);
        Debug.Log("handler keyboardinput " + readKeyboardInput);

    }

    public static void updateBaselineVolume(float enviroVolume, float highVolume)
    {
        baselineVolume = enviroVolume;
        highestVolume = highVolume;
    }

    public static float getBaselineVolume()
    {
        return baselineVolume;
    }

    public static float getHighestVolume()
    {
        return highestVolume;
    }


    public static bool readInMicInput()
    {
        return micInput;
    }

    public static bool readInKeyboardInput()
    {
        return keyboardInput;
    }

    public void updateStatsDisplay()
    {
       // Text healthTextTemp = healthText.GetComponent<Text>();
       // healthTextTemp.text = "HEALTH: " + playerHealth;

        Text scoreTextTemp = scoreText.GetComponent<Text>();
        scoreTextTemp.text = "Score: " + gotScore;

        Text seatsTextTemp = seatsText.GetComponent<Text>();
        seatsTextTemp.text = currSeats + " seats remaining";

    }

    public void playerGetScore(int scoreIncrease)
    {
        gotScore += scoreIncrease;
        updateStatsDisplay();
    }


    /*
    public void StartGame()
    {
        SceneManager.LoadScene("Level1");
    }
    */

    /*
    public void RestartGame()
    {
        SceneManager.LoadScene("MainMenu");
        playerHealth = StartPlayerHealth;
    }
    */

    public void QuitGame()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
                Application.Quit();
#endif
    }

    public void Credits()
    {
        SceneManager.LoadScene("Credits");
    }

    void Update()
    {         //delete this quit functionality when a Pause Menu is added
        /*
        if (Input.GetKey("escape"))
        {
            Application.Quit();
        }
        */
        updateStatsDisplay();

        currSeats = seatsAvailable - (fanSaved + paparazziSaved);
        if (currSeats <= 0)
        {
            determineWinState();
        }
    }

    void determineWinState()
    {
       
        
        float fanratio = (float)fanSaved / seatsAvailable;
        float pratio = (float)paparazziSaved / seatsAvailable;
        Debug.Log("fanratio" + fanratio);
        Debug.Log("pratio" + pratio);

        if (sceneToLoad.Length != 0)
        {
            SceneManager.LoadScene(sceneToLoad);
        }
        else
        {

            if (fanratio >= 0.75f)
            {
                SceneManager.LoadScene("WinScreen");
            }
            else if (pratio >= 0.75f)
            {
                SceneManager.LoadScene("LoseScreen");
            }
            else if (fanLost >= 3)
            {
                SceneManager.LoadScene("NormalScreen");
            }
            else
            {
                SceneManager.LoadScene("MediumScreen");
            }
        }
    }

    public void UpdatePlayerStat(int amount)
    {
        playerStat += amount;
        Debug.Log("Current Player Stat = " + playerStat);
        //      UpdateScore ();
    }

    public int CheckPlayerStat()
    {
        return playerStat;
    }

    //void UpdateScore () {
    //        Text scoreTemp = textGameObject.GetComponent<Text>();
    //        scoreTemp.text = "Score: " + score; }

    public void StartGame()
    {
        SceneManager.LoadScene("Scene1");
    }

    public void RestartGame()
    {
        SceneManager.LoadScene("MainMenu");
    }

    
}