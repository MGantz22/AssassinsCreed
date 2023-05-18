using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bazooka : MonoBehaviour
{
    [Header("Bazooka Things")]
   public Transform shootingArea;
   public float giveDamage = 120f;
   public float shootingRange = 100f;
   public  Animator animator;
   public bool isMoving;
   public PlayerScript playerScript;

   [Header("Bazooka Ammo and reloading")]
   private int maximumAmmunition = 1;
   public int presentAmmunition;
   public int mag;
   public float reloadingTime;
   private bool setReloading;
   public GameObject crosshair;

   private void Start()
   {
        presentAmmunition = maximumAmmunition;
   }

   private void Update()
   {

        if(animator.GetFloat("movementValue") > 0.001f)
        {
            isMoving = true;
        }
         else if(animator.GetFloat("movementValue") < 0.0999999f)
        {
            isMoving = false;
        }

        if(setReloading)
            return;

        if(presentAmmunition <= 0 && mag > 0)    
        {
            StartCoroutine(Reload());
            return;
        }

        if(Input.GetMouseButtonDown(0) && isMoving == false)
        {
            animator.SetBool("BazookaActive", true);
            animator.SetBool("BazookaShooting", true); 
            Shoot();
        }
        else if(!Input.GetMouseButtonDown(0))
        {
            animator.SetBool("BazookaShooting", false);
        }

        if(Input.GetMouseButtonDown(1))
        {
            animator.SetBool("BazookaAim", true);
            //crosshair.SetActive(false);
        }

        else if(!Input.GetMouseButtonDown(1))
        {
            animator.SetBool("BazookaAim", false);
            //crosshair.SetActive(false);
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
        animator.SetFloat("movementValue", 0f);
        playerScript.movementSpeed = 0f;
        animator.SetBool("ReloadBazooka", true);
        //reloading anim
        yield return new WaitForSeconds(reloadingTime);
        animator.SetBool("ReloadBazooka", false);
        presentAmmunition = maximumAmmunition;
        setReloading = false;
        animator.SetFloat("movementValue", 0f);
        playerScript.movementSpeed = 5f;
        
   }
}
