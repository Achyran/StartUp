using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IMovement
{
    float weight {get; set;}
    float jumpStrenght { get; set; }
    float speed { get; set; }

    void Jump();
    void Crouch();
    void Move();
}
