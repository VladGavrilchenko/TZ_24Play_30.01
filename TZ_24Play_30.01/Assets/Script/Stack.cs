using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stack : MonoBehaviour
{
    [SerializeField] private float _cubeSize = 2;
    [SerializeField] private List<GameObject> _cubeList = new List<GameObject>();
    private Animator _animator;

    private void Start()
    {
        _animator = GetComponentInChildren<Animator>();
    }

    public void IncreaseCubeStack(PickUpCube cubePick)
    {
        _animator.SetTrigger("Jump");
        transform.position = new Vector3(transform.position.x, transform.position.y + _cubeSize, transform.position.z);
        cubePick.gameObject.transform.position = new Vector3(transform.position.x, GetLastBlock().transform.position.y - _cubeSize, transform.position.z);
        cubePick.gameObject.transform.SetParent(transform);
        _cubeList.Add(cubePick.gameObject);
    }

    public void DecreaseCube(PickUpCube decreaseCube)
    {
        decreaseCube.gameObject.transform.parent = null;
        _cubeList.Remove(decreaseCube.gameObject);
    }

    public int GetBlockCount()
    {
        return _cubeList.Count;
    }


    private GameObject GetLastBlock()
    {
        return _cubeList[_cubeList.Count - 1];
    }

}
