using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Rendering;

public class CharacterMovement : MonoBehaviour
{
    public float moveSpeed;
    public float jumpForce;

    Vector2 moveInput;

    PlayerInput playerInput;

    //terrain
    public Transform terrainCheck;
    public float altitude;
    public LayerMask terrainMask;
    bool isGrounded;

    Rigidbody rb;

    void Start()
    {

        rb = GetComponent<Rigidbody>();

        playerInput = new PlayerInput();
        
    }

    void Update()
    {
        checkTerrain();
    }

    private void FixedUpdate()
    {
        MovePlayer();
    }


    //Movement
    void OnJump()
    {
        if(isGrounded)
            rb.AddForce(new Vector3(0,jumpForce,0), ForceMode.Impulse);
    }
    
    void checkTerrain()
    {
        isGrounded = Physics.CheckSphere(terrainCheck.position, altitude, terrainMask);
    }

    public void OnMovement(InputValue value)
    {
        moveInput = value.Get<Vector2>();
    }

    void MovePlayer()
    {
        Vector3 direction = transform.right * moveInput.x + transform.forward * moveInput.y;
        direction.Normalize();
        rb.linearVelocity = new Vector3(direction.x * moveSpeed, rb.linearVelocity.y, direction.z * moveSpeed);

    }
}
