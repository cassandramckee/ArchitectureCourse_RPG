﻿using UnityEngine;

public class Player : MonoBehaviour
{
    private CharacterController _characterController;
    public IPlayerInput PlayerInput { get; set; } = new PlayerInput();

    private void Awake()
    {
        _characterController = GetComponent<CharacterController>();
    }

    private void Update()
    {
        Vector3 movementInput = new Vector3(PlayerInput.Horizontal, 0f, PlayerInput.Vertical);
        Vector3 movement = transform.rotation * movementInput;
        _characterController.SimpleMove(movement);
    }
}

public class PlayerInput : IPlayerInput
{
    public float Vertical => Input.GetAxis("Vertical");
    public float Horizontal => Input.GetAxis("Horizontal");
}

public interface IPlayerInput
{
    float Vertical { get; }
    float Horizontal { get; }
}