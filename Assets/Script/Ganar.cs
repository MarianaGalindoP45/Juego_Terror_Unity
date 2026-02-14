using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections; // Necesario para usar corrutinas

public class Ganar : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        // Verifica si el objeto con el que chocó tiene el tag "Hermana"
        if (other.CompareTag("Hermana"))
        {
            // Inicia la corrutina para esperar antes de cambiar de escena
            StartCoroutine(CambiarEscenaConRetraso(3f)); // 3 segundos de espera
        }
    }

    private IEnumerator CambiarEscenaConRetraso(float segundos)
    {
        yield return new WaitForSeconds(segundos); // Espera el tiempo especificado
        SceneManager.LoadScene(4); // Carga la escena de ganar
    }
}
