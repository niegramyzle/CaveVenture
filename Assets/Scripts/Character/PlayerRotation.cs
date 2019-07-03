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

    private float resetDownDownLimiter;
    private float resetDownUpLimiter;
    private float resetUpDownLimiter;
    private float resetUpUpLimiter;
    private float clampDownDownLimiter;
    private float clampDownUpLimiter;
    private float clampUpDownLimiter;
    private float clampUpUpLimiter;

    private void Awake()
    {
        clampUpDownLimiter = 270.0f;
        clampUpUpLimiter = 355.0f;
        resetUpDownLimiter = 270.0f;
        resetUpUpLimiter = 280.0f;
        clampDownDownLimiter = 5.0f;
        clampDownUpLimiter = 90.0f;
        resetDownDownLimiter = 80.0f;
        resetDownUpLimiter = 90.0f;
    }

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
        quaternionToRotate.eulerAngles = new Vector3(Mathf.Clamp(quaternionToRotate.eulerAngles.x, clampUpDownLimiter, clampUpUpLimiter), quaternionToRotate.eulerAngles.y, quaternionToRotate.eulerAngles.z);
        if (quaternionToRotate.eulerAngles.x < clampUpUpLimiter - 5 && quaternionToRotate.eulerAngles.x >= clampUpDownLimiter)
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
        if (quaternionToRotate.eulerAngles.x < resetUpUpLimiter && quaternionToRotate.eulerAngles.x > resetUpDownLimiter)// taki reset na środku aby się zakres nie przesuwał
            directionRotationVal = 0;
    }

    private void rotateDown(float vertiRotationVal)
    {
        quaternionToRotate = Quaternion.FromToRotation(playerHeadTransform.transform.forward, -playerHeadTransform.up) * playerHeadTransform.rotation;
        quaternionToRotate.eulerAngles = new Vector3(Mathf.Clamp(quaternionToRotate.eulerAngles.x, clampDownDownLimiter, clampDownUpLimiter), quaternionToRotate.eulerAngles.y, quaternionToRotate.eulerAngles.z);
        if (quaternionToRotate.eulerAngles.x > clampDownDownLimiter + 5 && quaternionToRotate.eulerAngles.x < clampDownUpLimiter)
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
        if (quaternionToRotate.eulerAngles.x > resetDownDownLimiter && quaternionToRotate.eulerAngles.x < resetDownUpLimiter)// taki reset na środku aby się zakres nie przesuwał
            directionRotationVal = 0;
    }
}

//[SerializeField]
//private float rotateSpeed;
//float rotatVertical = 0.0f;
//// Update is called once per frame
//void Update()
//{
//    //float rotatVer = Input.GetAxis("Mouse Y") * rotateSpeed;
//    //if (rotatVer + rotatVertical < 60 && rotatVer + rotatVertical > -30)
//    //{
//    //    rotatVertical += rotatVer;
//    //    transform.eulerAngles = new Vector3(rotatVertical, 0.0f, 0.0f);
//    //}
//}
//}
////float rotatHor = Input.GetAxis("Mouse X") * rotateSpeed;
////float rotatVer = Input.GetAxis("Mouse Y") * rotateSpeed;
////if (rotatVer+rotatVertical < 60 && rotatVer+rotatVertical > -30)
////{
////    rotatVertical += rotatVer;
////    rotatHorizontal -= rotatHor;
////    transform.eulerAngles = new Vector3(rotatVertical, rotatHorizontal, 0.0f);
////}
//////rotatHorizontal *= Time.deltaTime;
//////rotatVertical *= Time.deltaTime;
////Debug.Log(rotatVertical + ", " + rotatHorizontal);

