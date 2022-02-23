using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressSpace : MonoBehaviour
{
    private bool keydown, keyup;
    private float keydownTime, keyupTime, pressedTime;
    public GameObject bar;
    private float length = 0;
    
    // Start is called before the first frame update
    void Start()
    {
        Vector3 scaleChange = new Vector3(-2, 0, 0);
        GameObject spacebar = Instantiate(bar, transform.position, transform.rotation);
    }

    // Update is called once per frame
    void Update()
    {
        pressedTime = keyupTime - keydownTime;
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

        }

        if (keydown = false)
        {
            length = 0;
        }
        changeBarLength(pressedTime);
    }

    void changeBarLength(float time)
    {
        Vector3 scaleChange = new Vector3(time, 0, 0);

        bar.transform.localScale += scaleChange;
    }

}
