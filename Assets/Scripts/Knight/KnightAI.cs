using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnightAI : MonoBehaviour
{
    [Header("Character Info")]
   public float movingSpeed;
   public float runningSpeed;
   public float CurrentmovingSpeed;
   public float turningSpeed = 300f;
   public float stopSpeed = 1f;
   public float maxHealth = 120f;
    public float currenthealth;


   [Header("Destination Var")]
   public Vector3 destination;
   public bool destinationReached;


   [Header("Knight AI")]
   public GameObject playerBody;
   public LayerMask playerLayer;
   public float visionRadius;
   public float attackRadius;
   public bool playerInvisionRadius;
   public bool playerInattackRadius;


   [Header("Knight Attack Var")]
   public int SingleMeleeVal;
   public Transform attackArea;
   public float giveDamage;
   public float attackingRadius;
   bool previouslyAttack;
   public float timebtwAttack;
   public Animator anim;
    
    private void Start()
    {
        CurrentmovingSpeed = movingSpeed;
        currenthealth = maxHealth;
        playerBody = GameObject.Find("Player");
    }

   private void Update()
   {
        playerInvisionRadius = Physics.CheckSphere(transform.position, visionRadius, playerLayer);
        playerInattackRadius = Physics.CheckSphere(transform.position, attackRadius, playerLayer);

        if(!playerInvisionRadius && !playerInattackRadius)
        {
            anim.SetBool("Idle", false);
            Walk();
        }

        if(playerInvisionRadius && !playerInattackRadius)
        {
            anim.SetBool("Idle", false);
            ChasePlayer();
        }

        if(playerInvisionRadius && playerInattackRadius)
        {
            anim.SetBool("Idle", true);
            SingleMeleeModes();
        } 
   }

   public void Walk()
   {
        CurrentmovingSpeed = movingSpeed;
        if(transform.position != destination)
        {
            Vector3 destinationDirection = destination - transform.position;
            destinationDirection.y = 0;
            float destinationDistance = destinationDirection.magnitude;

            if(destinationDistance >= stopSpeed)
            {
                //turning
                destinationReached = false;
                Quaternion targetRotation = Quaternion.LookRotation(destinationDirection);
                transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, turningSpeed * Time.deltaTime);

                //Moving AI
                transform.Translate(Vector3.forward * CurrentmovingSpeed * Time.deltaTime);

                anim.SetBool("Walk", true);
                anim.SetBool("Attack", false);
                anim.SetBool("Run", false);
            }
            else
            {
                destinationReached = true;
            }
        }
   }

    void ChasePlayer()
    {
        CurrentmovingSpeed = runningSpeed;
        transform.position += transform.forward * CurrentmovingSpeed * Time.deltaTime;
        transform.LookAt(playerBody.transform);

        anim.SetBool("Walk", false);
        anim.SetBool("Attack", false);
        anim.SetBool("Run", true);
           
    }

    void SingleMeleeModes()
    {
        if(!previouslyAttack)
        {
            SingleMeleeVal = Random.Range(1, 5); 

            if(SingleMeleeVal == 1)
            {          
                Attack();
                StartCoroutine(Attack1());
            }

            if(SingleMeleeVal == 2)
            {
                Attack();
                StartCoroutine(Attack2());
            }

            if(SingleMeleeVal == 3)
            {              
                Attack();
                StartCoroutine(Attack3());
            }

            if(SingleMeleeVal == 4)
            {  
                Attack();
                StartCoroutine(Attack4());
            }
        }
    }

     void Attack()
    {
        Collider[] hitPlayer = Physics.OverlapSphere(attackArea.position, attackingRadius, playerLayer);

        foreach(Collider player in hitPlayer)
        {
            PlayerScript playerScript = player.GetComponent<PlayerScript>();

            if(playerScript != null)
            {
                playerScript.playerHitDamage(giveDamage);
                
            }
        }

        previouslyAttack = true;
        Invoke(nameof(ActiveAttack), timebtwAttack);
    }

    private void OnDrawGizmosSelected()
    {
        if(attackArea == null)
            return;

        Gizmos.DrawWireSphere(attackArea.position, attackingRadius);
    }

    private void ActiveAttack()
    {
        previouslyAttack = false;
    }

    IEnumerator Attack1()
    {
        anim.SetBool("Attack1", true);
        movingSpeed = 0f;
        runningSpeed = 0f;
        yield return new WaitForSeconds(0.2f);
        anim.SetBool("Attack1", false);
        movingSpeed = 1f;
        runningSpeed = 3f;
    }

    IEnumerator Attack2()
    {
        anim.SetBool("Attack2", true);
        movingSpeed = 0f;
        runningSpeed = 0f;
        yield return new WaitForSeconds(0.2f);
        anim.SetBool("Attack2", false);
        movingSpeed = 1f;
        runningSpeed = 3f;
    }

    IEnumerator Attack3()
    {
        anim.SetBool("Attack3", true);
        movingSpeed = 0f;
        runningSpeed = 0f;
        yield return new WaitForSeconds(0.2f);
        anim.SetBool("Attack3", false);
        movingSpeed = 1f;
        runningSpeed = 3f;
    }
    
    IEnumerator Attack4()
    {
        anim.SetBool("Attack4", true);
        movingSpeed = 0f;
        runningSpeed = 0f;
        yield return new WaitForSeconds(0.2f);
        anim.SetBool("Attack4", false);
        movingSpeed = 1f;
        runningSpeed = 3f;
    }

   public void LocateDestination(Vector3 destination)
   {
        this.destination = destination;
        destinationReached = false;
   }

   public void TakeDamage(float amount)
   {
        currenthealth -= amount;

        anim.SetTrigger("GetHit");

        if(currenthealth <= 0f)
        {
            Die();
        }
    }

    void Die()
    {
        anim.SetBool("isDead", true);
        this.enabled = false;
        GetComponent<Collider>().enabled = false;
    }
}
