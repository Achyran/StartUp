using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomRotation : MonoBehaviour
{
    private void Start()
    {
        Vector3 euler = transform.eulerAngles;
         euler.y = Random.Range(0.0f,360.0f);

        transform.eulerAngles = euler;
    }
}
