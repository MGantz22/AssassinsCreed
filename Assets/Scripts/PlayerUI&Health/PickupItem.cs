using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupItem : MonoBehaviour
{
    [Header("Item Info")]
    public int itemRadius;
    public string ItemTag;
    private GameObject ItemToPick;

    [Header("Player Info")]
    public Transform player;
    public Inventory inventory;
    public GameManager GM;


    private void Start()
    {
        ItemToPick = GameObject.FindWithTag(ItemTag);

    }

    private void Update()
    {
        if(Vector3.Distance(transform.position, player.transform.position) < itemRadius)
        {
            if(Input.GetKeyDown("f"))
            {
                if(ItemTag == "Sword")
                {
                    inventory.isWeapon1Picked = true;
                }

                else if(ItemTag == "Rifle")
                {
                    inventory.isWeapon2Picked = true;
                }

                else if(ItemTag == "Bazooka")
                {
                    inventory.isWeapon3Picked = true;
                }

                else if(ItemTag == "Grenade")
                {
                    GM.numberofGrenades += 5;
                    inventory.isWeapon4Picked = true;
                }

                else if(ItemTag == "Health")
                {
                    GM.numberofHealth += 1;
                }

                else if(ItemTag == "Energy")
                {
                    GM.numberofEnergy += 1;
                }

                ItemToPick.SetActive(false);
            }
        }
    }


   
}
