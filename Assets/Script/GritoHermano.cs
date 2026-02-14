using UnityEngine;

public class GritoHermano : MonoBehaviour
{
    public AudioSource audioGanar; // Asocia un AudioSource en el inspector

    private void OnTriggerEnter(Collider other)
    {
        // Verifica si el objeto con el que chocó tiene el tag "Hermana"
        if (other.CompareTag("Hermana"))
        {
            // Reproduce el audio
            if (audioGanar != null)
            {
                audioGanar.Play();
            }
        }
    }
}
