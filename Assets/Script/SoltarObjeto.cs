using UnityEngine;

public class SoltarObjeto : MonoBehaviour
{
    public GameObject lootPrefab; // Objeto que se soltará al morir.
    public Transform lootSpawnPoint; // Punto desde donde se generará el loot (opcional).
    private BarraVida barraVida; // Referencia al script BarraVida.

    void Start()
    {
        // Busca el componente BarraVida en este objeto.
        barraVida = GetComponent<BarraVida>();

        if (barraVida == null)
        {
            Debug.LogError("No se encontró el componente BarraVida en el objeto.");
        }
    }

    void Update()
    {
        if (barraVida != null && barraVida.ObtenerVidaActual() <= 0)
        {
            // Suelta el objeto antes de desactivar el monstruo.
            SoltarLoot();
            gameObject.SetActive(false);
        }
    }

    private void SoltarLoot()
    {
        if (lootPrefab != null)
        {
            // Usa el punto de spawn o la posición actual del monstruo.
            Vector3 spawnPosition = lootSpawnPoint != null ? lootSpawnPoint.position : transform.position;
            Instantiate(lootPrefab, spawnPosition, Quaternion.identity);
        }
    }
}
