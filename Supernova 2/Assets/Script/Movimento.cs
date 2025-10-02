using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Movimento : MonoBehaviour
{
    private float inputX;
    private float inputY;

    public float normalSpeed = 3f;  
    public float sprintSpeed = 6f;  
    public float crouchSpeed = 1.5f;  
    public float gravity = -9.81f; 
    public float jumpHeight = 2f;  

    private Vector3 velocity;
    private bool isSprinting = false;
    private bool isCrouching = false;

   
    public float crouchHeight = 0.5f;  
    public float standingHeight = 2f; 
    public float crouchDuration = 0.25f;  

    private float targetHeight;
    private float currentHeight;

    public FixedJoystick joystick;
  
    
    public Animator animator;
    public CharacterController characterController;

    private void Awake()
    {
        currentHeight = characterController.height;
        targetHeight = currentHeight;
    }

    void Update()
    {

      
        {
            inputX = Input.GetAxis("Horizontal");
            inputY = Input.GetAxis("Vertical");

        }
        if (Input.GetKey("w") || Input.GetKey("a") || Input.GetKey("s") || Input.GetKey("d"))
        {
            animator.SetBool("Andar", true);
        }


        if (!Input.GetKey("w") || !Input.GetKey("a") || !Input.GetKey("s") || !Input.GetKey("d"))
        {
            animator.SetBool("Andar", false);
        }
        // inputX = joystick.Horizontal;
        //  inputY = joystick.Vertical;


        isSprinting = Input.GetKey(KeyCode.LeftShift);


        if (Input.GetKeyDown(KeyCode.C) && !isCrouching)
        {
            StartCoroutine(CrouchStand());
        }
        else if (Input.GetKeyDown(KeyCode.C) && isCrouching)
        {
            StartCoroutine(StandUp());
        }


        Vector3 move = transform.right * inputX + transform.forward * inputY;
        float speed = isCrouching ? crouchSpeed : isSprinting ? sprintSpeed : normalSpeed;

        if(characterController.enabled)
        {
            characterController.Move(move * speed * Time.deltaTime);
        }


        if (characterController.isGrounded)
        {
            velocity.y = -2f;
        }
        else
        {
            velocity.y += gravity * Time.deltaTime;
        }

        if(characterController.enabled)
        {
            characterController.Move(velocity * Time.deltaTime);
        }

        bool TocarNaTecla = (Input.GetKey("w") || Input.GetKey("a") || Input.GetKey("s") || Input.GetKey("d"));

        if (TocarNaTecla)
        {
            animator.SetBool("Andar", true);
        }
        if (!TocarNaTecla)
        {
            animator.SetBool("Andar", false);
        }
    }

    IEnumerator CrouchStand()
    {
        isCrouching = true;

       
        targetHeight = crouchHeight;
        float timeElapsed = 0f;
        while (timeElapsed < crouchDuration)
        {
            characterController.height = Mathf.Lerp(currentHeight, targetHeight, timeElapsed / crouchDuration);
            timeElapsed += Time.deltaTime;
            yield return null;
        }
        characterController.height = targetHeight;
        currentHeight = characterController.height;
    }

   
    IEnumerator StandUp()
    {
        isCrouching = false;

       
        targetHeight = standingHeight;
        float timeElapsed = 0f;
        while (timeElapsed < crouchDuration)
        {
            characterController.height = Mathf.Lerp(currentHeight, targetHeight, timeElapsed / crouchDuration);
            timeElapsed += Time.deltaTime;
            yield return null;
        }
        characterController.height = targetHeight;
        currentHeight = characterController.height;
    }
    public void ToggleCrouch()
    {
        if (!isCrouching)
        {
            StopAllCoroutines(); // Para evitar bugs se apertar v�rias vezes
            StartCoroutine(CrouchStand());
        }
        else
        {
            StopAllCoroutines();
            StartCoroutine(StandUp());
        }
    }
    
}
