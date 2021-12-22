
using Lab.Scripts.Util;
using UnityEngine;

namespace Lab.Scripts.Player
{
public class Movement : MonoBehaviour
{
    [SerializeField] private float walkSpeed;
    [SerializeField] private float runSpeed;
    // [SerializeField] private float gravity;
    [SerializeField] private float decreaseStaminaRate;
    private float _applySpeed;

    private bool _isRun;
    private bool _isBorder;
    private Stamina _stamina;
    private CharacterController _controller;
    private Vector3 _moveDir;

    private void Start()
    {
        _stamina = FindObjectOfType<Stamina>();
        _controller = GetComponent<CharacterController>();
        _applySpeed = walkSpeed;
        
        _moveDir = Vector3.zero;

        // Debug (TODO: remove)
        Debug.Log(Application.version);
        Application.targetFrameRate = 360;
    }

    private void Update()
    {
        Move();
        Run();

        _isBorder = (_controller.collisionFlags & CollisionFlags.Sides) != 0;
    }

    private void FixedUpdate()
    {
        CheckRunning();
    }

    private void Run()
    {
        var move = Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D);
        var run = Input.GetKey(KeyCode.LeftShift);
        var stamina = _stamina.GetCurrentSp();
        if (move && run && stamina > 0)
        {
            _isRun = true;
        }
        else if ((!(move || run) || !(move && run)) || stamina <= 0)
        {
            _isRun = false;
        }
    }

    private void Move()
    {
        _moveDir = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        _moveDir = transform.TransformDirection(_moveDir);
        _moveDir *= _applySpeed;

        _controller.SimpleMove(_moveDir);
    }

    private void CheckRunning()
    {
        if (_isRun && _controller.isGrounded && !_isBorder)
        {
            _isRun = true;
            _stamina.DecreaseStamina(decreaseStaminaRate);
            _applySpeed = runSpeed;
        }
        else
        {
            _isRun = false;
            _applySpeed = walkSpeed;
        }
    }
}
}