using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{

    public float speed = 10f;
    Rigidbody2D m_Rigidbody;
    //public string axisName = "Hori";
    //public float jump = 1;

    private void Start()
    {
        m_Rigidbody = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        Vector3 m_Input = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), 0);

        //Apply the movement vector to the current position, which is
        //multiplied by deltaTime and speed for a smooth MovePosition
        m_Rigidbody.MovePosition(transform.position + speed * Time.deltaTime * m_Input);
    }

    void Update()
    {
        //movement code


         //transform.position += transform.right * Input.GetAxis("Horizontal") * speed;
         // transform.position += transform.up * Input.GetAxis("Vertical") * speed;
        

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
