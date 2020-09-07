using UnityEngine;

public class Player : MonoBehaviour
{
    private CharacterController _characterController;
    private IMover _mover;
    private Rotator _rotator;
    public IPlayerInput PlayerInput { get; set; } = new PlayerInput();

    private void Awake()
    {
        _mover = new Mover(this);
        _rotator = new Rotator(this);
        _characterController = GetComponent<CharacterController>();

        PlayerInput.MoveModeTogglePressed += MoveModeTogglePressed;
    }

    private void MoveModeTogglePressed()
    {
        if (_mover is NavmeshMover)
            _mover = new Mover(this);
        else
            _mover = new NavmeshMover(this);
    }

    private void Update()
    {
        _mover.Tick();
        _rotator.Tick();
        PlayerInput.Tick();
    }
}