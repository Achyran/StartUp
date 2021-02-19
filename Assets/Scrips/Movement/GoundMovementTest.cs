using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoundMovementTest : IMovement 
{
    public Rigidbody rb { get; set; }
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
    public bool isGrounded { get; set; }
    //Calculation
    private Vector3 projectedforce;
    private  float _canReset;
    public void InitMovement(Rigidbody pRb,Transform pBody, Transform pPivot,LayerMask pGround)
    {
        rb = pRb;
        _body = pBody;
        _pivot = pPivot;
        whatIsGround = pGround;
        _RbInit(pRb);
    }
    
    public void Move(Vector2 pDir)
    {
        isGrounded = _isGrounded();

        //Limits Directional Movement
        Vector3 direction = new Vector3(pDir.x, 0,pDir.y);
        direction = direction.normalized;


        projectedforce = rb.transform.forward * direction.z + rb.transform.right * direction.x + rb.velocity;
        //Prevent Multible jumps
        ControlleCanJump();

        DebugRays();
        
        // Adds the moving force
        if (pDir.magnitude > _threshold &&  rb.velocity.magnitude <= _maxSpeed && _isGrounded())
        {
            direction *= relativspeed();
            rb.AddForce(rb.transform.forward * direction.z);
            rb.AddForce(rb.transform.right * direction.x);

            
        }

        //Stops Player if no input is given
        
        if (pDir.magnitude <= _threshold && _isGrounded())
        {
            rb.angularVelocity = Vector3.zero;
            rb.velocity = rb.velocity * _forwardStop;
        } 
        
    }

    //Rotates the pysics body when moving (when not the cam can spin indvidualy form the player)
    public void Rotate()
    {
        if (rb.velocity.magnitude >= 0.5f)
        {
            rb.transform.localRotation = Quaternion.Euler(0, _pivot.rotation.eulerAngles.y, 0);
        }
    }

    //Applies jumpforce
    public bool Jump() 
    {
        if (_isGrounded() && _canJump)
        { 
            rb.AddForce(0, _jumpStrenght, 0);
            _canJump = false;
            _canReset = 0;
            return true;
        }
        return false;
    }
    //Returns relativspeed
    private float relativspeed()
    {
        return _speed * Time.deltaTime;
    }

    //Adds a jump cd to pervent multible jumps
    void ControlleCanJump()
    {
        if(_canReset >= _jumpCd && !_canJump && _isGrounded())
            {
                _canJump = true;
            }
        else if(_canReset < _jumpCd)
        {
            _canReset += Time.deltaTime;
        }
        
    }
    
    //Checks if the player is grounded
    private bool _isGrounded()
    {

        Debug.DrawRay(_body.transform.position + new Vector3(-0.3f,0,-1.3f), _body.transform.up * -1.1f, Color.white);
        Debug.DrawRay(_body.transform.position + new Vector3(-0.3f,0,1.3f), _body.transform.up * -1.1f, Color.white);
        Debug.DrawRay(_body.transform.position + new Vector3(0.3f, 0, 1.3f), _body.transform.up * -1.1f, Color.white);
        Debug.DrawRay(_body.transform.position + new Vector3(0.3f, 0, -1.3f), _body.transform.up * -1.1f, Color.white);

        if (Physics.Raycast(_body.transform.position + new Vector3(0.3f, 0, -1.3f), -_body.transform.up, 1.2f, whatIsGround))
        {
            rb.drag = _drag;
            return true;
        }
        if (Physics.Raycast(_body.transform.position + new Vector3(0.3f, 0, 1.3f), -_body.transform.up, 1.2f, whatIsGround))
        {
            rb.drag = _drag;
            return true;
        }
        if (Physics.Raycast(_body.transform.position + new Vector3(-0.3f, 0, -1.3f), -_body.transform.up, 1.2f, whatIsGround))
        {
            rb.drag = _drag;
            return true;
        }
        if (Physics.Raycast(_body.transform.position + new Vector3(-0.3f, 0, 1.3f), -_body.transform.up, 1.2f, whatIsGround))
        {
            rb.drag = _drag;
            return true;
        }
        if (Physics.Raycast(_body.transform.position, -_body.transform.up, 1.2f, whatIsGround))
        {
            rb.drag = _drag;
            return true;
        }
        rb.drag = 0;
        return false;
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
        Debug.DrawRay(_body.position, rb.velocity.normalized * 5, Color.green);
    }
}
