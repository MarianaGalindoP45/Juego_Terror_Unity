using UnityEngine;

public class ActivarPuertaConLlave : MonoBehaviour
{
    public string tagLlave = "Llave"; // Asegúrate de que el objeto llave tenga este Tag
    private Abrirpuerta scriptAbrirPuerta;
    public GameObject canvasMensaje; // Arrastra el Canvas o el objeto del texto aquí

    void Start()
    {
        // Obtén el componente "Abrirpuerta" de este objeto y desactívalo al inicio
        scriptAbrirPuerta = GetComponent<Abrirpuerta>();
        if (scriptAbrirPuerta != null)
        {
            scriptAbrirPuerta.enabled = false; // Desactivar el script al inicio
        }
        else
        {
            Debug.LogError("No se encontró el componente Abrirpuerta en el objeto.");
        }

        // Opcional: Asegúrate de que el canvas esté activo al inicio si es necesario
        if (canvasMensaje != null)
        {
            canvasMensaje.SetActive(true); // Activa el Canvas inicialmente
        }
        else
        {
            Debug.LogError("No se asignó el Canvas para mostrar el mensaje.");
        }
    }

    void OnTriggerEnter(Collider other)
    {
        // Si el objeto que entra al collider tiene el Tag "Llave"
        if (other.CompareTag(tagLlave))
        {
            if (scriptAbrirPuerta != null)
            {
                scriptAbrirPuerta.enabled = true; // Activar el script
                Debug.Log("Llave detectada. Habilitando el script Abrirpuerta.");
            }

            // Desactivar el Canvas del mensaje
            if (canvasMensaje != null)
            {
                canvasMensaje.SetActive(false); // Desactivar el Canvas
                Debug.Log("Canvas desactivado.");
            }
        }
    }
}
