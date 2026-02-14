using UnityEngine;
using UnityEngine.SceneManagement;


public class PauseMenu : MonoBehaviour
{
    public GameObject pauseMenuUI; // Arrastra aquí el Canvas del menú de pausa
    private bool isPaused = false;

    void Update()
    {
        // Detectar la tecla de pausa (Escape)
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }

    public void Resume()
    {
        pauseMenuUI.SetActive(false); // Oculta el menú de pausa
        Time.timeScale = 1;           // Reanuda el tiempo
        isPaused = false;
    }

    public void Pause()
    {
        pauseMenuUI.SetActive(true); // Muestra el menú de pausa
        Time.timeScale = 0;          // Detiene el tiempo
        isPaused = true;
    }

    public void QuitToMenu()
    {
        Time.timeScale = 1;           // Asegúrate de reanudar el tiempo antes de cambiar de escena
        Debug.Log("Volviendo al menú principal..."); // Reemplaza con tu lógica para cargar el menú
        SceneManager.LoadScene(0); // Descomenta esto si tienes una escena de menú principal
    }
}
