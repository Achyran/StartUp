using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomScale : MonoBehaviour
{
    public float maxScale = 3;
    public float offsetY = 3.15f;
    private float currentScale = 1;
    private void Start()
    {
        currentScale = Random.Range(1, maxScale);
        transform.localScale = new Vector3(currentScale, currentScale, currentScale);
        transform.position = new Vector3(transform.position.x, offsetY * currentScale / 100 + transform.position.y, transform.position.z);
    }
}
