using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    [Header("Weapon 1 Slot")]
    public GameObject Weapon1;
    public bool isWeapon1Picked = false;
     public bool isWeapon1Active = false;
     public SingleMeleeAttack SMAS;

     public bool fistFightMode = false;

     [Header("Weapon 2 Slot")]
     public GameObject Weapon2;
     public bool isWeapon2Picked = false;
     public bool isWeapon2Active = false;
     public Rifle rifle;

     [Header("Weapon 3 Slot")]
     public GameObject Weapon3;
     public bool isWeapon3Picked = false;
     public bool isWeapon3Active = false;
     public Bazooka bazooka;

     [Header("Weapon 4 Slot")]
     public GameObject Weapon4;
     public bool isWeapon4Picked = false;
     public bool isWeapon4Active = false;
     public GrenadeThrower grenadethrower;

     [Header("Scripts")]
     public FistFight fistFight;
     public PlayerScript playerScript;
     public GameManager GM;
     public Animator anim;

     [Header("Current Weapons")]
     public GameObject NoWeapon;
     public GameObject CurrentWeapon1;
     public GameObject CurrentWeapon2;
     public GameObject CurrentWeapon3;
     public GameObject CurrentWeapon4;

     private void Update()
     {
        if(isWeapon1Active == false && isWeapon2Active == false && isWeapon3Active == false && isWeapon4Active == false && fistFightMode == false)
        {
            NoWeapon.SetActive(true);
        }
        if(Input.GetMouseButtonDown(0) && isWeapon1Active == false && isWeapon2Active == false && isWeapon3Active == false && isWeapon4Active == false && fistFightMode == false)
        {
            fistFightMode = true;
            isRifleActive();
        }

        if(Input.GetKeyDown("1") && isWeapon1Active == false && isWeapon2Active == false && isWeapon3Active == false && isWeapon4Active == false && isWeapon1Picked == true)
        {
            isWeapon1Active = true;
            isRifleActive();
            CurrentWeapon1.SetActive(true);
            NoWeapon.SetActive(false);
        }
        else if(Input.GetKeyDown("1") && isWeapon1Active == true)
        {
            isWeapon1Active = false;
            isRifleActive();
            CurrentWeapon1.SetActive(false);
        }

        if(Input.GetKeyDown("2") && isWeapon1Active == false && isWeapon2Active == false && isWeapon3Active == false && isWeapon4Active == false && isWeapon2Picked == true)
        {
            isWeapon2Active = true;
            isRifleActive();
            CurrentWeapon2.SetActive(true);
            NoWeapon.SetActive(false);
        }
        else if(Input.GetKeyDown("2") && isWeapon2Active == true)
        {
            isWeapon2Active = false;
            isRifleActive();
            CurrentWeapon2.SetActive(false);
        }

        if(Input.GetKeyDown("3") && isWeapon1Active == false && isWeapon2Active == false && isWeapon3Active == false && isWeapon4Active == false && isWeapon3Picked == true)
        {
            isWeapon3Active = true;
            isRifleActive();
            CurrentWeapon3.SetActive(true);
            NoWeapon.SetActive(false);
        }
        else if(Input.GetKeyDown("3") && isWeapon3Active == true)
        {
            isWeapon3Active = false;
            isRifleActive();
            CurrentWeapon3.SetActive(false);
        }

         if(Input.GetKeyDown("4") && isWeapon1Active == false && isWeapon2Active == false && isWeapon3Active == false && isWeapon4Active == false && isWeapon4Picked == true)
        {
            isWeapon4Active = true;
            isRifleActive();
            CurrentWeapon4.SetActive(true);
            NoWeapon.SetActive(false);
        }
        else if(Input.GetKeyDown("4") && isWeapon4Active == true)
        {
            isWeapon4Active = false;
            isRifleActive();
            CurrentWeapon4.SetActive(false);
        }

        if(Input.GetKeyDown("5") && isWeapon1Active == false && isWeapon2Active == false && isWeapon3Active == false && isWeapon4Active == false && GM.numberofHealth > 0)
        {
            StartCoroutine(IncreaseHealth());
        }

        if(Input.GetKeyDown("6") && isWeapon1Active == false && isWeapon2Active == false && isWeapon3Active == false && isWeapon4Active == false && GM.numberofEnergy > 0)
        {
            StartCoroutine(IncreaseEnergy());
        }
     }

     void isRifleActive()
     {
        if(fistFightMode == true)
        {
            fistFight.GetComponent<FistFight>().enabled = true;
        }

        if(isWeapon1Active == true)
        {
            StartCoroutine(Weapon1GO());
            SMAS.GetComponent<SingleMeleeAttack>().enabled = true;
            anim.SetBool("SingleHandAttackActive", true);
        }

        if(isWeapon1Active == false)
        {
            StartCoroutine(Weapon1GO());
            SMAS.GetComponent<SingleMeleeAttack>().enabled = false;
            anim.SetBool("SingleHandAttackActive", false);
        }

        if(isWeapon2Active == true)
        {
            StartCoroutine(Weapon2GO());
            rifle.GetComponent<Rifle>().enabled = true;
            anim.SetBool("RifleActive", true);
        }

        if(isWeapon2Active == false)
        {
            StartCoroutine(Weapon2GO());
            rifle.GetComponent<Rifle>().enabled = false;
            anim.SetBool("RifleActive", false);
        }

        if(isWeapon3Active == true)
        {
            StartCoroutine(Weapon3GO());
            bazooka.GetComponent<Bazooka>().enabled = true;
            anim.SetBool("BazookaActive", true);
        }

        if(isWeapon3Active == false)
        {
            StartCoroutine(Weapon3GO());
            bazooka.GetComponent<Bazooka>().enabled = false;
            anim.SetBool("BazookaActive", false);
        }

        if(isWeapon4Active == true)
        {
            StartCoroutine(Weapon4GO());
            grenadethrower.GetComponent<GrenadeThrower>().enabled = true;
        }

        if(isWeapon4Active == false)
        {
            StartCoroutine(Weapon4GO());
            grenadethrower.GetComponent<GrenadeThrower>().enabled = false; 
        }
     }

     IEnumerator Weapon1GO()
     {
        if(!isWeapon1Active)
        {
            Weapon1.SetActive(false);
        }
        yield return new WaitForSeconds(0.1f);
        if(isWeapon1Active)
        {
            Weapon1.SetActive(true);
        }
     }

     IEnumerator Weapon2GO()
     {
        if(!isWeapon2Active)
        {
            Weapon2.SetActive(false);
        }
        yield return new WaitForSeconds(0.1f);
        if(isWeapon2Active)
        {
            Weapon2.SetActive(true);
        }
     }

     IEnumerator Weapon3GO()
     {
        if(!isWeapon3Active)
        {
            Weapon3.SetActive(false);
        }
        yield return new WaitForSeconds(0.1f);
        if(isWeapon3Active)
        {
            Weapon3.SetActive(true);
        }
     }

     IEnumerator Weapon4GO()
     {
        if(!isWeapon4Active)
        {
            Weapon4.SetActive(false);
        }
        yield return new WaitForSeconds(0.1f);
        if(isWeapon4Active)
        {
            Weapon4.SetActive(true);
        }
     }

     IEnumerator IncreaseHealth()
     {
        anim.SetBool("Drink", true);
        yield return new WaitForSeconds(1.5f);
        anim.SetBool("Drink", false);
        GM.numberofHealth -= 1;
        playerScript.presentHealth = 200f;
        playerScript.healthbar.GiveFUllHealth(200f);
     }

     IEnumerator IncreaseEnergy()
     {
        anim.SetBool("Drink", true);
        yield return new WaitForSeconds(1.5f);
        anim.SetBool("Drink", false);
        GM.numberofEnergy -= 1;
        playerScript.presentEnergy = 100f;
        playerScript.energybar.GiveFUllEnergy(100f);
     }

}
