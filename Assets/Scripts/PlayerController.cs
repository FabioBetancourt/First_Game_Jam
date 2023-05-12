using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;


public class PlayerController : MonoBehaviour
{
   private Rigidbody playerRb;
   public float speed;
   public float jumpForce = 10f;
   public float gravityModifier;
   public bool isOnGround = true;
   private Animator animator;
   private bool isRunning = false;
   private int currentPosition= 0;
   public float transitionTime;

   private void Start()
   {
      playerRb = GetComponent<Rigidbody>();
      animator = GetComponent<Animator>();
      Physics.gravity *= gravityModifier;
   }
   private void FixedUpdate()
   {
      if (isRunning && isOnGround)
      {
         playerRb.velocity = new Vector3(playerRb.velocity.x, playerRb.velocity.y, speed);
      }
   }
   
   private void Update()
   {
      changeAxisX();
      CheckKeyboard();
      if (Input.GetKeyDown(KeyCode.G))
      {
         isRunning = true; 
      }

      if (playerRb.velocity.z > 0.1f)
      {
         animator.SetBool("isRunning", true);
      }
      else
      {
         animator.SetBool("isRunning", false);
      }
   }

   private void changeAxisX()
   {
      float difference = Math.Abs(transform.position.x - currentPosition);
      transform.position = new Vector3(Mathf.Lerp(transform.position.x,currentPosition, transitionTime), transform.position.y, transform.position.z);

   }

   private void OnCollisionEnter(Collision collision)
   {
      if (collision.gameObject.CompareTag("Ground"))
      {
         isOnGround = true;
         if (Input.GetKey(KeyCode.W))
         {
            animator.SetBool("isRunning", true); // Continúa la animación de correr si "W" todavía está siendo presionada
         }
         else
         {
            animator.SetBool("isRunning", false); // Cambia a la animación por defecto si ninguna tecla está siendo presionada
         }
      }

      if (collision.gameObject.CompareTag("Obstacle"))
      {
         animator.Play("Stumble Backwards");
         isRunning = false;
         playerRb.velocity = new Vector3(playerRb.velocity.x, playerRb.velocity.y, 0);
      }
   }

   private void OnTriggerEnter(Collider other)
   {
      if (other.CompareTag("Obstacle"))
      {
         animator.Play("Stumble Backwards");
         isRunning = false;
         playerRb.velocity = new Vector3(playerRb.velocity.x, playerRb.velocity.y, 0);
      }
   }

   public void Jump(int positionX)
   {
      playerRb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
      currentPosition = positionX;
      animator.gameObject.GetComponent<Animator>().Play($"Front Twist Flip");
      isOnGround = false;
   }

   public void CheckKeyboard()
   {
      if (isOnGround)
      {
         if (Input.GetKeyDown(KeyCode.Space))
         {
            Jump(currentPosition);
         }

         if (Input.GetKeyDown(KeyCode.A))
         {
            Jump(-2);
         }

         if (Input.GetKeyDown(KeyCode.S))
         {
            Jump(-4);
         }
         if (Input.GetKeyDown(KeyCode.D))
         {
            Jump(-6);
         }
         if (Input.GetKeyDown(KeyCode.F))
         {
            Jump(-8);
         }
         if (Input.GetKeyDown(KeyCode.G))
         {
            Jump(-10);
         }
      }
      
   }
}

