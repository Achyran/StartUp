﻿using System.Collections;
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

    

    private Vector2 FindRelativeToLook()
    {
        float lookAngel = _body.transform.eulerAngles.y;
        float moveAngel = Mathf.Atan2(_rb.velocity.x, _rb.velocity.z) * Mathf.Rad2Deg;

        float u = Mathf.DeltaAngle(lookAngel, moveAngel);
        float v = 90 - u;

        float yMag = _rb.velocity.magnitude * Mathf.Cos(u*Mathf.Deg2Rad);
        float xMag = _rb.velocity.magnitude * Mathf.Cos(v*Mathf.Deg2Rad);

        return new Vector2(yMag,xMag);
    }

    private void Countermovement(float x, float y, Vector2 mag)
    {
        if (!isGrounded()) return;

     
        if(Mathf.Abs(mag.x)> _threshold && Mathf.Abs(x) < 0.5f || (mag.x < -_threshold && x >0) ||(mag.x > _threshold && x<0))
        {
            _rb.AddForce(relativspeed() * _body.transform.right * -mag.x * _counter);
        }
        if (Mathf.Abs(mag.y) > _threshold && Mathf.Abs(y) < 0.5f || (mag.y < -_threshold && y > 0) || (mag.y > _threshold && x < 0)){
            _rb.AddForce(relativspeed() * _body.transform.right * -mag.y * _counter);
        }
        

    }
    
    
}
