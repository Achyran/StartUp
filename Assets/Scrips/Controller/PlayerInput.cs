using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    public static PlayerInput current;
    public Vector2 direction { get; private set; }
    public bool jump { get; private set; }
    public bool crouch { get; private set; }

    void Start()
    {
       if(current == null) current = this;
        else
        {
            Debug.LogError("Player Input allready exist, Destroying This!");
            Destroy(this);
        }
    }

    // Update is called once per frame
    void Update()
    {
        direction = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        jump = Input.GetKey(KeyCode.Space);
        crouch = Input.GetKey(KeyCode.LeftShift);
    }
}
