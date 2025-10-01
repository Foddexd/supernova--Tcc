using UnityEngine;
using Cinemachine;

public class ControladorCamera : MonoBehaviour
{
    [SerializeField] private float xSpeed = 3;
    [SerializeField] private float ySpeed = 3;
    [SerializeField] private float xSpeedDelay = 5;
    [SerializeField] private float ySpeedDelay = 5;
    [SerializeField] private float yMin = -45;
    [SerializeField] private float yMax = 5;
    [SerializeField] private Transform lookat;
    
    private Vector3 playerAngles;
    private Vector3 lookAtAngles;

    void LateUpdate()
    {
        // Rotaciona o corpo do player
        playerAngles = new Vector3(0, playerAngles.y + Input.GetAxis("Mouse X") * xSpeed, 0);
        transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(playerAngles), xSpeedDelay * Time.deltaTime);
        
        // Rotaciona o lookat
        lookAtAngles = new Vector3(Mathf.Clamp(lookAtAngles.x + -Input.GetAxis("Mouse Y") * ySpeed, yMin, yMax), 0, 0);
        lookat.localRotation = Quaternion.Lerp(lookat.localRotation, Quaternion.Euler(lookAtAngles), ySpeedDelay * Time.deltaTime);
    }
}
