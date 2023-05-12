using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FistFight : MonoBehaviour
{
    public float Timer = 0f;

    public int FistFightVal;
    public Animator anim;
    public PlayerScript playerScript;

    public Transform attackArea;
    public float giveDamage = 10f;
    public float attackRadius;
    public LayerMask knightLayer;

    [SerializeField] Transform LeftHandPunch;
    [SerializeField] Transform RightHandPunch;
    [SerializeField] Transform LeftLegKick;

    private void Update()
    {
        if(!Input.GetMouseButtonDown(0))
        {
            Timer += Time.deltaTime;
        }
        else
        {
            playerScript.movementSpeed = 3f;
            anim.SetBool("FistFightActive", true);
            Timer = 0f;
        }

        if(Timer > 5f)
        {
            playerScript.movementSpeed = 5f;
           anim.SetBool("FistFightActive", false);
        }

        FistFightModes();
    }

    void FistFightModes()
    {
        if(Input.GetMouseButtonDown(0))
        {
            FistFightVal = Random.Range(1, 7);  //Max range is set to 7 because and incase same attack is called back to back.

            if(FistFightVal == 1)
            {
                //Attack
                attackArea = LeftHandPunch;
                attackRadius = 0.5f;
                Attack();
                //Animation
                StartCoroutine(SingleFist());
            }

            if(FistFightVal == 2)
            {
                //Attack
                attackArea = RightHandPunch;
                attackRadius = 0.6f;
                Attack();
                StartCoroutine(DoubleFist());
            }

            if(FistFightVal == 3)
            {
                //Attack
                attackArea = LeftHandPunch;
                attackArea = LeftLegKick;
                attackRadius = 0.7f;
                Attack();
                StartCoroutine(FirstFistKick());
            }

            if(FistFightVal == 4)
            {
                  //Attack
                attackArea = LeftLegKick;
                attackRadius = 0.9f;
                Attack();
                StartCoroutine(KickCombo());
            }

            if(FistFightVal == 5)
            {
                 //Attack
                attackArea = LeftLegKick;
                attackRadius = 0.9f;
                Attack();
                StartCoroutine(Leftkick());
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

    IEnumerator SingleFist()
    {
        anim.SetBool("SingleFist", true);
        playerScript.movementSpeed = 0f;
        anim.SetFloat("movementValue", 0f);
        yield return new WaitForSeconds(0.7f);
        anim.SetBool("SingleFist", false);
        playerScript.movementSpeed = 5f;
        anim.SetFloat("movementValue", 0f);
    }

    IEnumerator DoubleFist()
    {
        anim.SetBool("DoubleFist", true);
        playerScript.movementSpeed = 0f;
        anim.SetFloat("movementValue", 0f);
        yield return new WaitForSeconds(0.4f);
        anim.SetBool("DoubleFist", false);
        playerScript.movementSpeed = 5f;
        anim.SetFloat("movementValue", 0f);
    }

    IEnumerator FirstFistKick()
    {
        anim.SetBool("FirstFistKick", true);
        playerScript.movementSpeed = 0f;
        anim.SetFloat("movementValue", 0f);
        yield return new WaitForSeconds(0.4f);
        anim.SetBool("FirstFistKick", false);
        playerScript.movementSpeed = 5f;
        anim.SetFloat("movementValue", 0f);
    }

    IEnumerator KickCombo()
    {
        anim.SetBool("KickCombo", true);
        playerScript.movementSpeed = 0f;
        anim.SetFloat("movementValue", 0f);
        yield return new WaitForSeconds(0.4f);
        anim.SetBool("KickCombo", false);
        playerScript.movementSpeed = 5f;
        anim.SetFloat("movementValue", 0f);
    }

    IEnumerator Leftkick()
    {
        anim.SetBool("LeftKick", true);
        playerScript.movementSpeed = 0f;
        anim.SetFloat("movementValue", 0f);
        yield return new WaitForSeconds(0.4f);
        anim.SetBool("LeftKick", false);
        playerScript.movementSpeed = 5f;
        anim.SetFloat("movementValue", 0f);
    }
}
