using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRotation : MonoBehaviour
{
    [SerializeField]
    private Transform playerHeadTransform;
    [SerializeField]
    private Transform playerFullTransform;

    private float xAxisClamp;
    private Quaternion quaternionToRotate;

    private void Awake()
    {
        xAxisClamp = 0;
    }

    public void rotatePlayer(float horizonRotationVal, float vertiRotationVal)
    {
        xAxisClamp += vertiRotationVal;
        if(vertiRotationVal<0 && xAxisClamp>-1.0f)
        {
            rotateDown(vertiRotationVal);
        }
        else if(vertiRotationVal > 0 && xAxisClamp<1.0f)
        {
            rotateUp(vertiRotationVal);
        }

        if(xAxisClamp<-1.0f)
        {
            xAxisClamp = -1.0f;
        }
        else if(xAxisClamp > 1.0f)
        {
            xAxisClamp = 1.0f;
        }

        if (horizonRotationVal < 0)
        {
            rotateLeft(horizonRotationVal);
        }
        else if (horizonRotationVal > 0)
        {
            rotateRight(horizonRotationVal);
        }
    }

    private void rotateRight(float horizonRotationVal)
    {
        quaternionToRotate = Quaternion.FromToRotation(playerFullTransform.transform.forward, playerFullTransform.right) * playerFullTransform.rotation;
        playerFullTransform.rotation = Quaternion.Slerp(playerFullTransform.rotation, quaternionToRotate, horizonRotationVal);
    }
    private void rotateLeft(float horizonRotationVal)
    {
        quaternionToRotate = Quaternion.FromToRotation(playerFullTransform.transform.forward, -playerFullTransform.right) * playerFullTransform.rotation;
        playerFullTransform.rotation = Quaternion.Slerp(playerFullTransform.rotation, quaternionToRotate, horizonRotationVal * (-1));
    }
    private void rotateUp(float vertiRotationVal)
    {
        quaternionToRotate = Quaternion.FromToRotation(playerHeadTransform.transform.forward, playerHeadTransform.up) * playerHeadTransform.rotation;
        playerHeadTransform.rotation = Quaternion.Slerp(playerHeadTransform.rotation, quaternionToRotate, vertiRotationVal);
    }
    private void rotateDown(float vertiRotationVal)
    {
        quaternionToRotate = Quaternion.FromToRotation(playerHeadTransform.transform.forward, -playerHeadTransform.up) * playerHeadTransform.rotation;
        playerHeadTransform.rotation = Quaternion.Slerp(playerHeadTransform.rotation, quaternionToRotate, vertiRotationVal*(-1));
    }
}

