using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRotation : MonoBehaviour
{
    [SerializeField]
    private Transform playerHeadTransform;
    [SerializeField]
    private Transform playerFullTransform;


    private Quaternion quaternionToRotate;
    private float directionRotationVal = 0;

    public void rotatePlayer(float horizonRotationVal, float vertiRotationVal)
    {
        if (vertiRotationVal < 0)
        {
            rotateDown(vertiRotationVal);
        }
        else if (vertiRotationVal > 0)
        {
            rotateUp(vertiRotationVal);
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
        Quaternion quater = Quaternion.Slerp(playerFullTransform.rotation, quaternionToRotate, horizonRotationVal);
        playerFullTransform.rotation = quater;
    }
    private void rotateLeft(float horizonRotationVal)
    {
        quaternionToRotate = Quaternion.FromToRotation(playerFullTransform.transform.forward, -playerFullTransform.right) * playerFullTransform.rotation;
        Quaternion quater = Quaternion.Slerp(playerFullTransform.rotation, quaternionToRotate, horizonRotationVal * (-1));
        playerFullTransform.rotation = quater;
    }
    private void rotateUp(float vertiRotationVal)
    {
        quaternionToRotate = Quaternion.FromToRotation(playerHeadTransform.transform.forward, playerHeadTransform.up) * playerHeadTransform.rotation;
        quaternionToRotate.eulerAngles = new Vector3(Mathf.Clamp(quaternionToRotate.eulerAngles.x, 270.0f, 355.0f), quaternionToRotate.eulerAngles.y, quaternionToRotate.eulerAngles.z);
        if (quaternionToRotate.eulerAngles.x < 350.0f && quaternionToRotate.eulerAngles.x >= 270.0f)
        {
            Quaternion quater = Quaternion.Slerp(playerHeadTransform.rotation, quaternionToRotate, vertiRotationVal);
            playerHeadTransform.rotation = quater;
            directionRotationVal += vertiRotationVal;
        }
        else if (directionRotationVal < 0)//jak się na górze zablokuje, to żeby w dół ruszyć
        {
            Quaternion quater = Quaternion.Slerp(playerHeadTransform.rotation, quaternionToRotate, vertiRotationVal);
            playerHeadTransform.rotation = quater;
        }
        if (quaternionToRotate.eulerAngles.x < 280.0f && quaternionToRotate.eulerAngles.x > 270.0f)// taki reset na środku aby się zakres nie przesuwał
            directionRotationVal = 0;
    }

    private void rotateDown(float vertiRotationVal)
    {
        quaternionToRotate = Quaternion.FromToRotation(playerHeadTransform.transform.forward, -playerHeadTransform.up) * playerHeadTransform.rotation;
        quaternionToRotate.eulerAngles = new Vector3(Mathf.Clamp(quaternionToRotate.eulerAngles.x, 5.0f, 90.0f), quaternionToRotate.eulerAngles.y, quaternionToRotate.eulerAngles.z);
        if (quaternionToRotate.eulerAngles.x > 10.0f && quaternionToRotate.eulerAngles.x < 270.0f)
        {
            Quaternion quater = Quaternion.Slerp(playerHeadTransform.rotation, quaternionToRotate, vertiRotationVal * (-1));
            playerHeadTransform.rotation = quater;
            directionRotationVal += vertiRotationVal;
        }
        else if (directionRotationVal > 0) //jak się na dole zablokuje, to żeby w górę ruszyć
        {
            Quaternion quater = Quaternion.Slerp(playerHeadTransform.rotation, quaternionToRotate, vertiRotationVal * (-1));
            playerHeadTransform.rotation = quater;
        }
        if (quaternionToRotate.eulerAngles.x > 80.0f && quaternionToRotate.eulerAngles.x < 90.0f)// taki reset na środku aby się zakres nie przesuwał
            directionRotationVal = 0;

    }
}


/*public class PlayerRotation : MonoBehaviour
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
}*/
