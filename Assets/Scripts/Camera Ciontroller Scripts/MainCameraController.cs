using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCameraController : MonoBehaviour
{
    [Header("Camera Controller")]
    public Transform target;
    public float gap = 3f;
    public float rotSpeed = 2f;

    [Header("Camera handling")]
    public float minVerAngle = -14f;
    public float maxVerAngle = 45f;
    public Vector2 framingBalance;
    float rotX;
    float rotY;
    public bool invertX;
    public bool invertY;
    float invertXValue;
    float invertYValue;


    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void Update()
    {
        invertXValue = (invertX) ? -1 : 1;
        invertYValue = (invertY) ? -1 : 1;

        rotX += Input.GetAxis("Mouse Y") * invertYValue * rotSpeed;
        rotX = Mathf.Clamp(rotX, minVerAngle, maxVerAngle);
        rotY += Input.GetAxis("Mouse X") * invertXValue * rotSpeed;

        var targetRotation = Quaternion.Euler(rotX, rotY, 0);

        var focusPos = target.position + new Vector3(framingBalance.x, framingBalance.y);


        transform.position = focusPos - targetRotation * new Vector3(0, 0, gap);
        transform.rotation = targetRotation;
    }

    public Quaternion flatRotation => Quaternion.Euler(0, rotY, 0);
}
