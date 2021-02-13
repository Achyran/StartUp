using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementManager : MonoBehaviour
{
    public Rigidbody rb;
    public Transform pivot;
    public Transform body;
    public LayerMask isGround;

    public IMovement movement;

    private void Start()
    {
        movement = new GoundMovementTest();
        movement.InitMovement(rb,body,pivot,isGround);
    }

    private void Update()
    {
        movement.Move(PlayerInput.current.direction);
        movement.Rotate();
        if (PlayerInput.current.jump) movement.Jump();
        
    }

}
