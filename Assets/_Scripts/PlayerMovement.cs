using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    Rigidbody rbToMove;
   [SerializeField] float moveSpeed;
    const float diagonalNerf = 0.7f;
    public void move(float xFactor, float zFactor) 
    {
        if (rbToMove != null)
        {
            rbToMove.velocity = new Vector3(xFactor * moveSpeed, 0f, zFactor * moveSpeed);
            rbToMove.velocity = rbToMove.velocity * diagonalNerf;
        }
    }
    public void setRigidBody(Rigidbody newRB)
    {
        rbToMove = newRB;
        moveSpeed = newRB.GetComponent<Body>().getMoveSpeed();
    }
}
