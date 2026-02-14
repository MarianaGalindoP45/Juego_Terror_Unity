using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Collections;

public class TransicionEscena : MonoBehaviour
{
    public Image fadeImage;  // El image que sirve de overlay para el fade
    public float fadeSpeed = 3.0f;  // Velocidad de la transición (más bajo es más lento)

    void Start()
    {
        // Iniciar el fade de entrada cuando inicias la escena
        StartCoroutine(FadeIn());
    }

    public void CambiarEscena(int sceneIndex)
    {
        StartCoroutine(FadeOut(sceneIndex));
    }

    IEnumerator FadeIn()
    {
        float tiempo = 1.0f;
        fadeImage.color = new Color(fadeImage.color.r, fadeImage.color.g, fadeImage.color.b, 1); // Opaco al inicio

        // Fade de entrada: reducir la opacidad de 1 a 0
        while (tiempo > 0)
        {
            tiempo -= Time.deltaTime * fadeSpeed;
            fadeImage.color = new Color(fadeImage.color.r, fadeImage.color.g, fadeImage.color.b, tiempo);
            yield return null;
        }
    }

    IEnumerator FadeOut(int sceneIndex)
    {
        float tiempo = 0;
        fadeImage.color = new Color(fadeImage.color.r, fadeImage.color.g, fadeImage.color.b, 0); // Transparente al inicio

        // Fade de salida: aumentar la opacidad de 0 a 1
        while (tiempo < 1)
        {
            tiempo += Time.deltaTime * fadeSpeed;
            fadeImage.color = new Color(fadeImage.color.r, fadeImage.color.g, fadeImage.color.b, tiempo);
            yield return null;
        }

        // Cargar la nueva escena usando el índice
        SceneManager.LoadScene(1);
    }
}
