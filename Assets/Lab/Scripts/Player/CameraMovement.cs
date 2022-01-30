using UnityEngine;

namespace Lab.Scripts.Player
{
public class CameraMovement : MonoBehaviour
{
    // Sensitivity of mouse movement
    [SerializeField] private float lookSensitivity;

    // Camera Rotation Limit
    [SerializeField] private float cameraRotationLimitMin;
    [SerializeField] private float cameraRotationLimitMax;
    
    // FreeLook Camera Rotation Limit
    [SerializeField] private float freeLookCameraRotationLimitMin;
    [SerializeField] private float freeLookCameraRotationLimitMax;

    // Component
    [SerializeField] private Camera getCamera;
    private float _xRotate;
    private float _xRotateFreeLook;
    private float _yRotate;
    public static bool IsPaused;

    private void Start()
    {
        getCamera = FindObjectOfType<Camera>();
        IsPaused = false;
    }

    private void Update()
    {
        // Pause
        if (IsPaused)
        {
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
            Movement.SetMovement(false);
        }
        else
        {
            // Camera Movement
            CameraRotation();
            CharacterRotation();
            
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
            Movement.SetMovement(true);
        }
    }

    private void CharacterRotation()
    {
        var yRotateSize = Input.GetAxis("Mouse X") * lookSensitivity;

        // Free Look Camera Rotation
        if (Input.GetKey(KeyCode.LeftAlt))
        {
            _yRotate = Mathf.Clamp(_yRotate + yRotateSize, freeLookCameraRotationLimitMin, freeLookCameraRotationLimitMax);
        }
        else
        {
            _yRotate = 0f;
            transform.Rotate(0f, yRotateSize, 0f);
        }
    }

    private void CameraRotation()
    {
        var xRotateSize = -Input.GetAxis("Mouse Y") * lookSensitivity;
        
        // Free Look Camera Rotation
        if (Input.GetKey(KeyCode.LeftAlt))
        {
            _xRotateFreeLook = Mathf.Clamp(_xRotateFreeLook + xRotateSize, cameraRotationLimitMin, cameraRotationLimitMax);

            getCamera.transform.localEulerAngles = new Vector3(_xRotateFreeLook, _yRotate, 0f);
        }
        else
        {
            _xRotateFreeLook = _xRotate;
            _xRotate = Mathf.Clamp(_xRotate + xRotateSize, cameraRotationLimitMin, cameraRotationLimitMax);
            
            getCamera.transform.localEulerAngles = new Vector3(_xRotate, _yRotate, 0f);
        }
    }
}
}