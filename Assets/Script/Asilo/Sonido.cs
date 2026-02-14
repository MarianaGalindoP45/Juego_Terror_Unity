using System.Collections;
using UnityEngine;

public class Sonido : MonoBehaviour
{
    public AudioSource audioSource; // Arrastra aquí el AudioSource desde el Inspector.
    public float delay = 5f; // Tiempo de retraso antes de reproducir el sonido.

    private bool hasPlayed = false; // Evita que el sonido se reproduzca varias veces.

    private void OnTriggerEnter(Collider other)
    {
        // Comprueba si el objeto que entra es el jugador.
        if (other.CompareTag("Player") && !hasPlayed)
        {
            hasPlayed = true; // Marca como reproducido para evitar repeticiones.
            StartCoroutine(PlaySoundWithDelay(delay));
        }
    }

    IEnumerator PlaySoundWithDelay(float delay)
    {
        yield return new WaitForSeconds(delay); // Espera el tiempo especificado.
        audioSource.Play(); // Reproduce el sonido.
    }
}
