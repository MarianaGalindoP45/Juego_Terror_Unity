using System.Collections;
using UnityEngine;

public class Grito : MonoBehaviour
{
    private AudioSource grito; // Variable para almacenar el AudioSource deseado

    void Start()
    {
        // Obtén todos los AudioSource en este objeto
        AudioSource[] audioSources = GetComponents<AudioSource>();

        // Verifica si hay suficientes AudioSource y selecciona el segundo
        if (audioSources.Length > 0)
        {
            grito = audioSources[0]; // Elige el segundo AudioSource (índice 1)
        }
        else
        {
            Debug.LogWarning("No se encontraron suficientes AudioSource en este objeto.");
            return;
        }

        // Inicia la corrutina para reproducir el sonido después de 5 segundos
        StartCoroutine(ReproducirGritoDespuesDeTiempo(9f));
    }

    IEnumerator ReproducirGritoDespuesDeTiempo(float segundos)
    {
        // Espera el tiempo especificado
        yield return new WaitForSeconds(segundos);

        // Reproduce el sonido desde el AudioSource seleccionado
        grito.Play();
    }
}
