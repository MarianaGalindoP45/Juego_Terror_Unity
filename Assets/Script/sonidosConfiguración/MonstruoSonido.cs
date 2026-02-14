using System.Collections;
using UnityEngine;

public class MonstruoSonido : MonoBehaviour
{
    public AudioSource audioSource; // Tu componente AudioSource
    public float intervaloRepeticion = 5.0f; // Tiempo de espera entre repeticiones, en segundos
    private bool jugadorEnRango = false; // Variable para verificar si el jugador está cerca
    private Coroutine reproducirAudioCoroutine;

    void Start()
    {
        // Inicia la corrutina cuando el jugador está en rango
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) // Asegúrate de que el jugador tenga el tag "Player"
        {
            jugadorEnRango = true;
            // Solo inicia la corrutina si aún no está corriendo
            if (reproducirAudioCoroutine == null)
            {
                reproducirAudioCoroutine = StartCoroutine(ReproducirAudioConIntervalo());
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            jugadorEnRango = false;
            // Detiene la corrutina cuando el jugador sale del rango
            if (reproducirAudioCoroutine != null)
            {
                StopCoroutine(reproducirAudioCoroutine);
                reproducirAudioCoroutine = null;
            }
            // Pausa el audio si aún está reproduciéndose
            audioSource.Pause();
        }
    }

    IEnumerator ReproducirAudioConIntervalo()
    {
        while (jugadorEnRango) // Repite solo mientras el jugador esté cerca
        {
            audioSource.Play(); // Reproduce el audio
            yield return new WaitForSeconds(audioSource.clip.length + intervaloRepeticion); // Espera a que termine el audio y agrega el intervalo
        }
        reproducirAudioCoroutine = null; // Reinicia la variable de la corrutina cuando el jugador sale del rango
    }
}
