using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movimento : MonoBehaviour
{
    private float inputX;
    private float inputY;

    private CharacterController characterController;

    
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

    
    private void Awake()
    {
        characterController = GetComponent<CharacterController>();
        currentHeight = characterController.height;
        targetHeight = currentHeight;
    }

   
    void Update()
    {
        
        inputX = Input.GetAxis("Horizontal");
        inputY = Input.GetAxis("Vertical");

       
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

        
        characterController.Move(move * speed * Time.deltaTime);

        
        if (characterController.isGrounded)
        {
            velocity.y = -2f; 
        }
        else
        {
            velocity.y += gravity * Time.deltaTime; 
        }

        
        characterController.Move(velocity * Time.deltaTime);
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
}
