using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class ButtonHandler : MonoBehaviour
{
    public string sceneToLoad = "";
    public void SetScene()
    {
        if (sceneToLoad != "")SceneManager.LoadScene(sceneToLoad);
    }

    
}