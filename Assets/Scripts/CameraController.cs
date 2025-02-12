using UnityEngine;
using UnityEngine.InputSystem;

public class CameraController : MonoBehaviour
{
    [SerializeField] private float sensitivity = 0.5f;
    [SerializeField] private Vector2 verticalLimits = new(-50, 50);

    [SerializeField] private PlayerInput _playerInput;

    private float _rotationX = 0;

    void Update()
    {
        var look = _playerInput.actions["Look"].ReadValue<Vector2>();

        _rotationX -= look.y * sensitivity;
        _rotationX = Mathf.Clamp(_rotationX, verticalLimits.x, verticalLimits.y);

        float delta = look.x * sensitivity;
        float rotationY = transform.localEulerAngles.y + delta;

        transform.localEulerAngles = new Vector3(_rotationX, rotationY, 0);
    }
}
