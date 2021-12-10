using Lab.Scripts.Util;
using UnityEngine;

namespace Lab.Scripts.Player {
public class Movement : MonoBehaviour {
    [SerializeField] private float walkSpeed;
    [SerializeField] private float runSpeed;
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
        if (!(Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D))) return;
        if (Input.GetKey(KeyCode.LeftShift) && _stamina.GetCurrentSp() > 0) {
            _isRun = true;
        }
        if (Input.GetKeyUp(KeyCode.LeftShift) || _stamina.GetCurrentSp() <= 0) {
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
            _stamina.DecreaseStamina(1);
            _applySpeed = runSpeed;
        } else {
            _isRun = false;
            _applySpeed = walkSpeed;
        }
    }
}
}