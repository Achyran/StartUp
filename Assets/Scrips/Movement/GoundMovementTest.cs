using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoundMovementTest : IMovement 
{
    private Rigidbody _rb;
    private float _speed = 1000;
    private float _maxSpeed = 10;
    private Transform _body;
    private Transform _pivot;
    private float _counter = 0.175f;
    private float _threshold = 0.01f;
    private float _forwardStop = 0.7f;
    private float _jumpStrenght = 200;
    private bool _canJump;
    LayerMask whatIsGround;

    public void InitMovement(Rigidbody pRb,Transform pBody, Transform pPivot,LayerMask pGround)
    {
        _rb = pRb;
        _body = pBody;
        _pivot = pPivot;
        whatIsGround = pGround;
    }
    Vector3 projectedforce;
    public void Move(Vector2 pDir)
    {
        
        //Limits Directional Movement
        Vector3 direction = new Vector3(pDir.x, 0,pDir.y);
        direction = direction.normalized;

        ControlleCanJump();
        projectedforce = _rb.transform.forward * direction.z + _rb.transform.right * direction.x + _rb.velocity;
        Debug.DrawRay(_body.position, projectedforce.normalized * 5, Color.black);
        Debug.DrawRay(_body.position, (Quaternion.Euler(0,-Vector3.SignedAngle(_body.forward,projectedforce,_body.up),0) * _body.forward).normalized * 5, Color.blue);
        Debug.DrawRay(_body.position, _body.forward * 5, Color.red);
        Debug.DrawRay(_body.position, _rb.velocity.normalized * 5, Color.green);
        Debug.DrawRay(_body.position, _rb.velocity.normalized + new Vector3());
        direction *= relativspeed();
        // Adds the moving force
       
        
        if (pDir.magnitude > _threshold &&  _rb.velocity.magnitude <= _maxSpeed && isGrounded())
        {
            _rb.AddForce(_rb.transform.forward * direction.z);
            _rb.AddForce(_rb.transform.right * direction.x);
            
            _rb.AddForce((Quaternion.Euler(0, -Vector3.SignedAngle(_body.forward, projectedforce, _body.up), 0) * _body.forward).normalized *_rb.velocity.magnitude );
        }

        //Stops Player if no input is given
        
        if (pDir.magnitude <= _threshold && isGrounded())
        {
            _rb.angularVelocity = Vector3.zero;
            _rb.velocity = _rb.velocity * _forwardStop;
        }
        
        
    }
    public void Rotate()
    {
        if (_rb.velocity.magnitude >= 0.5f)
        {
            _rb.transform.localRotation = Quaternion.Euler(0, _pivot.rotation.eulerAngles.y, 0);
        }
    }

    public void Jump() 
    {
        if (isGrounded() && _canJump)
        {
            _rb.AddForce(0, _jumpStrenght, 0);
            _canJump = false;
            _canReset = 0;
        }
    }

    private float relativspeed()
    {
        return _speed * Time.deltaTime;
    }

    int _canReset;
    void ControlleCanJump()
    {
        if(_canReset >= 10 && !_canJump && isGrounded())
            {
                _canJump = true;
            }
        else if(_canReset < 10)
        {
            _canReset++;
        }
    }
    //--------------------------Gorund Check-----------------------//
    private bool isGrounded()
    {
        Debug.DrawRay(_body.transform.position, _body.transform.up * -0.6f, Color.white);
        if(Physics.Raycast(_body.transform.position, -_body.transform.up, 0.6f,whatIsGround))
        {

            return true;
        }
        
        return false;
    }

    //----------------------Needed for Counter movenemt---------------//
    
    private void CounterMovement()
    {
        
    }
}
