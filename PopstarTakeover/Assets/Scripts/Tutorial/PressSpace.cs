using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressSpace : MonoBehaviour
{
    public bool keydown, keyup;
    private float keydownTime, keyupTime, pressedTime;
    public GameObject bar;
    private float length = 0;
    private GameObject holder;
    public Vector3 sizeChange;
    Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        //holder = new GameObject();
        anim = GetComponent<Animator>();


       // Vector3 scaleChange = new Vector3(0, 0, 0);
      //  GameObject spacebar = Instantiate(bar, transform.position, transform.rotation, holder.transform);
    }

    // Update is called once per frame
    void Update()
    {
        pressedTime = keyupTime - keydownTime;
        length = (pressedTime / 0.3f);
       
        if (Input.GetButtonDown("Jump") || shockwave_spawner.inputStart)
        {
            if (keydown == false)
            {
                keydownTime = Time.timeSinceLevelLoad;
                keydown = true;
                
            }

        }

        if (Input.GetButtonUp("Jump") || !shockwave_spawner.inputStart)
        {
            keydown = false;
            keyupTime = Time.timeSinceLevelLoad;
            

        }

        if (keydown == false)
        {
            length = 0;
        }

        anim.SetBool("spacePressed", keydown);
       // anim.SetBool("spaceReleased", keyup);

        changeBarLength(pressedTime);
    }

    void changeBarLength(float length)
    {
        /*Vector3 scaleChange = new Vector3(length, 0, 0);

        bar.transform.localScale += scaleChange;
        */

        Vector3 temp = transform.position;
        //float t = micVolume();
        //temp.x = length;
        //holder.transform.localScale = temp;
        // Debug.Log("getVolume: "+ getVolume());
       // sizeChange.x += 0.1f;
       // holder.transform.localScale = holder.transform.localScale + (1 * sizeChange);

    }

}
