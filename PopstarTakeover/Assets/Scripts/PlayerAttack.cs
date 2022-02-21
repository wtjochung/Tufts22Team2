using System.Collections.Generic;
using System.Collections;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{

    //public Animator animator;
    public Transform firePoint;
    public GameObject projectilePrefab;
    public float projectileSpeed = 10f;
      public float attackRate = 2f;
    private float nextAttackTime = 0f;

    void Start()
    {
        //animator = gameObject.GetComponentInChildren<Animator>();
    }

    void Update()
    {
        if (Time.time >= nextAttackTime)
        {
            //if (Input.GetKeyDown(KeyCode.Space))
            if (Input.GetAxis("Attack") > 0)
            {
                playerFire();
                nextAttackTime = Time.time + 1f / attackRate;
            }
        }
    }

    void playerFire()
    {
        //animator.SetTrigger ("Fire");
        GameObject projectile = Instantiate(projectilePrefab, firePoint.position, Quaternion.identity);
        //projectile.AddForce(fwd * projectileSpeed, ForceMode.Impulse);TODO
    }
}