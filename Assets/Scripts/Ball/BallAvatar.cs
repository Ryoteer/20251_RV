using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallAvatar : MonoBehaviour
{
    private BallSpawner _spawner;

    private void Start()
    {
        _spawner = GetComponentInChildren<BallSpawner>();
    }

    public void SpawnObject()
    {
        _spawner.SpawnObject();
    }
}
