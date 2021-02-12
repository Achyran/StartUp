using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IMovement
{

    void InitMovement(Rigidbody prb, Transform pBody, Transform pPivot,LayerMask isGorund);
    void Rotate();
    void Move(Vector2 pdir);
    void Jump();
}
