using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCubePick : PickUpCube
{
    private void Awake()
    {
        _isTake = true;
        _stack = FindObjectOfType<Stack>();
    }

    private void FixedUpdate()
    {
        if (_isTake)
        {
            SetCubeRaycast();
        }
    }

}
