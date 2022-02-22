using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{

    public float speed = 10f;
    public float mobileSpeed = 2f;
    Rigidbody2D m_Rigidbody;
    //public string axisName = "Hori";
    //public float jump = 1;
    public float screenHeight;
    private float vertical;
    private Touch currTouch;

    private void Start()
    {
        m_Rigidbody = GetComponent<Rigidbody2D>();
        screenHeight = Screen.height;
    }

    private void FixedUpdate()
    {
        if (Input.touchCount > 0)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y + currTouch.deltaPosition.y * Time.deltaTime, 0);

            // Touch touch = Input.GetTouch(0);
            // Vector3 mobile_Input = new Vector3(0, vertical, 0);
            // rigidbody2D.AddForce(new Vector2(horizontal * (moveSpeed * 20f) * Time.deltaTime, 0));
            //   if (transform.position.y != currTouch.position.y) {
            //      m_Rigidbody.MovePosition(transform.position + speed * Time.deltaTime * mobile_Input);
            // }
        } else
        {
            Vector3 m_Input = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), 0);
            //Apply the movement vector to the current position, which is
            //multiplied by deltaTime and speed for a smooth MovePosition
            m_Rigidbody.MovePosition(transform.position + speed * Time.deltaTime * m_Input);
        }
    }

        void Update()
        {

        if (Input.touchCount > 0)
        {
            currTouch = Input.GetTouch(0);
            /*
            if (currTouch.phase == TouchPhase.Began && currTouch.phase != TouchPhase.Ended)
            {
                if (currTouch.position.y > screenHeight / 2)
                {
                    vertical = 1.0f * mobileSpeed;
                }
                if (currTouch.position.y < screenHeight / 2)
                {
                    vertical = -1.0f * mobileSpeed;
                }
            
            }*/
            // else if (currTouch.phase == TouchPhase.Stationary)
           // {

          //  }
        }
        else
        {
            vertical = 0.0f;
        }


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

