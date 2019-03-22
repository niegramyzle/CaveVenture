using UnityEngine;
using System.Collections;

public class RotationInputController : MonoBehaviour
{
    [SerializeField]
    private PlayerRotation playerRotation;

    [SerializeField]
    private string horizonInputName;
    [SerializeField]
    private string vertiInputName;
    [SerializeField]
    private float rotationSpeed;

    private float horizonRotationVal;
    private float vertiRotationVal;
    // Update is called once per frame
    void Update()
    {
        horizonRotationVal = rotationSpeed * Input.GetAxis(horizonInputName) * Time.deltaTime;
        vertiRotationVal = rotationSpeed * Input.GetAxis(vertiInputName) * Time.deltaTime;
        playerRotation.rotatePlayer(horizonRotationVal, vertiRotationVal);
    }
}
