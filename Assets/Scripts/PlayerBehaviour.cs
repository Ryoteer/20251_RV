//Librerías
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Clase = comportamiento del código.
public class PlayerBehaviour : MonoBehaviour
{
    public float moveSpeed = 3.5f;

    private Vector3 _dir = Vector3.zero;

    private Rigidbody _rb;

    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        _dir.x = Input.GetAxis("Horizontal");
        _dir.z = Input.GetAxis("Vertical");

        Movement();
    }

    void Movement()
    {
        _rb.MovePosition(transform.position + _dir * moveSpeed * Time.deltaTime);
    }
}
