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
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
            _mover = new Mover(this);
        if (Input.GetKeyDown(KeyCode.Alpha2))
            _mover = new NavmeshMover(this);
        
        _mover.Tick();
        _rotator.Tick();
    }
}