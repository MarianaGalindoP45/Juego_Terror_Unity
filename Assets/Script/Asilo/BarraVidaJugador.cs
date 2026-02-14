using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class BarraVidaJugador : MonoBehaviour
{

    public Image vida;
    public float vidaActual;
    public float vidaMaxima;

    void start ()
    {
        vidaActual = vidaMaxima;
    }
     void Update()
    {
        RevisarVida();

        if (vidaActual <=5)
        {
            SceneManager.LoadScene(0);

        }
    }

    public void RevisarVida()
    {
        vida.fillAmount = vidaActual / vidaMaxima;
    }
}
