using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InfinitePlatformsSpawner : MonoBehaviour
{
    [SerializeField] protected Platform[] _platforms;
    [SerializeField] protected Platform _startPlatform;
    [SerializeField] protected int _maxPlatformCount;
    [SerializeField] protected float _platformLenght;
    private Transform _playerTransform;
    private List<GameObject> _activePlatforms = new List<GameObject>();
    protected float _spawnDirection;

    private void Start()
    {
        _playerTransform = FindObjectOfType<PlayerMover>().transform;
        GenerateStart();
    }

    private void Update()
    {
        if (_playerTransform.position.z > _spawnDirection - (_maxPlatformCount * _platformLenght))
        {
            SpawnPlatform(GetRandomPlatform());
            RemoveActivePlatforms();
        }
    }

    private void SpawnPlatform(Platform spawnPlatform)
    {
        GameObject newPlatform = Instantiate(spawnPlatform, transform.forward * _spawnDirection, transform.rotation).gameObject;
        _spawnDirection += _platformLenght;
        newPlatform.transform.parent = transform;
        _activePlatforms.Add(newPlatform);
    }

    private Platform GetRandomPlatform()
    {
        int randomIndex = Random.Range(0, _platforms.Length);
        return _platforms[randomIndex];
    }


    private void GenerateStart()
    {
        SpawnPlatform(_startPlatform);
        for (int i = 0; i < _maxPlatformCount; i++)
        {
            SpawnPlatform(GetRandomPlatform());
        }
    }

    private void RemoveActivePlatforms()
    {
        GameObject lostPlatform = _activePlatforms[0];
        _activePlatforms.RemoveAt(0);
        Destroy(lostPlatform);
    }
}
