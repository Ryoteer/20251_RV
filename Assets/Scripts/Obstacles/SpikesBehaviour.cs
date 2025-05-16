using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikesBehaviour : MonoBehaviour
{
    [Header("Values")]
    [SerializeField] private int _dmg = 10;

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.TryGetComponent(out ThirdPersonCharacter player))
        {
            player.TakeDamage(_dmg);
        }
    }
}
