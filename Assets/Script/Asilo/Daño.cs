using System.Collections;
using UnityEngine;

public class Daño : MonoBehaviour
{
    public BarraVida BarraVidaPersonaje;
    public float daño = 5.0f;
    private bool estaCercaDelMonstruo = false;

    void Start()
    {
        // Iniciar la corrutina de daño constante
        StartCoroutine(AplicarDañoCadaDosSegundos());
    }

    // Corrutina para aplicar daño cada dos segundos
    IEnumerator AplicarDañoCadaDosSegundos()
    {
        while (true)
        {
            if (estaCercaDelMonstruo)
            {
                BarraVidaPersonaje.vidaActual -= daño;
                Debug.Log("Daño recibido cada 0.5 segundos");
            }
            yield return new WaitForSeconds(1.5f); // Espera los segundos antes de aplicar el próximo daño
        }
    }

    // Detecta cuando el jugador entra en el área del monstruo
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) // Asegúrate de que el jugador tenga el tag "Player"
        {
            estaCercaDelMonstruo = true;
        }
    }

    // Detecta cuando el jugador sale del área del monstruo
    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            estaCercaDelMonstruo = false;
        }
    }
}
