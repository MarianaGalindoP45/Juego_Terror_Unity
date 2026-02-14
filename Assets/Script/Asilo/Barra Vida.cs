using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; // Necesario para cambiar de escena
using UnityEngine.UI;

public class BarraVida : MonoBehaviour
{
    public Image vida;
    public float vidaActual;
    public float vidaMaxima;

    public bool esJugador; // Variable para diferenciar entre jugador y monstruo

    void Start()
    {
        vidaActual = vidaMaxima;
    }

    void Update()
    {
        RevisarVida();

        if (vidaActual <= 0)
        {
            if (esJugador)
            {
                // Cargar la escena de "Game Over"
                SceneManager.LoadScene("Perdiste");
            }
            else
            {
                // Desactivar el monstruo
                gameObject.SetActive(false);
            }
        }
    }

    public void RevisarVida()
    {
        vida.fillAmount = vidaActual / vidaMaxima;
    }


    public float ObtenerVidaActual()
    {
        return vidaActual; // Asegúrate de que esto esté devolviendo la vida correcta
    }


}
