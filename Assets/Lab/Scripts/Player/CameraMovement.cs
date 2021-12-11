using UnityEngine;

namespace Lab.Scripts.Player {
public class CameraMovement : MonoBehaviour {
    // Sensitivity of mouse movement
    [SerializeField] private float lookSensitivity;

    // Camera Rotation Limit
    [SerializeField] private float cameraRotationLimitMin;
    [SerializeField] private float cameraRotationLimitMax;
    
    // Component
    [SerializeField] private Camera getCamera;
    
    private Rigidbody _rigidbody;
    private float _xRotate;
    
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
        var xRotateSize = -Input.GetAxis("Mouse Y") * lookSensitivity;
        _xRotate = Mathf.Clamp(_xRotate + xRotateSize, cameraRotationLimitMin, cameraRotationLimitMax);

        getCamera.transform.localEulerAngles = new Vector3(_xRotate, 0f, 0f);
    }
    
    private void CharacterRotation() {
        var yRotateSize = Input.GetAxis("Mouse X") * lookSensitivity;
        
        _rigidbody.MoveRotation(_rigidbody.rotation * Quaternion.Euler(new Vector3(0f, yRotateSize, 0f)));
    }
}
}