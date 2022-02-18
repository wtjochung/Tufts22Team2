using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundwaveCollision : MonoBehaviour
{
    private bool gotHit = false;
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("start");
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        //Debug.Log("collision");
        if (!gotHit)
        {
            if (collision.gameObject.tag == "Player")
            {
                //EnemyLives -= 1;
                //StopCoroutine("HitEnemy");
                //StartCoroutine("HitEnemy");
                //Destroy(gameObject);
                Debug.Log("player collision");
            }
            else if (collision.gameObject.tag == "Soundwave")
            {
                //EnemyLives -= EnemyLives;
                //rend.material.color = new Color(2.4f, 0.9f, 0.9f, 0.5f);

                NPCMovement m = gameObject.GetComponent<NPCMovement>();
                m.changeDirection();
                gotHit = true;
                //Destroy(gameObject);
                //Debug.Log("soundwave collision");
            }
        }
    }
}
