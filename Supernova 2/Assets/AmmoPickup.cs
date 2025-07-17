using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoPickup : MonoBehaviour
{
    public GameObject BalaVisualInventario;
    private AmmoManager ammoManager;

    public bool JogadorPerto;

    private PlayerShooting jogadorScript;

    // Start is called before the first frame update
    void Start()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            JogadorPerto = true;

            ammoManager = other.GetComponent<AmmoManager>();

        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            JogadorPerto = false;

            ammoManager = null;

        }
    }

    private void Update()
    {
        if (JogadorPerto && Input.GetKeyDown(KeyCode.E) && ammoManager != null)
        {
            ammoManager.AdicionarCartucho();

                BalaVisualInventario.SetActive(true);
                
                Destroy(gameObject);
            

        }
    }
}
