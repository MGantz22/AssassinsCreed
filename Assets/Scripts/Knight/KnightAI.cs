using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnightAI : MonoBehaviour
{
    public float maxHealth = 120f;
    public float currenthealth;

    private void Start()
    {
        currenthealth = maxHealth;
    }

   public void TakeDamage(float amount)
   {
        currenthealth -= amount;

        if(currenthealth <= 0f)
        {
            Die();
        }
    }

    void Die()
    {
        Destroy(gameObject);
    }
}
