using UnityEngine;
using System.Collections;

public class RotationInputController : MonoBehaviour
{
    
    [SerializeField] private string horizonInputName;
    [SerializeField] private string vertiInputName;
    private CharacterStats stats;
    private PlayerRotation playerRotation;

    private float horizonRotationVal;
    private float vertiRotationVal;

    private void Awake()
    {
        stats=GetComponent<CharacterStats>();
        playerRotation = GetComponent<PlayerRotation>();
    }

    // Update is called once per frame
    void Update()
    {
        //horizonRotationVal = stats.RotationSpeed * Input.GetAxis(horizonInputName) * Time.deltaTime;
        //vertiRotationVal = stats.RotationSpeed * Input.GetAxis(vertiInputName) * Time.deltaTime;
        //playerRotation.rotatePlayer(horizonRotationVal, vertiRotationVal);
    }
}
