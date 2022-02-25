using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class projectileAttack : MonoBehaviour
{
   
    public int damage = 1;
    public float speed = 10f;
    public GameObject hitEffectAnim;
    public float SelfDestructTime = 10.0f;

    public float scale = 1f;
    private Vector3 scaleChange;



    void Start()
    {
        StartCoroutine(selfDestruct());
        scaleChange = new Vector3(scale-1, scale-1, scale-1);
        //gameObject.AddForce(fwd * projectileSpeed, ForceMode.Impulse);
    }

    private void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, transform.position + transform.right, speed * Time.deltaTime);
       
    }

    //if the bullet hits a collider, play the explosion animation, then destroy the effect and the bullet
    void OnTriggerEnter2D(Collider2D other)
    {
        //Debug.Log("note hits other object");
        if (other.gameObject.tag != "Player")
        {
            
            GameObject animEffect = Instantiate(hitEffectAnim, transform.position, Quaternion.identity);
            animEffect.transform.localScale += scaleChange;
            Destroy(animEffect, 0.5f);
            Destroy(gameObject);
        }
    }
    
    IEnumerator selfDestruct()
    {
        yield return new WaitForSeconds(SelfDestructTime);
        Destroy(gameObject);
    }
    
}
