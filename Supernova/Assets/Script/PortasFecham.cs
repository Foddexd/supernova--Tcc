using UnityEngine;

public class PortasFecham : MonoBehaviour
{
    [System.Serializable]
    public class GrupoAtivacao
    {
        public GameObject areaTrigger;
        public GameObject[] objetosParaAtivar;
        public GameObject[] objetosParaDesativar;
    }

    [Header("Grupos de ativação")]
    public GrupoAtivacao[] grupos;

    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Player")) return;

        foreach (GrupoAtivacao grupo in grupos)
        {
            if (grupo.areaTrigger == null) continue;

            // Verifica se este objeto é a área do grupo
            if (grupo.areaTrigger == this.gameObject)
            {
                foreach (GameObject obj in grupo.objetosParaAtivar)
                {
                    if (obj != null) obj.SetActive(true);
                }

                foreach (GameObject obj in grupo.objetosParaDesativar)
                {
                    if (obj != null) obj.SetActive(false);
                }

                break; // Se encontrar o grupo correspondente, sai do loop
            }
        }
    }
}
