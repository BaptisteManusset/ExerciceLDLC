using UnityEngine;

public class FpsController : MonoBehaviour {
    private const float Gravity = 20.0f;

    [Header("Movement"), SerializeField] private float walkingSpeed = 7.5f;
    [SerializeField] private float jumpSpeed = 8;

    [Header("Camera"), SerializeField] private Camera playerCamera;
    [Space] [SerializeField] private float lookSpeed = 2;
    [SerializeField] private float lookXLimit = 45;

    private CharacterController _characterController;
    private Vector3 _moveDirection = Vector3.zero;
    private float _rotationX;

    private void Awake() {
        _characterController = GetComponent<CharacterController>();
        LockCursor();
    }

    private void Update() {
        float speedVertical = walkingSpeed * Input.GetAxis("Vertical");
        float speedHorizontal = walkingSpeed * Input.GetAxis("Horizontal");
        float movementDirectionY = _moveDirection.y;

        _moveDirection = transform.forward * speedVertical + transform.right * speedHorizontal;

        if (Input.GetButton("Jump") && _characterController.isGrounded) {
            _moveDirection.y = jumpSpeed;
        }
        else {
            _moveDirection.y = movementDirectionY;
        }

        ApplyGravity();

        _characterController.Move(_moveDirection * Time.deltaTime);

        RotateCamera();
    }

    private void RotateCamera() {
        _rotationX += -Input.GetAxis("Mouse Y") * lookSpeed;
        _rotationX = Mathf.Clamp(_rotationX, -lookXLimit, lookXLimit);
        playerCamera.transform.localRotation = Quaternion.Euler(_rotationX, 0, 0);
        transform.rotation *= Quaternion.Euler(0, Input.GetAxis("Mouse X") * lookSpeed, 0);
    }



    /// <summary>
    /// lock the cursor to the center of the screen
    /// </summary>
    public static void LockCursor() {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    /// <summary>
    /// lock the cursor to the center of the screen
    /// </summary>
    public static void UnlockCursor() {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    private void ApplyGravity() {
        if (_characterController.isGrounded) return;
        _moveDirection.y -= Gravity * Time.deltaTime;
    }
}