using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Abrirpuerta : MonoBehaviour
{
    public float speed = 1.0f;
    public float angleApertura = 80.0f; // Ángulo de apertura en relación al ángulo inicial
    private float initialAngle;
    private float targetAngle;
    private bool puedeAbrir = false;
    private bool puertaAbriendo = false;
    private bool puertaAbierta = false;

    void Start()
    {
        initialAngle = transform.eulerAngles.y; // Guarda el ángulo inicial de la puerta
    }

    void Update()
    {
        // Si la puerta está en proceso de apertura o cierre
        if (puertaAbriendo)
        {
            // Suaviza la rotación hacia el ángulo objetivo
            float newAngle = Mathf.LerpAngle(transform.eulerAngles.y, targetAngle, Time.deltaTime * speed);
            transform.eulerAngles = new Vector3(transform.eulerAngles.x, newAngle, transform.eulerAngles.z);

            // Detiene la rotación cuando llega cerca del ángulo objetivo
            if (Mathf.Abs(Mathf.DeltaAngle(transform.eulerAngles.y, targetAngle)) < 0.5f)
            {
                transform.eulerAngles = new Vector3(transform.eulerAngles.x, targetAngle, transform.eulerAngles.z);
                puertaAbriendo = false;
                puertaAbierta = !puertaAbierta; // Cambia el estado de la puerta (abierta/cerrada)
            }
        }

        // Detecta la tecla Shift para abrir o cerrar la puerta, de forma individual
        if ((Input.GetKey(KeyCode.Space)) && puedeAbrir && !puertaAbriendo)
        {
            // Alterna entre abrir y cerrar
            targetAngle = puertaAbierta ? initialAngle : initialAngle + angleApertura;
            puertaAbriendo = true;
            Debug.Log("Abriendo puerta: " + targetAngle);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            puedeAbrir = true; // Solo se activa cuando el jugador está cerca de la puerta
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            puedeAbrir = false; // Desactiva cuando el jugador sale del área
        }
    }
}
