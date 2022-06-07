using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class followme : MonoBehaviour
{
   [SerializeField] private float moveSpeed;
   [SerializeField] private float walkSpeed;
   [SerializeField]private float runSpeed;
   [SerializeField] private bool isGrounded;
   [SerializeField] private float groundCheckDistance;
   [SerializeField] private LayerMask groundMask;
   [SerializeField] private float gravity;
   public Animator animator;
   private bool isGround;
[SerializeField] private float jumpHeight;

   private Vector3 moveDirection;
    private Vector3 velocity;
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
       if(controller.isGrounded)
       {
           moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0.0f, Input.GetAxis("Vertical"));
       }
       isGrounded = Physics.CheckSphere(transform.position, groundCheckDistance,groundMask);
       if (isGrounded && velocity.y < 0)
       {
           velocity.y = -2f;
       }
       
        float vertical = Input.GetAxis("Vertical");
        float horizontal = Input.GetAxis("Horizontal");
        //transform.Translate(new Vector3(horizontal,0,vertical) * (moveSpeed * Time.deltaTime));
      
       
   if (Input.GetKey(KeyCode.RightArrow)){
		transform.position += Vector3.right * moveSpeed * Time.deltaTime;
       
       
	}
	if (Input.GetKey(KeyCode.LeftArrow)){
		transform.position += Vector3.left * moveSpeed * Time.deltaTime;
	}
	if (Input.GetKey(KeyCode.UpArrow)){
		transform.position += Vector3.up* moveSpeed* Time.deltaTime;
	}
	if (Input.GetKey(KeyCode.DownArrow)){
		transform.position += Vector3.down *moveSpeed * Time.deltaTime;
	}
    
   
    moveDirection = transform.TransformDirection(moveDirection);
   
    if(isGrounded)
    {
// moveDirection *= walkSpeed;
   if (moveDirection != Vector3.zero && !Input.GetKey(KeyCode.LeftShift))
   {
       //player is just walking 
       Walk();
  animator.SetFloat("puppyfloat",Mathf.Abs( horizontal));
    animator.SetFloat("puppyfloat]",Mathf.Abs( vertical));
       
   }
   else if(moveDirection != Vector3.zero && Input.GetKey(KeyCode.LeftShift))
   {
       //now running 
        Run();
        animator.SetFloat("puppyfloat",Mathf.Abs( horizontal));
    animator.SetFloat("puppyfloat]",Mathf.Abs( vertical));
       
   }
   else if(moveDirection == Vector3.zero)
   {
       // i am idle 
        Idle();
   }
        moveDirection *= moveSpeed;
        if(Input.GetKeyDown(KeyCode.Space))
        {
            Jump();
             animator.SetBool("isGround",true);
        }
     else 
     animator.SetBool("isGround",false);
       
    }
     
   
   
    controller.Move(moveDirection * Time.deltaTime);
    velocity.y += gravity *Time.deltaTime;
    controller.Move(velocity * Time.deltaTime);

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
 
 private void Jump()
 {
 
 
 }
    
}
