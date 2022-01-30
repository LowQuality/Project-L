using Lab.Scripts.Util;
using UnityEngine;

namespace Lab.Scripts.Player
{
public class Movement : MonoBehaviour
{
    [SerializeField] private float walkSpeed;
    [SerializeField] private float runSpeed;
    [SerializeField] private float gravity;
    [SerializeField] private float decreaseStaminaRate;
    private float _applySpeed;

    private bool _isRun;
    private bool _isBorder;
    private static bool _canMove;
    private Stamina _stamina;
    private CharacterController _controller;
    private Vector3 _moveDir;
    private float _moveDirY;

    private void Start()
    {
        _stamina = FindObjectOfType<Stamina>();
        _controller = GetComponent<CharacterController>();
        _applySpeed = walkSpeed;
        
        _moveDir = Vector3.zero;

        // Debug (TODO: remove)
        Debug.Log(Application.version);
        // Application.targetFrameRate = 360; || Fixed
    }

    private void Update()
    {
        if (!_canMove) return;
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
        var move = Input.GetKey(KeyCode.W) && !Input.GetKey(KeyCode.S);
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
        // Old Movement Function
        // _moveDir = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        // _moveDir = transform.TransformDirection(_moveDir);
        // _moveDir *= _applySpeed;
        //
        // _controller.SimpleMove(_moveDir);

        if (_controller.isGrounded)
        {
            _moveDirY = 0f;
        }
        else
        {
            _moveDirY -= gravity * Time.deltaTime;
        }
        
        _moveDir = new Vector3(Input.GetAxisRaw("Horizontal"), _moveDirY, Input.GetAxisRaw("Vertical"));
        _moveDir = transform.TransformDirection(_moveDir);
        
        _moveDir.y -= gravity * Time.deltaTime;
        _controller.Move(_moveDir * (_applySpeed * Time.deltaTime));

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
    
    public static void SetMovement(bool canMove)
    {
        _canMove = canMove;
    }
}
}