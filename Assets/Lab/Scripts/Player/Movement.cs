using Lab.Scripts.Util;
using UnityEngine;

namespace Lab.Scripts.Player {
public class Movement : MonoBehaviour {
    [SerializeField] private float walkSpeed;
    [SerializeField] private float runSpeed;
    [SerializeField] private float decreaseStaminaRate;
    private float _applySpeed;

    private bool _isRun;
    private Stamina _stamina;

    private void Start() {
        _stamina = FindObjectOfType<Stamina>();
        _applySpeed = walkSpeed;
    }

    private void Update() {
        // Player movement
        Move();
        Run();
    }

    private void FixedUpdate() {
        CheckRunning();
    }

    private void Run() {
        var move = Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D);
        var run = Input.GetKey(KeyCode.LeftShift);
        var stamina = _stamina.GetCurrentSp();
        if (move && run && stamina > 0) {
            _isRun = true;
        } else if ((!(move || run) || !(move && run)) || stamina <= 0) {
            _isRun = false;
        }
    }
    
    private void Move() {
        var moveDirX = Input.GetAxis("Horizontal");
        var moveDirZ = Input.GetAxis("Vertical");
        
        transform.Translate(moveDirX * _applySpeed * Time.deltaTime, 0, moveDirZ * _applySpeed * Time.deltaTime);
    }

    private void CheckRunning() {
        if (_isRun) {
            _isRun = true;
            _stamina.DecreaseStamina(decreaseStaminaRate);
            _applySpeed = runSpeed;
        } else {
            _isRun = false;
            _applySpeed = walkSpeed;
        }
    }
}
}