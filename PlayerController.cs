using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    float horizontalInput;
    float verticalInput; 

    float moveSpeed = 10f;
    float jumpSpeed = 10f;

    public float health = 1f;

    private CharacterController controller;

    
    private Vector3 moveDirection;

    public BarHealth BarHealth;

    private Animator animator;


    public GameObject loseImg;

    public GameObject hpBar;

    void Start()
    {
        controller = GetComponent<CharacterController>();
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        animator = GetComponent<Animator>();
        BarHealth.SetMaxHealth(health);
    }

   
    void Update()
    {

        if(controller.isGrounded) {
            horizontalInput = Input.GetAxis("Horizontal");
            verticalInput = Input.GetAxis("Vertical");
            moveDirection = transform.forward * verticalInput + transform.right * horizontalInput;

            if(Input.GetKeyDown(KeyCode.Space)){
                moveDirection.y += jumpSpeed;
            }

        }else {
            moveDirection.y -= 9.81f * Time.deltaTime;
        }
        
        
        //animations
        if(horizontalInput == 0 && verticalInput == 0)
        {
            
            //idle
            animator.SetFloat("speed", 0);
        }
        else
        {
            
            animator.SetFloat("speed", 0.5f);
            
        }

        
        controller.Move(moveDirection * moveSpeed *Time.deltaTime);
    }

    void OnControllerColliderHit(ControllerColliderHit hit)
    {
        

        if (hit.gameObject.tag == "enemy")
        {
            health = health - Time.deltaTime * 2;
            print(health);
            BarHealth.SetHealth(health);
            
            
            if (health <= 0) 
            {
                loseImg.SetActive(true);
                
                hpBar.SetActive(false);
            }
        }
    }
}
