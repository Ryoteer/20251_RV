using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerUIBehaviour : MonoBehaviour
{
    [Header("UI")]
    [SerializeField] private string _textToShow = "Presiona 'F' para interactuar con la pelota.";

    private void OnTriggerEnter(Collider other)
    {
        if(other.TryGetComponent(out ThirdPersonCharacter player))
        {
            player.ModifyMissionText(_textToShow, true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.TryGetComponent(out ThirdPersonCharacter player))
        {
            player.ModifyMissionText();
        }
    }
}
