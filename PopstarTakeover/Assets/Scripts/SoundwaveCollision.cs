using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundwaveCollision : MonoBehaviour
{
    private bool gotHit = false;
    public GameObject hitEffect;

    public int scoreIncreaseWhenHit;
    public int scoreIncreaseAtScorezone;
    // Start is called before the first frame update
    void Start()
    {

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
            else if (collision.gameObject.tag == "Attack")
            {
                //EnemyLives -= EnemyLives;
                //rend.material.color = new Color(2.4f, 0.9f, 0.9f, 0.5f);

                NPCMovement m = gameObject.GetComponent<NPCMovement>();
                m.changeDirection();
                gotHit = true;
                GameHandler.gotScore += scoreIncreaseWhenHit;


                if (hitEffect != null)
                {
                    Instantiate(hitEffect, transform.position, transform.rotation, null);
                }

                if (name.Contains("Fan"))
                {
                    GameHandler.fanLost++;
                }
                else if (name.Contains("Paparazzi"))
                {
                    GameHandler.paparazziLost++;
                }

                //Destroy(gameObject);
                //Debug.Log("soundwave collision");
            }
            else if (collision.gameObject.tag == "Scorezone")
            {
                Debug.Log("in scorezone, name: " + name);
                GameHandler.gotScore += scoreIncreaseAtScorezone;
                if (name.Contains("Fan"))
                {
                    GameHandler.fanSaved++;
                    Debug.Log("fan saved: " + GameHandler.fanSaved);
                } else if (name.Contains("Paparazzi"))
                {
                    GameHandler.paparazziSaved++;
                    Debug.Log("paparazzi saved: " + GameHandler.paparazziSaved);
                }

            }
        }
    }
}
