using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camcontroller : MonoBehaviour
{
    public Transform pivot;
    public int dist;

    private void Update()
    {
        SetThirdPersonPosition();
    }
    //Sets the Cam a dist away from the Char and its rotation relativ to the pivot
    private void SetThirdPersonPosition()
    {
        this.transform.position = pivot.transform.position + (pivot.forward * dist);
        this.transform.LookAt(pivot);
    }

    private void RotatePivot()
    {

    }
}
