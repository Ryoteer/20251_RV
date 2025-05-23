using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Rigidbody))]
public class ThirdPersonCharacter : MonoBehaviour
{
    [Header("<color=#997570>Animator</color>")]
    [SerializeField] private string _airBoolName = "isOnAir"; 
    [SerializeField] private string _deathTriggerName = "onDeath"; 
    [SerializeField] private string _interactTriggerName = "onInteract"; 
    [SerializeField] private string _jumpTriggerName = "onJump"; 
    [SerializeField] private string _xFloatName = "xAxis"; 
    [SerializeField] private string _zFloatName = "zAxis";

    [Header("<color=#997570>Health</color>")]
    [SerializeField] private float _maxHP = 100.0f;
    private float _actualHP;
    private bool _isAlive = true;

    [Header("<color=#997570>Inputs</color>")]
    [SerializeField] private KeyCode _interactKey = KeyCode.F;
    [SerializeField] private KeyCode _jumpKey = KeyCode.Space;
    [SerializeField] private KeyCode _tpKey = KeyCode.T;

    [Header("<color=#997570>Movement</color>")]
    [SerializeField] private float _jumpForce = 7.5f;
    [SerializeField] private float _moveSpeed = 4.0f;

    [Header("<color=#997570>Physics</color>")]
    [SerializeField] private float _groundDistance = 0.25f;
    [SerializeField] private LayerMask _groundMask;
    [SerializeField] private float _interactDistance = 2.0f;
    [SerializeField] private float _interactRadius =0.5f;
    [SerializeField] private LayerMask _interactMask;

    [Header("<color=#997570>UI</color>")]
    [SerializeField] private Image _lifeBarFill;
    [SerializeField] private Image _missionBox;
    [SerializeField] private TextMeshProUGUI _missionText;

    private Vector3 _dir = new(), _dirFix = new(), _cameraForwardFix = new(), _cameraRightFix = new(), _groundOffset = new();
    private Vector3 _spawnPoint = new();

    private Animator _animator;
    private Rigidbody _rb;
    private ThirdPersonCamera _camera;
    private Transform _cameraTransform;

    private Ray _groundRay, _interactRay;
    private RaycastHit _interactHit;

    private void Awake()
    {
        _actualHP = _maxHP;

        _rb = GetComponent<Rigidbody>();
        _rb.constraints = RigidbodyConstraints.FreezeRotation;
    }

    private void Start()
    {
        _spawnPoint = transform.position;

        _animator = GetComponentInChildren<Animator>();

        _cameraTransform = Camera.main.transform;
        _camera= Camera.main.GetComponentInParent<ThirdPersonCamera>();

        ModifyMissionText();
    }

    private void Update()
    {
        if (!_isAlive) return;

        _dir.x = Input.GetAxis("Horizontal");
        _animator.SetFloat(_xFloatName, _dir.x);
        _dir.z = Input.GetAxis("Vertical");
        _animator.SetFloat(_zFloatName, _dir.z);

        if (Input.GetKeyDown(_interactKey))
        {
            Interaction();
        }
        else if (Input.GetKeyDown(_tpKey))
        {
            Teleport(_spawnPoint);
        }

        _animator.SetBool(_airBoolName, IsOnAir());

        if (Input.GetKeyDown(_jumpKey) && !IsOnAir())
        {
            _animator.SetTrigger(_jumpTriggerName);
            Jump();
        }
    }

    private void FixedUpdate()
    {
        if (!_isAlive) return;

        if (_dir.sqrMagnitude != 0.0f)
        {
            Movement(_dir);
        }
    }

    private void Interaction()
    {
        _interactRay = new Ray(_camera.Target.position, _camera.Target.forward);

        if (Physics.SphereCast(_interactRay, _interactRadius, out _interactHit, _interactDistance, _interactMask))
        {
            Debug.Log($"Collided with {_interactHit.collider.name}.");

            if (_interactHit.collider.TryGetComponent(out IInteractable inter))
            {
                Debug.Log($"{_interactHit.collider.name}: valid interaction.");

                _animator.SetTrigger(_interactTriggerName);
                inter.OnInteract();
            }
        }
    }

    private bool IsOnAir()
    {
        _groundOffset = new Vector3(transform.position.x, transform.position.y + 0.1f, transform.position.z);

        _groundRay = new Ray(_groundOffset, -transform.up);

        return !Physics.Raycast(_groundRay, _groundDistance, _groundMask);
    }

    private void Jump()
    {
        _rb.AddForce(transform.up * _jumpForce, ForceMode.Impulse);
    }

    private void Movement(Vector3 dir)
    {
        _cameraForwardFix = _cameraTransform.forward;
        _cameraRightFix = _cameraTransform.right;

        _cameraForwardFix.y = 0.0f;
        _cameraRightFix.y = 0.0f;

        Rotate(_cameraForwardFix);

        _dirFix = (_cameraRightFix * dir.x + _cameraForwardFix * dir.z).normalized;

        _rb.MovePosition(transform.position + _dirFix * _moveSpeed * Time.fixedDeltaTime);
    }

    public void ModifyMissionText(string textToShow = "", bool isOnRange = false)
    {
        if (isOnRange)
        {
            _missionBox.enabled = true;
            _missionText.enabled = true;

            _missionText.text = textToShow;
        }
        else
        {
            _missionText.text = textToShow;

            _missionBox.enabled = false;
            _missionText.enabled = false;
        }
    }

    private void Rotate(Vector3 dir)
    {
        transform.forward = dir;
    }

    public void TakeDamage(int dmg)
    {
        _actualHP -= dmg;

        _lifeBarFill.fillAmount = _actualHP / _maxHP;

        if(_actualHP <= 0)
        {
            _isAlive = false;
            _animator.SetTrigger(_deathTriggerName);
        }
    }

    public void Teleport(Vector3 destination)
    {
        transform.position = destination;
    }
}
