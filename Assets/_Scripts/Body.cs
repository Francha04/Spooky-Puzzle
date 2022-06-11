using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Body : MonoBehaviour
{
    [SerializeField] private float movementSpeed;
    public float getMoveSpeed()
    {
        return movementSpeed;
    }
}
