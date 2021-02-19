using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IMovement
{
    bool isGrounded { get; set; }
    Rigidbody rb { get; set; }
    void InitMovement(Rigidbody prb, Transform pBody, Transform pPivot,LayerMask isGorund);
    void Rotate();
    void Move(Vector2 pdir);
    //Returns true if the jump went trough
    bool Jump();
}
