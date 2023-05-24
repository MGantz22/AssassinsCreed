using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public int numberofGrenades;
    public int numberofHealth;
    public int numberofEnergy;

    [Header("Stocks")]
    public Text GrenadeStock1;
    public Text GrenadeStock2;
    public Text HealthStock;
    public Text EnergyStock;

    [Header("Health & Energy")]
    public GameObject healthSlot;
    public GameObject energySlot;




    [Header("Ammo & Mag")]
    public Rifle rifle;
    public Bazooka bazooka;
    public Text RifleAmmoText;
    public Text RifleMagText;
    public Text BazookaAmmoText;
    public Text BazookaMagText;

    private void Update()
    {
        //show Ammo and Mag stock for Guns
        RifleAmmoText.text = "" + rifle.presentAmmunition;
        RifleMagText.text = "" + rifle.mag;
        BazookaAmmoText.text = "" + bazooka.presentAmmunition;
        BazookaMagText.text = "" + bazooka.mag;

        //show stock for grenade and pots
        GrenadeStock1.text = "" + numberofGrenades;
        GrenadeStock2.text = "" + numberofGrenades;
        HealthStock.text = "" + numberofHealth;
        EnergyStock.text = "" + numberofEnergy;

        if(numberofHealth > 0)
        {
            healthSlot.SetActive(true);
        }
        else if(numberofHealth <= 0)
        {
            healthSlot.SetActive(false);
        }

        if(numberofEnergy > 0)
        {
            energySlot.SetActive(true);
        }
        else if(numberofEnergy <= 0)
        {
            energySlot.SetActive(false);
        }


    }
}
