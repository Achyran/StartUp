using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoundMovementTest : IMovement 
{
    private Rigidbody _rb;
    private float _speed = 500;
    private Transform _body;
    private Transform _pivot;

    public void InitMovement(Rigidbody prb,Transform pbody, Transform pPivot)
    {
        _rb = prb;
        _body = pbody;
        _pivot = pPivot;
    }
    public void Move(Vector2 pDir)
    {
        Vector3 direction = new Vector3(pDir.x, 0,pDir.y);
        direction = direction.normalized;
        direction *= relativspeed();
        _rb.AddForce(_rb.transform.forward * direction.z);
        _rb.AddForce(_rb.transform.right * direction.x);

    }
    public void Rotate()
    {
        if (_rb.velocity.magnitude >= 0.5f)
        {
            _rb.transform.localRotation = Quaternion.Euler(0, _pivot.rotation.eulerAngles.y, 0);
        }
    }

    public void Jump() { }

    private float relativspeed()
    {
        return _speed * Time.deltaTime;
    }
}
