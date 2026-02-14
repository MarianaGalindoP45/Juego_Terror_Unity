using System.Collections;
using UnityEngine;
using TMPro; // Necesario para usar TextMeshPro

public class RecogerLlaves : MonoBehaviour
{
    public GameObject[] llaves; // Array de llaves
    public TextMeshProUGUI mensajeLlave; // Texto que mostrará el mensaje
    public float duracionMensaje = 5f; // Duración en segundos del mensaje

    public void ActivarLlave(int numero)
    {
        // Desactiva todas las llaves
        for (int i = 0; i < llaves.Length; i++)
        {
            llaves[i].SetActive(false);
        }

        // Activa la llave seleccionada
        llaves[numero].SetActive(true);

        // Muestra el mensaje
        StartCoroutine(MostrarMensaje("Has tomado una llave"));
    }

    private IEnumerator MostrarMensaje(string mensaje)
    {
        if (mensajeLlave != null)
        {
            mensajeLlave.text = mensaje; // Asigna el texto
            mensajeLlave.gameObject.SetActive(true); // Muestra el texto
            yield return new WaitForSeconds(duracionMensaje); // Espera la duración especificada
            mensajeLlave.gameObject.SetActive(false); // Oculta el texto
        }
    }
}
