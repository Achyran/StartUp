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
        GameMaster.current.event_PlayerChange += ChangeMovement;
    }

    private void Update()
    {
        movement.Move(PlayerInput.current.direction);
        movement.Rotate();
        
    }
    private void FixedUpdate()
    {
        if (PlayerInput.current.jump) movement.Jump();
    }

    private void ChangeMovement(GameMaster.Animal pAnimal)
    {
        switch (pAnimal)
        {
            case GameMaster.Animal.eagle:
                movement = new FlyMovement();
                break;
            case GameMaster.Animal.wolf:
                movement = new GoundMovementTest();
                break;
        }
        //Debug.Log("Chosen animal is " + pAnimal);
        movement.InitMovement(rb, body, pivot, isGround);

    }
    private void OnDestroy()
    {
        GameMaster.current.event_PlayerChange -= ChangeMovement;
    }

}
