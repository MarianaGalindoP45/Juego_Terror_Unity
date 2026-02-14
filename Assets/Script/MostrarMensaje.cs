using UnityEngine;
using TMPro; // Importa TextMeshPro

public class MostrarMensajePuerta : MonoBehaviour
{
    public TMP_Text mensajeTexto;  // Usa TMP_Text si estás utilizando TextMeshPro
    public string mensaje = "Está cerrada";  // El mensaje que aparecerá
    public float distanciaDeteccion = 3.0f; // Distancia para mostrar el mensaje

    private void Start()
    {
        // Asegúrate de que el mensaje esté oculto al inicio
        mensajeTexto.gameObject.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        // Verifica si el jugador ha entrado en el área de la puerta
        if (other.CompareTag("Player"))
        {
            // Mostrar el mensaje si el jugador está cerca de la puerta
            mensajeTexto.gameObject.SetActive(true);
            mensajeTexto.text = mensaje;  // Establecer el texto
        }
    }

    private void OnTriggerExit(Collider other)
    {
        // Verifica si el jugador ha salido del área
        if (other.CompareTag("Player"))
        {
            // Ocultar el mensaje
            mensajeTexto.gameObject.SetActive(false);
        }
    }

    private void Update()
    {
        // Opcional: Mostrar el mensaje solo si el jugador está lo suficientemente cerca
        float distancia = Vector3.Distance(transform.position, GameObject.FindGameObjectWithTag("Player").transform.position);
        
        if (distancia < distanciaDeteccion)
        {
            mensajeTexto.gameObject.SetActive(true);
            mensajeTexto.text = mensaje;
        }
        else
        {
            mensajeTexto.gameObject.SetActive(false);
        }
    }
}
