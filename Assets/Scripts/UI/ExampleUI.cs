using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ExampleUI : MonoBehaviour
{
    private Image _image;

    private bool _state = true;

    private void Start()
    {
        _image = GetComponent<Image>();

        EnableImage();
    }

    public void EnableImage()
    {
        _state = !_state;

        if(_state == false)
        {
            _image.enabled = false;
        }
        else
        {
            _image.enabled = true;
        }
    }
}
