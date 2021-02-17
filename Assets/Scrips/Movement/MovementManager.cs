using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementManager : MonoBehaviour
{
    public Rigidbody rb;
    public Transform pivot;
    public Transform body;
    public LayerMask isGround;
    private bool CanChange = true;

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
        
        if(CanChange && Input.GetKeyDown(KeyCode.H))
        {
            movement = new FlyMovement();
            movement.InitMovement(rb, body, pivot, isGround);
        }
        
    }
    private void FixedUpdate()
    {
        if (PlayerInput.current.jump) movement.Jump();
    }

}
