using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayerShooting : MonoBehaviour
{
    public GameObject projectilePrefab;
    public Transform firePoint; // onde o tiro nasce
    public Camera mainCamera;
    public bool temArma = false;
    // public GameObject mobileShootButton; // referência ao botão de tiro (Mobile)

    [Header("Munição")]
    public int maxBalasPorCartucho = 30;
    public int balasNoCartucho = 30;

    public TextMeshProUGUI balasTexto;
    public TextMeshProUGUI cartuchosTexto;

    private AmmoManager ammoManager;

    void Start()
    {
        ammoManager = GetComponent<AmmoManager>();

        // Se pegar a arma já com um cartucho
        if (temArma)
        {
            balasNoCartucho = maxBalasPorCartucho;
        }

        AtualizarUI();
    }

    void Update()
    {
#if !UNITY_ANDROID && !UNITY_IOS
        if (temArma && Input.GetMouseButtonDown(0))
        {
            Shoot();
        }
        if (temArma && Input.GetKeyDown(KeyCode.R))
        {
            Recarregar();
        }
#endif
        AtualizarUI();
    }

    // Este método será chamado pelo botão no mobile
    // public void ShootMobile()
    //  {
    //    if (temArma)
    //   {
    //       Shoot();
    //   }
    //   }
    public void TentarAtirar()
    {
        if (balasNoCartucho > 0)
        {
            Shoot();
            balasNoCartucho--;
        }
        else
        {
            Debug.Log("Sem balas! Pressione R para recarregar.");
        }
    }
    void Shoot()
    {
        Ray ray = mainCamera.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));
        if (Physics.Raycast(ray, out RaycastHit hit))
        {
            Vector3 direction = (hit.point - firePoint.position).normalized;
            GameObject proj = Instantiate(projectilePrefab, firePoint.position, Quaternion.LookRotation(direction));
            Rigidbody rb = proj.GetComponent<Rigidbody>();
            rb.velocity = direction * 20f;
        }
    }
    void Recarregar()
    {
        if (ammoManager != null && ammoManager.ConsumirCartucho())
        {
            Debug.Log("Recarregando...");
            balasNoCartucho = maxBalasPorCartucho;
        }
        else
        {
            Debug.Log("Sem cartuchos sobrando!");
        }
    }

    public void EquiparArma()
    {
        temArma = true;
        
    }
    void AtualizarUI()
    {
        if (balasTexto != null)
        {
            balasTexto.text = "Balas: " + balasNoCartucho;
        }

        if (cartuchosTexto != null && ammoManager != null)
        {
            cartuchosTexto.text = "Cartuchos: " + ammoManager.GetCartuchos();
        }
    }
}
