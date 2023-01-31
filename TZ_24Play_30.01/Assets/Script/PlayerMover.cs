using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMover : MonoBehaviour
{
    [SerializeField] private float _speed = 10f;
    [SerializeField] private float _speedToSide = 0.1f;
    private int _sideValue;

    private void FixedUpdate()
    {
        Movement();
    }

    private void Movement()
    {
        transform.Translate(Vector3.forward * _speed * Time.fixedDeltaTime);
        transform.position += new Vector3(_sideValue * _speedToSide * Time.fixedDeltaTime, 0,0);
    }

    public void MovementSide(int newSideValue)
    {
        _sideValue = newSideValue;
    }
}
