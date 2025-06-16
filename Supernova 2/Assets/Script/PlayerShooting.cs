using UnityEngine;
using UnityEngine.UI;

public class PlayerShooting : MonoBehaviour
{
    public GameObject projectilePrefab;
    public Transform firePoint; // onde o tiro nasce
    public Camera mainCamera;
    public bool temArma = false;
    public GameObject mobileShootButton; // referência ao botão de tiro (Mobile)

    void Start()
    {
      
    }

    void Update()
    {
#if !UNITY_ANDROID && !UNITY_IOS
        if (temArma && Input.GetMouseButtonDown(0)) 
        {
            Shoot();
        }
#endif
    }

    // Este método será chamado pelo botão no mobile
    public void ShootMobile()
    {
        if (temArma)
        {
            Shoot();
        }
    }

    private void Shoot()
    {
        Ray ray = mainCamera.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0)); // mira central
        if (Physics.Raycast(ray, out RaycastHit hit))
        {
            Vector3 direction = (hit.point - firePoint.position).normalized;
            GameObject proj = Instantiate(projectilePrefab, firePoint.position, Quaternion.LookRotation(direction));
            Rigidbody rb = proj.GetComponent<Rigidbody>();
            rb.velocity = direction * 20f;
        }
    }
}
