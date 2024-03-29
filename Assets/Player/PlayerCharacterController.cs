using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCharacterController : MonoBehaviour
{
    [SerializeField] private LayerMask groundLayers;
    [SerializeField] private float runSpeed = 8f;
    [SerializeField] private float jumpHeight = 2f;
    private float gravity = -50f;
    private CharacterController characterController;
    private Vector3 velocity;
    private bool isGrounded;
    private float horizontalInput;

    private bool left;
    private bool right;

    public Animator animator;

    // Start is called before the first frame update
    void Start()
    {
    
       characterController = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        MoveRightLeft();

        horizontalInput = 1;
       
        // Face toward
        // transform.forward = new Vector3(horizontalInput, 0, Mathf.Abs(horizontalInput) - 1);

        // IsGrounded
        isGrounded = Physics.CheckSphere(transform.position, 0.1f, groundLayers, QueryTriggerInteraction.Ignore);

        if (isGrounded && velocity.y < 0)
        {
            velocity.y = 0;
        }
        else
        {
            // Add gravity on every frame
            velocity.y += gravity * Time.deltaTime;
        }
         
        //anim
        if (isGrounded)
        {
            animator.SetBool("isGrounded", true);
        }

        characterController.Move(new Vector3(0, 0, horizontalInput * runSpeed) * Time.deltaTime); 
        
        
        // Vertical velocity
        characterController.Move(velocity * Time.deltaTime);
    }


    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Jump"))
        {
            // Add jump
            if (isGrounded)
            {
                animator.SetBool("isJumping", true);
                velocity.y += Mathf.Sqrt(jumpHeight * -2 * gravity);
            }
            else
            {
                animator.SetBool("isGrounded", true);
                animator.SetBool("isJumping", false);
            }
        }
    }

    void MoveRightLeft() // ABSTRACTION
    {
        Vector3 right = new Vector3(3, 0, 0);
        Vector3 left = new Vector3(-3, 0, 0);
        if (Input.GetKey(KeyCode.D))
        {
            characterController.Move(right * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.A))
        {
            characterController.Move(left * Time.deltaTime);
        }
    }
}
