using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParkourControllerScript : MonoBehaviour
{
    public EnvironmentChecker environmentChecker;

    private void Update()
    {
       var hitData = environmentChecker.CheckObstacle();

       if(hitData.hitFound)
        {
            Debug.Log("Object Founded" + hitData.hitInfo.transform.name);
        }
    }
}
