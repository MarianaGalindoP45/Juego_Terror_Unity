using System.Collections;
using UnityEngine;

public class SonidoTiempo : MonoBehaviour
{
    public AudioSource audioSource; // Arrastra tu componente AudioSource al inspector.
    public float delay = 5f; // Configura el retraso desde el Inspector (por defecto, 5 segundos).

    void Start()
    {
        StartCoroutine(PlaySoundWithDelay(delay));
    }

    IEnumerator PlaySoundWithDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        audioSource.Play();
    }
}
