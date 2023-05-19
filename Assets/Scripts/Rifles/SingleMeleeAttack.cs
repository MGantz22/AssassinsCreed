using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SingleMeleeAttack : MonoBehaviour
{
    public int SingleMeleeVal;
    public Animator anim;
    public PlayerScript playerScript;

    public Transform attackArea;
    public float giveDamage = 10f;
    public float attackRadius;
    public LayerMask knightLayer;

    private void Update()
    {
        SingleMeleeModes();
    }

    void SingleMeleeModes()
    {
        if(Input.GetMouseButtonDown(0))
        {
            SingleMeleeVal = Random.Range(1, 7);  //Max range is set to 7 because and incase same attack is called back to back.

            if(SingleMeleeVal == 1)
            {
                Attack();
                StartCoroutine(SingleAttack1());
            }

            if(SingleMeleeVal == 2)
            {
                Attack();
                StartCoroutine(SingleAttack2());
            }

            if(SingleMeleeVal == 3)
            {
                Attack();
                StartCoroutine(SingleAttack3());
            }

            if(SingleMeleeVal == 4)
            {
                Attack();
                StartCoroutine(SingleAttack4());
            }

            if(SingleMeleeVal == 5)
            {
                Attack();
                StartCoroutine(SingleAttack5());
            }
        }
    }

    void Attack()
    {
        Collider[] hitKnight = Physics.OverlapSphere(attackArea.position, attackRadius, knightLayer);

        foreach(Collider Knight in hitKnight)
        {
            KnightAI knightAI = Knight.GetComponent<KnightAI>();

            if(knightAI != null)
            {
                knightAI.TakeDamage(giveDamage);
            }
            
        }
    }

    private void OnDrawGizmosSelected()
    {
        if(attackArea == null)
            return;

        Gizmos.DrawWireSphere(attackArea.position, attackRadius);
    }

    IEnumerator SingleAttack1()
    {
        anim.SetBool("SingleAttack1", true);
        playerScript.movementSpeed = 0f;
        anim.SetFloat("movementValue", 0f);
        yield return new WaitForSeconds(0.2f);
        anim.SetBool("SingleAttack1", false);
        playerScript.movementSpeed = 5f;
        anim.SetFloat("movementValue", 0f);
    }

    IEnumerator SingleAttack2()
    {
        anim.SetBool("SingleAttack2", true);
        playerScript.movementSpeed = 0f;
        anim.SetFloat("movementValue", 0f);
        yield return new WaitForSeconds(0.2f);
        anim.SetBool("SingleAttack2", false);
        playerScript.movementSpeed = 5f;
        anim.SetFloat("movementValue", 0f);
    }

    IEnumerator SingleAttack3()
    {
        anim.SetBool("SingleAttack3", true);
        playerScript.movementSpeed = 0f;
        anim.SetFloat("movementValue", 0f);
        yield return new WaitForSeconds(0.2f);
        anim.SetBool("SingleAttack3", false);
        playerScript.movementSpeed = 5f;
        anim.SetFloat("movementValue", 0f);
    }

    IEnumerator SingleAttack4()
    {
        anim.SetBool("SingleAttack4", true);
        playerScript.movementSpeed = 0f;
        anim.SetFloat("movementValue", 0f);
        yield return new WaitForSeconds(0.2f);
        anim.SetBool("SingleAttack4", false);
        playerScript.movementSpeed = 5f;
        anim.SetFloat("movementValue", 0f);
    }

    IEnumerator SingleAttack5()
    {
        anim.SetBool("SingleAttack5", true);
        playerScript.movementSpeed = 0f;
        anim.SetFloat("movementValue", 0f);
        yield return new WaitForSeconds(0.2f);
        anim.SetBool("SingleAttack5", false);
        playerScript.movementSpeed = 5f;
        anim.SetFloat("movementValue", 0f);
    }
}
