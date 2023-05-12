using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grenade : MonoBehaviour
{
    public float grenadeTimer = 3f;
    public float radius = 10f;
    float countDown;
    public float giveDamage = 120f;

    public GameObject explosionEffect;

    bool hasExploded = false;

    private void Start()
    {
        countDown = grenadeTimer;
    }

    private void Update()
    {
        countDown -= Time.deltaTime;

        if(countDown <= 0f && !hasExploded)
        {
            Explode();
            hasExploded = true;
        }
    }

    void Explode()
    {
        // //show Effect
        Instantiate(explosionEffect, transform.position, transform.rotation);

        //get close Objects
        Collider[] colliders = Physics.OverlapSphere(transform.position, radius);

        foreach (Collider nearbyObject in colliders)
        {
            //add force

            //damage
            Object obj = nearbyObject.GetComponent<Object>();

            if(obj != null)
            {
                obj.objectHitDamage(giveDamage);
            }
        }

        Destroy(gameObject);
    }
}
