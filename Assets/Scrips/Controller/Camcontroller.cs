using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camcontroller : MonoBehaviour
{
    public Transform pivot;
    public float dist;
    private float _dist;
    public float minDist;
    public float camSpeed;

    private void FixedUpdate()
    {
        SetThirdPersonPosition();
        DistCheck();
    }
        private void SetThirdPersonPosition()
    {
        this.transform.position = pivot.position + (pivot.forward * -_dist);
        this.transform.LookAt(pivot);
    }
    //Checks for objects beween char and cam and adusts local dist relativly
    private void DistCheck()
    {
        _dist = dist;
        RaycastHit hit;
        if(Physics.Raycast(pivot.position, -pivot.forward, out hit, dist))
        {
            if(hit.distance < dist && _dist > minDist)
            {
                _dist = hit.distance -0.1f;
            }
        }
    }


    
}
