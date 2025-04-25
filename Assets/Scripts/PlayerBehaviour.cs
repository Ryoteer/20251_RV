//Librerías
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Clase = comportamiento del código.
public class PlayerBehaviour : MonoBehaviour
{
    [Header("Inputs")]
    [SerializeField] private KeyCode _interactKey = KeyCode.F;

    [Header("Movement")]
    public float jumpForce = 7.5f;
    public float moveSpeed = 3.5f;

    [Header("Physics")]
    public float interactDistance = 1.5f;
    public LayerMask interactMask;
    public float groundRayDistance = 0.25f;
    public LayerMask groundRayMask;
    public Transform rayOrigin;

    private bool _isOnAir;

    private Vector3 _dir = Vector3.zero, _posOffset = Vector3.zero;

    private Animator _animator;
    private Rigidbody _rb;

    private Ray _groundRay, _interactRay;
    private RaycastHit _interactHit;

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

        _animator.SetBool("isOnAir", IsOnAir());

        if (Input.GetKeyDown(KeyCode.Space) && !IsOnAir())
        {
            _animator.SetTrigger("onJump");
            Jump();
        }

        if (Input.GetKeyDown(_interactKey))
        {
            Interact();
        }
        
    }

    private void FixedUpdate()
    {
        Movement();
    }

    private void Interact()
    {
        _interactRay = new Ray(rayOrigin.position, transform.forward);

        if (Physics.SphereCast(_interactRay, 0.25f, out _interactHit, interactDistance, interactMask))
        {
            _animator.SetTrigger("onInteract");

            if (_interactHit.collider.TryGetComponent(out IInteract interact))
            {
                interact.OnInteract();
            }
        }
    }

    private bool IsOnAir()
    {
        _posOffset = new Vector3(transform.position.x, transform.position.y + (groundRayDistance / 2.0f), transform.position.z);

        _groundRay = new Ray(_posOffset, -transform.up);

        return !Physics.Raycast(_groundRay, groundRayDistance, groundRayMask);
    }

    private void Jump()
    {
        _rb.AddForce(transform.up * jumpForce, ForceMode.Impulse);
    }

    private void Movement()
    {
        _rb.MovePosition(transform.position + _dir * moveSpeed * Time.fixedDeltaTime);
    }
}
