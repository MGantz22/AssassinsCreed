using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public int numberofGrenades;
    public int numberofHealth;
    public int numberofEnergy;

    [Header("Ammo & Mag")]
    public Rifle rifle;
    public Bazooka bazooka;
    public Text RifleAmmoText;
    public Text RifleMagText;
    public Text BazookaAmmoText;
    public Text BazookaMagText;

    private void Update()
    {
        RifleAmmoText.text = "" + rifle.presentAmmunition;
        RifleMagText.text = "" + rifle.mag;
        BazookaAmmoText.text = "" + bazooka.presentAmmunition;
        BazookaMagText.text = "" + bazooka.mag;
    }
}
