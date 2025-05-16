using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FootballInteraction : MonoBehaviour, IInteractable
{
    private Animation _animation;

    private void Start()
    {
        _animation = GetComponent<Animation>();
    }

    public void OnInteract()
    {
        if (_animation.isPlaying)
        {
            return;
        }

        _animation.clip = _animation.GetClip("Bounce");
        _animation.Play();
    }
}
