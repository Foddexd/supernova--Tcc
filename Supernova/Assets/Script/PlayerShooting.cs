using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    public GameObject projectilePrefab;
    public Transform firePoint; // onde o tiro nasce
    public Camera mainCamera;
    public bool temArma = false;

    void Update()
    {
        if (temArma && Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }
    }

    void Shoot()
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
