using UnityEngine;
using TMPro; // Importa TextMeshPro
using UnityEngine.UI; // Importa para usar imágenes

public class Notas : MonoBehaviour
{
    public TMP_Text mensajeTexto;  // Usa TMP_Text si estás utilizando TextMeshPro
    public Image mensajeImagen;   // Imagen que aparecerá junto al texto
    public string mensaje = "Está cerrada";  // El mensaje que aparecerá
    public float distanciaDeteccion = 3.0f; // Distancia para mostrar el mensaje

    private void Start()
    {
        // Asegúrate de que el texto y la imagen estén ocultos al inicio
        mensajeTexto.gameObject.SetActive(false);
        if (mensajeImagen != null)
        {
            mensajeImagen.gameObject.SetActive(false);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        // Verifica si el jugador ha entrado en el área de la puerta
        if (other.CompareTag("Player"))
        {
            // Mostrar el texto y la imagen si el jugador está cerca de la puerta
            mensajeTexto.gameObject.SetActive(true);
            mensajeTexto.text = mensaje;

            if (mensajeImagen != null)
            {
                mensajeImagen.gameObject.SetActive(true);
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        // Verifica si el jugador ha salido del área
        if (other.CompareTag("Player"))
        {
            // Ocultar el texto y la imagen
            mensajeTexto.gameObject.SetActive(false);

            if (mensajeImagen != null)
            {
                mensajeImagen.gameObject.SetActive(false);
            }
        }
    }

    private void Update()
    {
        // Opcional: Mostrar el mensaje y la imagen solo si el jugador está lo suficientemente cerca
        float distancia = Vector3.Distance(transform.position, GameObject.FindGameObjectWithTag("Player").transform.position);

        if (distancia < distanciaDeteccion)
        {
            mensajeTexto.gameObject.SetActive(true);
            mensajeTexto.text = mensaje;

            if (mensajeImagen != null)
            {
                mensajeImagen.gameObject.SetActive(true);
            }
        }
        else
        {
            mensajeTexto.gameObject.SetActive(false);

            if (mensajeImagen != null)
            {
                mensajeImagen.gameObject.SetActive(false);
            }
        }
    }
}
