using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpCube : MonoBehaviour
{
    protected Stack _stack;
    protected RaycastHit _hit;
    protected float _raycastDistance = 1;
    protected bool _isTake;

    private void Awake()
    {
        _stack = FindObjectOfType<Stack>();
    }

    private void FixedUpdate()
    {
        if (_isTake)
        {
            SetCubeRaycast();
        }
    }

    protected void SetCubeRaycast()
    {
        if (Physics.Raycast(transform.position, Vector3.forward, out _hit, _raycastDistance))
        {
            if (_hit.transform.GetComponent<StopCube>())
            {
                gameObject.transform.parent = _hit.transform;
                _stack.DecreaseCube(this);
                gameObject.SetActive(false);
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject == _stack.gameObject && _isTake == false)
        {
            collision.gameObject.GetComponent<Stack>().IncreaseCubeStack(this);
            _isTake = true;
        }
    }
}
