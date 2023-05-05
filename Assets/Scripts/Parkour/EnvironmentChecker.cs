using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnvironmentChecker : MonoBehaviour
{
    public Vector3 rayOffset = new Vector3(0, 0.2f, 0);
    public float rayLength = 0.9f;
    public float heightRayLength = 6f;
    public LayerMask obstacleLayer;

    [Header("Check Ledges")]
    [SerializeField] float ledgeRayLength = 11f;
    [SerializeField] float ledgeRayHeightThreshold = 0.76f;

    public ObstacleInfo CheckObstacle()
    {

        var hitData = new ObstacleInfo();

        var rayOrigin = transform.position + rayOffset;
        hitData.hitFound = Physics.Raycast(rayOrigin, transform.forward, out hitData.hitInfo, rayLength, obstacleLayer);

        Debug.DrawRay(rayOrigin, transform.forward * rayLength, (hitData.hitFound) ? Color.red : Color.green);

        if(hitData.hitFound)
        {
            var heightOrigin = hitData.hitInfo.point + Vector3.up * heightRayLength;
            hitData.heightHitFound = Physics.Raycast(heightOrigin, Vector3.down, out hitData.heightInfo, heightRayLength, obstacleLayer);

            Debug.DrawRay(heightOrigin, Vector3.down * heightRayLength, (hitData.heightHitFound) ? Color.blue : Color.green);


        }

        return hitData;
    }

    public bool CheckLedge(Vector3 movementDirection)
    {
        if(movementDirection == Vector3.zero)
            return false;

        float ledgeOriginOffset = 0.5f;  
        var ledgeOrigin = transform.position + movementDirection * ledgeOriginOffset + Vector3.up;

        if(Physics.Raycast(ledgeOrigin, Vector3.down, out RaycastHit hit, ledgeRayLength, obstacleLayer))
        {
            Debug.DrawRay(ledgeOrigin, Vector3.down * ledgeRayLength, Color.blue);
            float Ledgeheight = transform.position.y - hit.point.y;

            if(Ledgeheight > ledgeRayHeightThreshold)
            {
                return true;
            }
        }

        return false; 
    }
}

public struct ObstacleInfo
{
    public bool hitFound;
    public bool heightHitFound;
    public RaycastHit hitInfo;
    public RaycastHit heightInfo;
}