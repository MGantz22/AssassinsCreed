using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    [Header("Player Movement")]
    public float movementSpeed = 5f;
    public float rotSpeed = 450f;
    public MainCameraController MCC;
    public EnvironmentChecker environmentChecker;
    Quaternion requiredRotation;
    bool playerControl = true;


    [Header("Player Animator")]
    public Animator animator;


    [Header("Player Collision & Gravity")]
    public CharacterController CC;
    public float surfaceCheckRadious = 0.1f;
    public Vector3 surfaceCheckOffset;
    public LayerMask surfaceLayer;
    bool onSurface;
    public bool playerOnLedge{ get; set; }
    public LedgeInfo LedgeInfo { get; set; }
    [SerializeField] float fallingSpeed;
    [SerializeField] Vector3 moveDir;
    [SerializeField] Vector3 requiredMoveDir;
    Vector3 velocity;



    private void Update()
    {
        if(!playerControl)
            return;

        velocity = Vector3.zero;
        if(onSurface)
        {
            fallingSpeed = -0.5f;
            velocity = moveDir * movementSpeed;
            
            playerOnLedge = environmentChecker.CheckLedge(moveDir, out LedgeInfo ledgeInfo);
            if(playerOnLedge)
            {
                LedgeInfo = ledgeInfo;
                playerLedgeMovement();
                Debug.Log("player on ledge");
            }

            animator.SetFloat("movementValue", velocity.magnitude / movementSpeed, 0.2f, Time.deltaTime);


        }
        else
        {
            fallingSpeed += Physics.gravity.y * Time.deltaTime;

            velocity = transform.forward * movementSpeed / 2;
        }

        
        velocity.y = fallingSpeed;

        PlayerMovement();
        SurfaceCheck();
        animator.SetBool("onSurface", onSurface);
        Debug.Log("Player on Surface" + onSurface);
    }

    void PlayerMovement()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        float movementAmount = Mathf.Clamp01(Mathf.Abs(horizontal) + Mathf.Abs(vertical));

        var movementInput = (new Vector3(horizontal, 0, vertical)).normalized;

        requiredMoveDir = MCC.flatRotation * movementInput;

        CC.Move(velocity * Time.deltaTime);

        if (movementAmount > 0 && moveDir.magnitude > 0.2f)
        {
            requiredRotation = Quaternion.LookRotation(moveDir);
        }

        moveDir = requiredMoveDir;

        transform.rotation = Quaternion.RotateTowards(transform.rotation, requiredRotation, rotSpeed * Time.deltaTime);

        animator.SetFloat("movementValue", movementAmount, 0.2f, Time.deltaTime);
    }

    void SurfaceCheck()
    {
        onSurface = Physics.CheckSphere(transform.TransformPoint(surfaceCheckOffset), surfaceCheckRadious, surfaceLayer);
    }

    void playerLedgeMovement()
    {
        float angle = Vector3.Angle(LedgeInfo.surfaceHit.normal, requiredMoveDir);

        if(angle < 90)
        {
            velocity = Vector3.zero;
            moveDir = Vector3.zero;
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawSphere(transform.TransformPoint(surfaceCheckOffset), surfaceCheckRadious);
    }

    public void SetControl(bool hasControl)
    {
        this.playerControl = hasControl;
        CC.enabled = hasControl;

        if(!hasControl)
        {
            animator.SetFloat("movementValue", 0f);
            requiredRotation = transform.rotation;
        }
    }
}
