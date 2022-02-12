using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    PlayerControls playerControls;
    Unit unit;
    MenuControls menuControls;

    Interact interact;
    Vector2 direction;
    void Awake()
    {
        playerControls = new PlayerControls();

        playerControls.Gameplay.Direction.started += OnMovement;
        playerControls.Gameplay.Direction.performed += OnMovement;
        playerControls.Gameplay.Direction.canceled += OnMovement;
        playerControls.Gameplay.Confirm.started += OnInteract;

        playerControls.Gameplay.Cancel.started += OnCancel;
        playerControls.Gameplay.Menu.started += OnMenu;

        unit = GetComponent<Unit>();
        interact = GetComponent<Interact>();
        menuControls = GetComponent<MenuControls>();
    }
    private void OnEnable()
    {
        playerControls.Enable();
    }
    private void OnDisable()
    {
        playerControls.Disable();
    }
    private void Update()
    {
        if (direction.x == -1 || direction.x == 1 || direction.y == -1 || direction.y == 1)
            unit.Move(direction);

    }
    public void OnMovement(InputAction.CallbackContext context)
    {
        direction = context.ReadValue<Vector2>();
       // unit.Move(direction);
    }
    public void OnInteract(InputAction.CallbackContext context)
    {
        interact.Interaction();
    }
    public void OnCancel(InputAction.CallbackContext context)
    {
        interact.Cancel();
    }

    public void OnMenu(InputAction.CallbackContext context)
    {
        menuControls.HandleMenuCalls();
    }
}
