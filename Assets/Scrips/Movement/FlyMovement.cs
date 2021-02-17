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
    private float _jumpCd = 0.5f;
    private float _canjump;
    private float _jumpStrength = 500;
    private float _rotationSpeed = 100;
    private float _speed = 500;
    private float _maxTilt = 50;

    //MathShit
    private float _currentRoll;

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
        float aimAngle = _pivot.rotation.eulerAngles.x;

        //_body.transform.Rotate(0, 0, 1);
        
    }
    public void Move(Vector2 pdir) 
    {
        if(_currentRoll > 0)
        {
            _currentRoll--;
        }
        if(_currentRoll < 0)
        {
            _currentRoll++;
        }
        //Roatat the player around the forward axis
        if (Mathf.Abs( pdir.x) >= 0.1f &&  Mathf.Abs(_currentRoll) <= _maxTilt)
        {
            _currentRoll += Time.deltaTime * _rotationSpeed * pdir.x;
        }
       if(Mathf.Abs(pdir.y)>= 0.1f)
        {
            _rb.AddForce(_rb.transform.forward * pdir.y * Time.deltaTime * _speed);

        }

        _UpdateJumpCD();
        _rb.transform.rotation = Quaternion.LookRotation(_pivot.forward);
        _rb.transform.Rotate(0,0,_currentRoll);

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
        pRb.angularDrag = 1;
    }
    public void Jump() 
    {
        if( _jumpCd <= _canjump) 
        {
            _rb.AddForce(_rb.transform.up * _jumpStrength);
            _canjump = 0;
        } 
    }
}
