using UnityEngine;

namespace Lab.Scripts.Player {
public class Movement : MonoBehaviour {
    [SerializeField] private float walkSpeed;
    [SerializeField] private float runSpeed;
    private float _applySpeed;

    private bool _isRun;

    private void Start() {
        _applySpeed = walkSpeed;
    }

    private void Update() {
        // Player movement
        Move();
        Run();
    }
    
    private void Run() {
        if (Input.GetKey(KeyCode.LeftShift)) {
            Running();
        }
        else if (Input.GetKeyUp(KeyCode.LeftShift)) {
            RunningCancel();
        }
    }
    
    private void Move() {
        var moveDirX = Input.GetAxis("Horizontal");
        var moveDirZ = Input.GetAxis("Vertical");
        
        transform.Translate(moveDirX * _applySpeed * Time.deltaTime, 0, moveDirZ * _applySpeed * Time.deltaTime);
    }
    
    private void Running() {
        _isRun = true;
        _applySpeed = runSpeed;
    }

    private void RunningCancel() {
        _isRun = false;
        _applySpeed = walkSpeed;
    }
}
}