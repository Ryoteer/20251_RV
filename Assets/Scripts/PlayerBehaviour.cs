//Librerías
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Clase = comportamiento del código.
public class PlayerBehaviour : MonoBehaviour
{
    public float jumpForce = 7.5f;
    public float moveSpeed = 3.5f;

    private bool _isJumping = false;

    private Vector3 _dir = Vector3.zero;

    private Rigidbody _rb;
    private Animator _animator;

    // Start is called before the first frame update
    private void Start()
    {
        _rb = GetComponent<Rigidbody>();
        _animator = GetComponentInChildren<Animator>();
    }

    // Update is called once per frame
    private void Update()
    {
        _dir.x = Input.GetAxis("Horizontal");
        _animator.SetFloat("xAxis", _dir.x);
        _dir.z = Input.GetAxis("Vertical");
        _animator.SetFloat("zAxis", _dir.z);

        if (Input.GetKeyDown(KeyCode.Space) && _isJumping == false)
        {
            _isJumping = true;
            Jump();
        }
    }

    private void FixedUpdate()
    {
        Movement();
    }

    private void Jump()
    {
        _rb.AddForce(transform.up * jumpForce, ForceMode.Impulse);
    }

    private void Movement()
    {
        _rb.MovePosition(transform.position + _dir * moveSpeed * Time.fixedDeltaTime);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(_isJumping == true)
        {
            _isJumping = false;
        }
    }
}
