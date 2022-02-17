using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{

    public float speed = 0.2f;
    //public string axisName = "Hori";
    //public float jump = 1;

    void Update()
    {
        //movement code
        transform.position += transform.right * Input.GetAxis("Horizontal") * speed;
        transform.position += transform.up * Input.GetAxis("Vertical") * speed;

        //jump code
        /*
        if (Input.GetKey(KeyCode.UpArrow))
        {
            Vector3 position = this.transform.position;
            position.y += (1 * speed);
            this.transform.position = position;
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            Vector3 position = this.transform.position;
            position.y -= (1 * speed);
            //position.y -= position.y * speed ;
            //position.y += jump / 4;
            this.transform.position = position;
        }
        */

        //flip character based on movement direction
        /*
        if (Input.GetAxis(axisName) < 0)
        {
            Vector3 newScale = transform.localScale;
            newScale.x = 1.0f;
            transform.localScale = newScale;
        }
        else if (Input.GetAxis(axisName) > 0)
        {
            Vector3 newScale = transform.localScale;
            newScale.x = -1.0f;
            transform.localScale = newScale;
        }
        */
    }
}
