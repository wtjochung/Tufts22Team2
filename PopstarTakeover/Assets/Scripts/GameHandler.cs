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

    public int seatsAvailable = 10;
    public static int fanSaved;
    public static int paparazziSaved;
    

    public static int gotScore = 0;
    public GameObject scoreText;

    public bool isDefending = false;

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
    }

    

    public void updateStatsDisplay()
    {
       // Text healthTextTemp = healthText.GetComponent<Text>();
       // healthTextTemp.text = "HEALTH: " + playerHealth;

        Text scoreTextTemp = scoreText.GetComponent<Text>();
        scoreTextTemp.text = "Score: " + gotScore;

        if ((fanSaved + paparazziSaved) >= seatsAvailable)
        {
            //TODO: level end screen
        }
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
        if (Input.GetKey("escape"))
        {
            Application.Quit();
        }
        updateStatsDisplay();

      
        if ((fanSaved + paparazziSaved) >= seatsAvailable)
        {
            determineWinState();

        }

    }

    void determineWinState()
    {
        Debug.Log("In determine win state");
        
        float fanratio = fanSaved / seatsAvailable;
        Debug.Log("fanratio: " + fanratio);
        if (fanratio > 0.8f)
        {
            Debug.Log("fansaved: " + fanSaved);
            SceneManager.LoadScene("WinScreen");
        } else if ((paparazziSaved / seatsAvailable) > 0.8f)
        {
            Debug.Log("fansaved: " + fanSaved);
            SceneManager.LoadScene("LoseScreen");
        } else 
        {
            Debug.Log("fansaved: " + fanSaved);
            SceneManager.LoadScene("NormalScreen");
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