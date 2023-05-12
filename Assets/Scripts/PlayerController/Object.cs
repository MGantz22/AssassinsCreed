using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Object : MonoBehaviour
{
   public float objecthealth = 120f;

   public void objectHitDamage(float amount)
   {
        objecthealth -= amount;

        if(objecthealth <= 0f)
        {
            DestroyObject();
        }
    }

    void DestroyObject()
    {
        Destroy(gameObject);
    }
}
