using UnityEngine;
using TMPro; // Importa el espacio de nombres de TextMesh Pro
using System.Collections.Generic;

public class ContarNotas : MonoBehaviour
{
    public TextMeshProUGUI notaTexto; // Cambia a TextMeshProUGUI
    private int notasRecolectadas = 0;
    private int totalNotas = 8;
    private HashSet<GameObject> notasVisitadas = new HashSet<GameObject>();

    void Start()
    {
        // Inicializa el texto con el conteo inicial.
        ActualizarTexto();
    }

    private void OnTriggerEnter(Collider other)
    {
        // Verifica si el objeto es una nota y no ha sido contado aún.
        if (other.CompareTag("Nota") && !notasVisitadas.Contains(other.gameObject))
        {
            notasRecolectadas++;
            notasVisitadas.Add(other.gameObject); // Registra la nota como contada.
            ActualizarTexto();
        }
    }

    private void ActualizarTexto()
    {
        // Actualiza el texto en pantalla con el conteo.
        notaTexto.text = $"Nota: {notasRecolectadas}/{totalNotas}";
    }
}
