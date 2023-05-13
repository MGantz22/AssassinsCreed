using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rifle : MonoBehaviour
{
   [Header("Rifle Things")]
   public Transform shootingArea;
   public float giveDamage = 10f;
   public float shootingRange = 100f;

   [Header("Rifle Ammo and reloading")]
   private int maximumAmmunition = 1;
   public int presentAmmunition;
   public int mag;
   public float reloadingTime;
   private bool setReloading;

   private void Start()
   {
        presentAmmunition = maximumAmmunition;
   }




   private void Update()
   {
        if(setReloading)
            return;

        if(presentAmmunition <= 0 && mag > 0)    
        {
            StartCoroutine(Reload());
            return;
        }

        if(Input.GetMouseButtonDown(0))
        {   
            Shoot();
        }
        
   }

   void Shoot()
   {
        if(mag <= 0)
        {
            //show out UI
            return;
        }

        presentAmmunition--;

        if(presentAmmunition == (0))
        {
            mag--;
        }

        RaycastHit hitInfo;

        if(Physics.Raycast(shootingArea.position, shootingArea.forward, out hitInfo, shootingRange))
        {
            KnightAI knightAI = hitInfo.transform.GetComponent<KnightAI>();

            if(knightAI != null)
            {
                knightAI.TakeDamage(giveDamage);
            }
        }
   }

   IEnumerator Reload()
   {
        setReloading = true;
        //reloading anim
        yield return new WaitForSeconds(reloadingTime);
        presentAmmunition = maximumAmmunition;
        setReloading = false;
   }
}
