using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SelecTrigger : MonoBehaviour
{
    private bool isSelecting;
    private Vector2 middel2Mouse;
    private Image _image;
         
    private void Start()
    {
        _image = GetComponent<Image>();
        _image.color = new Vector4(0, 0, 0, 0);
        Cursor.lockState = CursorLockMode.Locked;

    }
    void Update()
    {
        
        if (PlayerInput.current.select && GameMaster.current.runeScore >= 3)
        {

            Cursor.lockState = CursorLockMode.Confined;
            _image.color = new Vector4(255, 255, 255, 255);
            middel2Mouse = new Vector2(transform.position.x,transform.position.y) - PlayerInput.current.mousePoss;
            isSelecting = true;
            

        }
        else if (!PlayerInput.current.select && isSelecting)
        {
            Cursor.lockState = CursorLockMode.Locked;
            _image.color = new Vector4(0, 0, 0, 0);
            isSelecting = false;
            float angel = Vector2.SignedAngle(new Vector2(0, -1), middel2Mouse);
            //Debug.Log(angel);
            if (angel < 0) GameMaster.current.PlayerChange(GameMaster.Animal.wolf);
            else GameMaster.current.PlayerChange(GameMaster.Animal.eagle);
        }
        


    }
}
