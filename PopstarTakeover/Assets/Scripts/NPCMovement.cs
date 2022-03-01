using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCMovement : MonoBehaviour
{

    [Tooltip("The distance this projectile will move each second.")]
    public float speed = 3.0f;

    [Tooltip("How far away from the main camera before destroying the projectile gameobject in meters.")]
    public float destroyDistance = 50.0f;

    public bool goLeft = true;
    public bool disableLeftMovement;
   
    /// <summary>
    /// Description:
    /// Standard Unity function called once per frame
    /// Inputs: 
    /// none
    /// Returns: 
    /// void (no return)
    /// </summary>
    // Update is called once per frame
    void Update()
    {
        MoveNPC();
    }

    /// <summary>
    /// Description:
    /// Move the object in the direction it is heading
    /// Inputs: 
    /// none
    /// Returns: 
    /// void (no return)
    /// </summary>
    private void MoveNPC()
    {
        if (!disableLeftMovement)
        {
            // move the transform
            if (goLeft)
            {
                transform.position = transform.position - transform.right * speed * Time.deltaTime;
            }
            else
            {
                
                transform.position = transform.position + transform.right * speed * Time.deltaTime;
               
            }
        }
        

        // calculate the distance from the main camera
        float dist = Vector2.Distance(Camera.main.transform.position, transform.position);

        // if the distance is greater than the destroyDistance
        if (dist > destroyDistance)
        {
            DestroyNPC();
        }
    }

    public void changeDirection()
    {
        Vector3 scaleChange = new Vector3(transform.localScale.x, 0, 0);
        transform.localScale = transform.localScale - 2 * scaleChange;
        goLeft = !goLeft;
        disableLeftMovement = false;
    }

    public void DestroyNPC()
    {
        Destroy(this.gameObject);
    }


}
