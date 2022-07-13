using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
   //VARIABLES
   public float moveSpeed;
   public float walkSpeed;
   public float runSpeed;

   private Vector3 moveDirection;

   public bool isGrounded;



   //REFERENCES
   private CharacterController controller;
   private void Start()
   {
    controller = GetComponent<CharacterController>();
   }

   private void Update()
   {
    Move();
   }

   private void Move()
   {
    float moveZ = Input.GetAxis("Vertical");
    moveDirection = new Vector3(0,0,moveZ);
    if(moveDirection != Vector3.zero && !Input.GetKey(KeyCode.LeftShift))
    {
        //Walk
        Walk();
    }
    else if (moveDirection != Vector3.zero && Input.GetKey(KeyCode.LeftShift))
    {
        //Run
        Run();
    }
    else if(moveDirection == Vector3.zero)
    {
        //Idle
        Idle();
    }
    moveDirection *= moveSpeed;
    controller.Move(moveDirection * Time.deltaTime);
   }

   private void Idle()
   {

   }

   private void Walk()
   {
    moveSpeed = walkSpeed;
   }
   
   private void Run()
   {
    moveSpeed = runSpeed;
   }


}
