using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallSpawner : MonoBehaviour
{
    [Header("Objects")]
    [SerializeField] private GameObject _objToSpawn;
    [SerializeField] private Transform _spawnTransform;

    private GameObject _spawnedObj;

    public void SpawnObject()
    {
        if (_spawnedObj) //lo mismo que : _spawnObj != null
        {
            Destroy(_spawnedObj.gameObject);
        }

        _spawnedObj = Instantiate(_objToSpawn, _spawnTransform.position, _spawnTransform.rotation);
    }
}
