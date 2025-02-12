using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(CharacterController))]
public class PlayerController : MonoBehaviour
{
    [SerializeField] private float speed = 5;
    private CharacterController _controller;
    private PlayerInput _playerInput;
    private Transform _cameraTransform;

    void Start()
    {
        _controller = GetComponent<CharacterController>();
        _playerInput = GetComponent<PlayerInput>();
        _cameraTransform = GetComponentInChildren<Camera>().GetComponent<Transform>();
    }

    void Update()
    {
        var input = _playerInput.actions["Move"].ReadValue<Vector2>();
        var move = new Vector3(input.x, 0, input.y);
        move = move.x * _cameraTransform.right + move.z * _cameraTransform.forward;
        move.y = 0;
        _controller.Move(move * (speed * Time.deltaTime));
    }
}
