using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private PlayerInputActions playerControls;

    [SerializeField]
    private Rigidbody2D rb;

    [SerializeField]
    private float moveSpeed = 500f;
    private Vector2 moveDirection = Vector2.zero;

    private InputAction move;
    private InputAction fire;
    private InputAction dash;
    private InputAction interact;
    private InteractablesManager interManager;
    


    private void Awake()
    {
        playerControls = new PlayerInputActions();
        interManager = GameObject.FindGameObjectWithTag("Manager").GetComponent<InteractablesManager>();

    }

    private void OnEnable()
    {
        move = playerControls.Player.Move;
        move.Enable();

        fire = playerControls.Player.Fire;
        fire.Enable();
        fire.performed += Fire;

        dash = playerControls.Player.Dash;
        dash.Enable();
        dash.performed += Dash;

        interact = playerControls.Player.Interact;
        interact.Enable();
        interact.performed += Interact;

    }

    private void OnDisable()
    {
        move.Disable();
        fire.Disable();
        interact.Disable();
    }

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        moveDirection = move.ReadValue<Vector2>();
    }

    private void FixedUpdate()
    {
        rb.velocity = moveDirection * moveSpeed * Time.fixedDeltaTime;
    }

    private void Fire(InputAction.CallbackContext context)
    {
        Debug.Log("We fired");
    }

    private void Dash(InputAction.CallbackContext context)
    {
        Debug.Log("Dashed");
    }
    
    private void Interact(InputAction.CallbackContext context)
    {
        interManager.Doors();
    }
}
