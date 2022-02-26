using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;

public class PauseMenu : MonoBehaviour
{

    public static bool GameisPaused = false;
    public GameObject pauseMenuUI;
    public GameObject settingsMenuUI;
    public AudioMixer mixer;
    public static float volumeLevel = 0.7f;
    private Slider sliderVolumeCtrl;
    private bool settings;

    void Awake()
    {
        pauseMenuUI.SetActive(false);
        SetLevel(volumeLevel);
        settings = false;
        /*
        GameObject sliderTemp = GameObject.FindWithTag("PauseMenuSlider");
        if (sliderTemp != null)
        {
            sliderVolumeCtrl = sliderTemp.GetComponent<Slider>();
            sliderVolumeCtrl.value = volumeLevel;
        }
        */
    }

    void Start()
    {
        pauseMenuUI.SetActive(false);
    }

    void Update()
    {
        if (Input.GetKeyDown("escape"))//Input.GetKeyDown(KeyCode.Escape) || 
        {
            if (GameisPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }

    }
    
    public void Settings()
    {
        settings = !settings;
        settingsMenuUI.SetActive(settings);
        //Time.timeScale = 0f;
        //GameisPaused = settings;
    }

    public void Pause()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameisPaused = true;
    }

    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameisPaused = false;
    }

    public void Restart()
    {
        Time.timeScale = 1f;
        //restart the game:
        //SceneManager.LoadScene (SceneManager.GetActiveScene().buildIndex);
        SceneManager.LoadScene("MainMenu");
    }

    public void QuitGame()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
                Application.Quit();
#endif
    }

    public void SetLevel(float sliderValue)
    {
       // mixer.SetFloat("MusicVolume", Mathf.Log10(sliderValue) * 20);
       // volumeLevel = sliderValue;
    }
}