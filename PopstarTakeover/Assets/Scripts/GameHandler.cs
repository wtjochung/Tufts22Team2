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

    public GameObject fanText;
    public GameObject paparazziText;

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

    public GameObject fanRatioStrip;
    public GameObject paparazziRatioStrip;

    public GameObject endSceneMenuUI;




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
        readMicInput = false;
        readKeyboardInput = true;
        
        micInput = readMicInput;
        keyboardInput = readKeyboardInput;

        baselineVolume = -80;
        highestVolume = -75;
        

        Debug.Log("handler micinput " + readMicInput);
        Debug.Log("handler keyboardinput " + readKeyboardInput);

    }

    private void updateRatioDisplay()
    {
        if (fanRatioStrip != null)
        {
            /* Vector3 scaleChange = new Vector3(0, 0, 0);


             fanRatioStrip.transform.localScale += scaleChange;

            */
            //  float size = fanRatioStrip.GetComponent<Renderer>().bounds.size.x;

            //  Vector3 rescale = fanRatioStrip.transform.localScale;

            //  rescale.x = getFanRatio() * 10 * rescale.x / size;

            // fanRatioStrip.transform.localScale = rescale;

            Vector3 scaleChange = new Vector3(12 * getFanRatio(), 0.6f, 1);
            fanRatioStrip.transform.localScale = scaleChange;

        } 
        if (paparazziRatioStrip != null)
        {
            /*
            float size = paparazziRatioStrip.GetComponent<Renderer>().bounds.size.x;

            Vector3 rescale = paparazziRatioStrip.transform.localScale;

            rescale.x = getPaparazziRatio()* 10 * rescale.x / size;

            paparazziRatioStrip.transform.localScale = rescale;
            */
            Vector3 scaleChange = new Vector3(12 * getPaparazziRatio(), 0.6f, 1);
            paparazziRatioStrip.transform.localScale = scaleChange;
        }
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

        updateRatioDisplay();

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
       
        
        float fanratio = getFanRatio();
        float pratio = getPaparazziRatio();
        Debug.Log("fanratio" + fanratio);
        Debug.Log("pratio" + pratio);
       
        if (endSceneMenuUI != null)
        {
           endSceneMenuUI.SetActive(true);
            Time.timeScale = 0f;

            if (fanText != null)
            {
                Text fanTextTemp = fanText.GetComponent<Text>();
                fanTextTemp.text = (Mathf.Round(getFanRatio()) * 100) + "% of your audience are your fans.";
            }
            if (paparazziText != null)
            {
                Text paparazziTextTemp = paparazziText.GetComponent<Text>();
                paparazziTextTemp.text = "You managed to drive away " + paparazziLost + " paparazzis!";
            }
        }
        else if (sceneToLoad.Length != 0)
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

    public float getFanRatio()
    {
       // return ((float)fanSaved / seatsAvailable);
       if (fanSaved + paparazziSaved == 0)
        {
            return 0;
        }
        return ((float)fanSaved / (fanSaved + paparazziSaved));

    }

    public float getPaparazziRatio()
    {
        // return ((float)paparazziSaved / seatsAvailable);
        if (fanSaved + paparazziSaved == 0)
        {
            return 0;
        }
        return ((float)paparazziSaved / (fanSaved + paparazziSaved));
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