using UnityEngine;

public class AmmoPickup : MonoBehaviour
{
    public GameObject BalaVisualInventario;
    private AmmoManager ammoManager;
    private bool jogadorPerto;

    private void OnTriggerEnter(Collider other)
    {
        // tenta achar AmmoManager no próprio collider, nos pais ou nos filhos
        ammoManager = other.GetComponent<AmmoManager>()
                    ?? other.GetComponentInParent<AmmoManager>()
                    ?? other.GetComponentInChildren<AmmoManager>();

        if (ammoManager != null)
        {
            jogadorPerto = true;
            Debug.Log($"AmmoPickup: jogador entrou. AmmoManager encontrado em {ammoManager.gameObject.name}");
        }
        else
        {
            Debug.Log($"AmmoPickup: {other.gameObject.name} entrou, mas AmmoManager não foi encontrado nessa hierarquia.");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        // limpa referência quando o mesmo jogador sai
        if (other.GetComponentInParent<AmmoManager>() == ammoManager)
        {
            jogadorPerto = false;
            ammoManager = null;
            Debug.Log("AmmoPickup: jogador saiu da área.");
        }
    }

    private void Update()
    {
        if (jogadorPerto && Input.GetKeyDown(KeyCode.E))
        {
            if (ammoManager != null)
            {
                ammoManager.AdicionarCartucho(1);
                if (BalaVisualInventario != null) BalaVisualInventario.SetActive(true);
                Debug.Log("AmmoPickup: cartucho pego. Destruindo pickup.");
                Destroy(gameObject);
            }
            else
            {
                Debug.LogWarning("AmmoPickup: tentou pegar mas ammoManager é null.");
            }
        }
    }
}
