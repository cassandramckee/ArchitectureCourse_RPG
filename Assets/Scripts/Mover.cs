using UnityEngine;
using UnityEngine.AI;

public class Mover : IMover
{
    private readonly Player _player;
    private readonly CharacterController _characterController;

    public Mover(Player player)
    {
        _player = player;
        // Will swap out at some point
        _characterController = _player.GetComponent<CharacterController>();
        // Disable any navmesh agents we have, quick hack, will fail if null?
        _player.GetComponent<NavMeshAgent>().enabled = false;
    }

    public void Tick()
    {
        Vector3 movementInput = new Vector3(_player.PlayerInput.Horizontal, 0f, _player.PlayerInput.Vertical);
        Vector3 movement = _player.transform.rotation * movementInput;
        _characterController.SimpleMove(movement);
    }
}