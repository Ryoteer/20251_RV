using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonBehaviour : MonoBehaviour, IInteractable
{
    [SerializeField] private BallSpawner _spawner;

    private Animation _animation;

    private void Start()
    {
        _animation = GetComponentInParent<Animation>();
    }

    public void OnInteract()
    {
        if (_animation.isPlaying) return;

        _animation.Play();
    }
}
