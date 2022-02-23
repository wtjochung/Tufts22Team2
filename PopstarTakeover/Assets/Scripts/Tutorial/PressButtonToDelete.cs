using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressButtonToDelete : MonoBehaviour
{
  
    public GameObject upArrow;
    public GameObject downArrow;

    GameObject up;
    GameObject down;

    // Start is called before the first frame update
    void Start()
    {
        Vector3 y = new Vector3(0, 1, 0);
        up = Instantiate(upArrow, transform.position + y, transform.rotation);
        down = Instantiate(downArrow, transform.position - y, transform.rotation);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetAxis("Vertical") > 0)
        {
            Destroy(up);
        } else if (Input.GetAxis("Vertical") < 0)
        {
            Destroy(down);
        } 
    }
}
