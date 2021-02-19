using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyMovement : IMovement
{
    //Outside References
    public Rigidbody rb { get; set; }
    private Transform _body;
    private Transform _pivot;
    private LayerMask _whatisGround;

    //Neede variables
    public bool isGrounded { get; set; }
    private float _jumpCd = 1f;
    private float _canjump;
    private float _jumpStrength = 500;
    private float _rotationSpeed = 100;
    private float _speed = 1000;
    private float _maxTilt = 50;
    private float _groundDist = 0.8f;
    private float _artificalGravity = 30;

    //MathShit
    private float _currentTilt;
    private CapsuleCollider _coll;

    public void InitMovement(Rigidbody prb, Transform pBody, Transform pPivot, LayerMask pIsGorund) 
    {
        rb = prb;
        _body = pBody;
        _pivot = pPivot;
        _whatisGround = pIsGorund;
        _RbInit(prb);
        
    }
    public void Rotate() 
    {
        isGrounded =_Grounded();
    }
    public void Move(Vector2 pdir)
    {
        if (_currentTilt > 0)
        {
            _currentTilt--;
        }
        if (_currentTilt < 0)
        {
            _currentTilt++;
        }
        //Roatat the player around the forward axis

        if (!_Grounded())
        {
            Tilt(pdir);
            _coll.height = 2.36f;
        }
        else _coll.height = 0.8f;
        if (Mathf.Abs(pdir.y) >= 0.1f)
        {
            rb.AddForce(_pivot.forward * pdir.y * Time.deltaTime * _speed);
        }


        _UpdateJumpCD();
        if (!_Grounded())
        {

            rb.transform.rotation = Quaternion.LookRotation(new Vector3(rb.velocity.x, 0, rb.velocity.z));
        }
        else {
            rb.transform.rotation = Quaternion.LookRotation(new Vector3(_pivot.forward.x, 0, _pivot.forward.z));
            rb.drag = 10;
                
             }
        rb.transform.Rotate(0,0,_currentTilt);
        rb.AddForce(0, -_artificalGravity * Time.deltaTime, 0);

    }
    private void Tilt(Vector2 pdir)
    {
        if (Mathf.Abs(pdir.x) >= 0.1f && Mathf.Abs(_currentTilt) <= _maxTilt)
        {
            _currentTilt += Time.deltaTime * _rotationSpeed * -pdir.x;
        }
    }
    private void _UpdateJumpCD()
    {
        if(_jumpCd <= _canjump) return;
        _canjump += Time.deltaTime;
    
        
    }
    private void _RbInit(Rigidbody pRb)
    {
        pRb.mass = 1;
        pRb.drag = 0.5f;
        pRb.angularDrag = 50;
        _coll =  pRb.GetComponent<CapsuleCollider>();
        _coll.height = 2.36f;
        _coll.radius = 0.43f;
        _coll.direction = 0;
        pRb.useGravity = false;
    }
    public bool Jump() 
    {
        if (_jumpCd <= _canjump)
        {
            rb.AddForce(rb.transform.up * _jumpStrength);
            _canjump = 0;
            rb.drag = 0.5f;
            return true;
        }
        return false;
    }

    private bool _Grounded()
    {
        Debug.DrawRay(rb.position, new Vector3(0, -1, 0) * _groundDist, Color.white);
        if(Physics.Raycast(rb.transform.position,new Vector3(0, -1, 0), _groundDist, _whatisGround))
        {
            return true;
        }
        return false;
    }
}
