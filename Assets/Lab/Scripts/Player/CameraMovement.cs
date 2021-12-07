using UnityEngine;

namespace Lab.Scripts.Player {
public class CameraMovement : MonoBehaviour {
    // Sensitivity of mouse movement
    [SerializeField] private float lookSensitivity;

    // Camera Rotation Limit
    [SerializeField] private float cameraRotationLimit;
    private float _currentCameraRotationX;
    
    // Component
    [SerializeField] private Camera getCamera;
    
    private Rigidbody _rigidbody;
    
    private void Start() {
        getCamera = FindObjectOfType<Camera>();
        _rigidbody = GetComponent<Rigidbody>();
        
        // Hide and lock cursor
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void Update() {
        // Camera Movement
        CameraRotation();
        CharacterRotation();
    }
    
    private void CameraRotation() {
        var xRotation = Input.GetAxisRaw("Mouse Y");
        var cameraRotationX = xRotation * lookSensitivity;

        _currentCameraRotationX -= cameraRotationX;
        _currentCameraRotationX = Mathf.Clamp(_currentCameraRotationX, -cameraRotationLimit, cameraRotationLimit);

        getCamera.transform.localEulerAngles = new Vector3(_currentCameraRotationX, 0f, 0f);
    }

    private void CharacterRotation() {
        var yRotation = Input.GetAxisRaw("Mouse X");
        var characterRotationY = new Vector3(0f, yRotation, 0f) * lookSensitivity;

        _rigidbody.MoveRotation(_rigidbody.rotation * Quaternion.Euler(characterRotationY));
    }
}
}