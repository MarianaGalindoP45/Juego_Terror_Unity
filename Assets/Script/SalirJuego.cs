using UnityEngine;

public class SalirJuego : MonoBehaviour
{
    public void QuitGame()
    {
        // Funciona en un build del juego, pero no en el editor
        Application.Quit();
        Debug.Log("El juego se cerrará (solo en build).");
    }
}
