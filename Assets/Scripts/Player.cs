using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private CharacterController _characterController;
    public PlayerInput PlayerInput { get; } = new PlayerInput();

    private void Awake()
    {
        _characterController = GetComponent<CharacterController>();
        // PlayerInput = new PlayerInput();
    }

    private void Update()
    {
        Vector3 movementInput = new Vector3(0f, 0f, PlayerInput.Vertical);
        Vector3 movement = transform.rotation * movementInput;
        _characterController.SimpleMove(movement);
    }
}

public class PlayerInput
{
    public float Vertical { get; set; } // => Input.GetAxis("Vertical");
}