using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementManager : MonoBehaviour
{
    public Rigidbody rb;
    public Transform pivot;
    public Transform body;

    public IMovement movement;

    private void Start()
    {
        movement = new GoundMovementTest();
        movement.InitMovement(rb,body,pivot);
    }

    private void Update()
    {
        movement.Move(PlayerInput.current.direction);
        movement.Rotate();
    }

}
