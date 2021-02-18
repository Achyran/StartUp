using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoundMovementTest : IMovement 
{
    private Rigidbody _rb;
    private float _speed = 5000;
    private float _maxSpeed = 700;
    private Transform _body;
    private Transform _pivot;
    private float _threshold = 0.01f;
    private float _forwardStop = 0.7f;
    private float _jumpStrenght = 300;
    private float _jumpCd = 0.5f;
    private bool _canJump;
    private float _drag = 5;
    LayerMask whatIsGround;

    //Calculation
    private Vector3 projectedforce;
    private  float _canReset;
    public void InitMovement(Rigidbody pRb,Transform pBody, Transform pPivot,LayerMask pGround)
    {
        _rb = pRb;
        _body = pBody;
        _pivot = pPivot;
        whatIsGround = pGround;
        _RbInit(pRb);
    }
    
    public void Move(Vector2 pDir)
    {
        
        //Limits Directional Movement
        Vector3 direction = new Vector3(pDir.x, 0,pDir.y);
        direction = direction.normalized;


        projectedforce = _rb.transform.forward * direction.z + _rb.transform.right * direction.x + _rb.velocity;
        //Prevent Multible jumps
        ControlleCanJump();
        //Prevents sliding
        //CounterMovement();
        DebugRays();
        //Debug.DrawRay(_body.position, (Quaternion.Euler(0, -Vector3.SignedAngle(_body.forward, projectedforce, _body.up), 0) * _body.forward).normalized * 5, Color.blue);
        
        // Adds the moving force
        if (pDir.magnitude > _threshold &&  _rb.velocity.magnitude <= _maxSpeed && isGrounded())
        {
            direction *= relativspeed();
            _rb.AddForce(_rb.transform.forward * direction.z);
            _rb.AddForce(_rb.transform.right * direction.x);

            
        }
        //if(isGrounded())CounterMovement();
        //Stops Player if no input is given
        
        if (pDir.magnitude <= _threshold && isGrounded())
        {
            _rb.angularVelocity = Vector3.zero;
            _rb.velocity = _rb.velocity * _forwardStop;
        } 
        
    }

    //Rotates the pysics body when moving (when not the cam can spin indvidualy form the player)
    public void Rotate()
    {
        if (_rb.velocity.magnitude >= 0.5f)
        {
            _rb.transform.localRotation = Quaternion.Euler(0, _pivot.rotation.eulerAngles.y, 0);
        }
    }

    //Applies jumpforce
    public void Jump() 
    {
        if (isGrounded() && _canJump)
        {
            _rb.AddForce(0, _jumpStrenght, 0);
            _canJump = false;
            _canReset = 0;
        }
    }
    //Returns relativspeed
    private float relativspeed()
    {
        return _speed * Time.deltaTime;
    }

    //Adds a jump cd to pervent multible jumps
    void ControlleCanJump()
    {
        if(_canReset >= _jumpCd && !_canJump && isGrounded())
            {
                _canJump = true;
            }
        else if(_canReset < _jumpCd)
        {
            _canReset += Time.deltaTime;
        }
        //Debug.Log(_canReset);
    }
    
    //Checks if the player is grounded
    private bool isGrounded()
    {

        Debug.DrawRay(_body.transform.position + new Vector3(-0.3f,0,-1.3f), _body.transform.up * -1.1f, Color.white);
        Debug.DrawRay(_body.transform.position + new Vector3(-0.3f,0,1.3f), _body.transform.up * -1.1f, Color.white);
        Debug.DrawRay(_body.transform.position + new Vector3(0.3f, 0, 1.3f), _body.transform.up * -1.1f, Color.white);
        Debug.DrawRay(_body.transform.position + new Vector3(0.3f, 0, -1.3f), _body.transform.up * -1.1f, Color.white);

        if (Physics.Raycast(_body.transform.position + new Vector3(0.3f, 0, -1.3f), -_body.transform.up, 1.2f, whatIsGround))
        {
            _rb.drag = _drag;
            return true;
        }
        if (Physics.Raycast(_body.transform.position + new Vector3(0.3f, 0, 1.3f), -_body.transform.up, 1.2f, whatIsGround))
        {
            _rb.drag = _drag;
            return true;
        }
        if (Physics.Raycast(_body.transform.position + new Vector3(-0.3f, 0, -1.3f), -_body.transform.up, 1.2f, whatIsGround))
        {
            _rb.drag = _drag;
            return true;
        }
        if (Physics.Raycast(_body.transform.position + new Vector3(-0.3f, 0, 1.3f), -_body.transform.up, 1.2f, whatIsGround))
        {
            _rb.drag = _drag;
            return true;
        }
        if (Physics.Raycast(_body.transform.position, -_body.transform.up, 1.2f, whatIsGround))
        {
            _rb.drag = _drag;
            return true;
        }
        _rb.drag = 0;
        return false;
    }

   
    //Prevents Sliding
    private void CounterMovement()
    {
        
        //Angel between the projected force and the look direction
        float angle = -Vector3.SignedAngle(_body.forward, projectedforce, _body.up);
        //Creates the negativ angle
        Quaternion direction = Quaternion.Euler(0, -Vector3.SignedAngle(_body.forward, projectedforce, _body.up), 0);
        //adds a force to counterackt the sliding based on the current momentum
        Vector3 force = direction * _body.forward; 

        _rb.AddForce(force.normalized * _rb.velocity.magnitude * 1);
    }

    private void _RbInit(Rigidbody pRb)
    {
        pRb.mass = 1;
        pRb.drag = 10;
        pRb.angularDrag = 1;
        CapsuleCollider coll = pRb.GetComponent<CapsuleCollider>();
        coll.height = 3.17f;
        coll.radius = 0.8f;
        coll.direction = 2;
        pRb.useGravity = true;
    }

    //Shows the forces and helpfull info
    private void DebugRays()
    {
        //direction of the Player without Counterforce
        Debug.DrawRay(_body.position, projectedforce.normalized * 5, Color.black);
        //Counterforce that will be aplied
        Debug.DrawRay(_body.position, (Quaternion.Euler(0, -Vector3.SignedAngle(_body.forward, projectedforce, _body.up), 0) * _body.forward).normalized * 5, Color.blue);
        //Look direction
        Debug.DrawRay(_body.position, _body.forward * 5, Color.red);
        //Current Velosity
        Debug.DrawRay(_body.position, _rb.velocity.normalized * 5, Color.green);
    }
}
