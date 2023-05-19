using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrenadeThrower : MonoBehaviour
{
    public float throwForce = 10f;
    public Transform grenadeArea;
    public GameObject grenadePrefab;
    public Animator anim;

    public GameManager GM;

    private void Update()
    {
        if(Input.GetMouseButtonDown(0) && GM.numberofGrenades > 0)
        {
            //function
            StartCoroutine(GrenadeAnim());
            GM.numberofGrenades -= 1;
        }
        
    }

    void ThrowGrenade()
    {
        GameObject grenade = Instantiate(grenadePrefab, grenadeArea.transform.position, grenadeArea.transform.rotation);
        Rigidbody rb = grenade.GetComponent<Rigidbody>();
        rb.AddForce(grenadeArea.transform.forward * throwForce, ForceMode.VelocityChange);
    }

    IEnumerator GrenadeAnim()
    {
        anim.SetBool("GrenadeInAir", true);
        yield return new WaitForSeconds(0.5f);
        ThrowGrenade();
        yield return new WaitForSeconds(1f);
        anim.SetBool("GrenadeInAir", false);
    }
}
