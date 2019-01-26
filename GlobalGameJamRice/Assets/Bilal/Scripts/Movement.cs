using UnityEngine;
using System.Collections;



public class Movement : MonoBehaviour
{
    public float speed = 6.0f;
    public float jumpSpeed = 8.0f;
    public float gravity = 20.0f;
    public float sprintSpeed = 5.0f; 

    private Vector3 moveDirection = Vector3.zero;
    private CharacterController controller;
    public bool onLadder = false;

    void Start()
    {
        controller = GetComponent<CharacterController>();

     
    }

    void Update()
    {

        if (controller.isGrounded && !onLadder)
        {
         
            if (Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift))
            {
                moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0.0f, Input.GetAxis("Vertical"));
                moveDirection = transform.TransformDirection(moveDirection);
                moveDirection = moveDirection * sprintSpeed;
            }
            else
            {
                moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0.0f, Input.GetAxis("Vertical"));
                moveDirection = transform.TransformDirection(moveDirection);
                moveDirection = moveDirection * speed;
            }
            
        }
        if (Input.GetKey(KeyCode.W) && onLadder)
        {
           transform.Translate(0, Time.deltaTime, 0, Space.World);
        }
        if (Input.GetKey(KeyCode.S) && onLadder)
        {
            transform.Translate(0, Time.deltaTime, 0, Space.World);
        }   

        moveDirection.y = moveDirection.y - (gravity * Time.deltaTime);

     
        controller.Move(moveDirection * Time.deltaTime);
    }
   
}