using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PivotController : MonoBehaviour
{
    public float sensitivity = 100f;
    public Vector2 camClamp = new Vector2(90,90);
    private float mouseX;
    private float mouseY;
    public Transform body;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        if (!PlayerInput.current.select)
        {
            Cursor.lockState = CursorLockMode.Locked;
            RotatePivot();
        }
        else
        {
            Cursor.lockState = CursorLockMode.Confined;
        }
        //_FixPostion();
    }
    private void FixedUpdate()
    {
        _FixPostion();
    }
    private void _FixPostion()
    {
        this.transform.position = body.position;
    }


    //Rotates The Pivot (The Parent of the Cam) depending on the mouse Position
    private void RotatePivot()
    {
         mouseX += Input.GetAxis("Mouse X") * sensitivity * Time.deltaTime;
         mouseY -= Input.GetAxis("Mouse Y") * sensitivity * Time.deltaTime;
        
        mouseY = Mathf.Clamp(mouseY,camClamp.x,camClamp.y);
        transform.rotation = Quaternion.Euler(mouseY, mouseX, 0);
    }
}
