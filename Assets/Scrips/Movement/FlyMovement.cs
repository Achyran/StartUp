using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyMovement : IMovement
{
    //Outside References
    private Rigidbody _rb;
    private Transform _body;
    private Transform _pivot;
    private LayerMask _whatisGround;

    //Neede variables
    private bool _isAirborne;
    private float _jumpCd = 1f;
    private float _canjump;
    private float _jumpStrength = 500;
    private float _rotationSpeed = 100;
    private float _speed = 1000;
    private float _maxTilt = 50;
    private float _groundDist;
    private float _artificalGravity = 30;

    //MathShit
    private float _currentTilt;

    public void InitMovement(Rigidbody prb, Transform pBody, Transform pPivot, LayerMask pIsGorund) 
    {
        _rb = prb;
        _body = pBody;
        _pivot = pPivot;
        _whatisGround = pIsGorund;
        _RbInit(prb);
        
    }
    public void Rotate() 
    {
        _Grounded();
    }
    public void Move(Vector2 pdir) 
    {
        if(_currentTilt > 0)
        {
            _currentTilt --;
        }
        if(_currentTilt < 0)
        {
            _currentTilt ++;
        }
        //Roatat the player around the forward axis
        if (Mathf.Abs( pdir.x) >= 0.1f &&  Mathf.Abs(_currentTilt) <= _maxTilt)
        {
            _currentTilt += Time.deltaTime * _rotationSpeed * -pdir.x;
        }
       if(Mathf.Abs(pdir.y)>= 0.1f)
        {
            _rb.AddForce(_pivot.forward * pdir.y * Time.deltaTime * _speed);

        }

        _UpdateJumpCD();
        if (_rb.velocity.magnitude > 0.1f)
        {
            
            _rb.transform.rotation = Quaternion.LookRotation(new Vector3(_rb.velocity.x, 0, _rb.velocity.z));
        }else
            _rb.transform.rotation = Quaternion.LookRotation(new Vector3(_pivot.forward.x, 0, _pivot.forward.z));
        _rb.transform.Rotate(0,0,_currentTilt);
        _rb.AddForce(0, -_artificalGravity * Time.deltaTime, 0);

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
        CapsuleCollider coll =  pRb.GetComponent<CapsuleCollider>();
        coll.height = 2.36f;
        coll.radius = 0.43f;
        coll.direction = 0;
        pRb.useGravity = false;
    }
    public void Jump() 
    {
        if( _jumpCd <= _canjump) 
        {
            _rb.AddForce(_rb.transform.up * _jumpStrength);
            _canjump = 0;
        } 
    }

    private bool _Grounded()
    {
        Debug.DrawRay(_rb.position, new Vector3(0, -1, 0), Color.white, _groundDist);
        if(Physics.Raycast(_rb.transform.position,new Vector3(0, -1, 0), _groundDist, _whatisGround))
        {
            return true;
        }
        return false;
    }
}
