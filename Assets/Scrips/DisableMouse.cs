using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisableMouse : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Cursor.visible = false;
        Cursor.lockState =  CursorLockMode.Confined;
    }

    // Update is called once per frame
    void Update()
    {
        MakeVisible();
    }

    private void MakeVisible() 
    {
        if (Input.GetKey(KeyCode.Tab) || Time.timeScale <= 0) 
        {
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
        }
        else 
        {
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Confined;
        }
    }
}
