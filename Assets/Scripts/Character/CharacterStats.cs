using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterStats : MonoBehaviour
{
    [SerializeField] private float rotationSpeed;
    public float RotationSpeed
    {
        get { return rotationSpeed; }
    }
    [SerializeField] private int health;
    public int Health
    {
        get { return health; }
        set { health = value; }
    }
    [SerializeField] private float jumpSpeed;
    public float JumpSpeed
    {
        get { return jumpSpeed; }
    }
    [SerializeField] private float movementSpeed;
    public float MovementSpeed
    {
        get { return movementSpeed; }
    }
    [SerializeField] private float acceleration;
    public float Acceleration
    {
        get { return acceleration; }
    }
    [SerializeField] private float gravityMultiplier;
    public float GravityMultiplier
    {
        get { return gravityMultiplier; }
    }
    [SerializeField] private float airMoveMultiplier;
    public float AirMoveMultiplier
    {
        get { return airMoveMultiplier; }
    }



    public bool IsDied { get; set; }

}
