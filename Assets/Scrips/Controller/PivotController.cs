using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PivotController : MonoBehaviour
{
    public float sensitivity = 100f;
    private float xRotation = 0f;
    public Vector2 camClamp = new Vector2(90,90);
    private float mouseX;
    private float mouseY;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        RotatePivot();
    }

    //Rotates The Pivot (The Parent of the Cam) depending on the mouse Position
    private void RotatePivot()
    {
         mouseX += Input.GetAxis("Mouse X") * sensitivity * Time.deltaTime;
         mouseY -= Input.GetAxis("Mouse Y") * sensitivity * Time.deltaTime;
        
        xRotation = Mathf.Clamp(mouseY,camClamp.x,camClamp.y);
        transform.rotation = Quaternion.Euler(xRotation, mouseX, 0);

    }
}
