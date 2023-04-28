using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Parkour Menu/Create New Parkour Action")]
public class NewParkourAction : ScriptableObject
{
    [SerializeField] string animationName;
    [SerializeField] float minimumHeight;
    [SerializeField] float maximumHeight;

    public bool CheckIfAvailable(ObstacleInfo hitInfo, transform player)
    {
        float checkHeight = hitInfo.heightInfo.point.y - player.position.y;

        if(checkHeight < minimumHeight || checkHeight > maximumHeight)
            return false;

        return true;
    }
}
