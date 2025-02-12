using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(CharacterController))]
public class PlayerController : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 5;
    [SerializeField] private float lookSpeed = 20;
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
        _controller.Move(move * (moveSpeed * Time.deltaTime));


        var look = _playerInput.actions["Look"].ReadValue<Vector2>();
        var rotation = new Vector3(-look.y, look.x);
        transform.Rotate(rotation * (lookSpeed * Time.deltaTime));
    }
}
