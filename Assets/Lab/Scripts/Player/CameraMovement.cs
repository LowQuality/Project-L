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

    // Component
    [SerializeField] private Camera getCamera;
    private float _xRotate;
    public static bool isPaused;

    private void Start()
    {
        getCamera = FindObjectOfType<Camera>();
    }

    private void Update()
    {
        // Pause
        if (isPaused)
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

    private void CameraRotation()
    {
        var xRotateSize = -Input.GetAxis("Mouse Y") * lookSensitivity;
        _xRotate = Mathf.Clamp(_xRotate + xRotateSize, cameraRotationLimitMin, cameraRotationLimitMax);

        getCamera.transform.localEulerAngles = new Vector3(_xRotate, 0f, 0f);
    }

    private void CharacterRotation()
    {
        var yRotateSize = Input.GetAxis("Mouse X") * lookSensitivity;

        transform.Rotate(0f, yRotateSize, 0f);
    }
}
}