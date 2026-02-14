using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivarLlavePersonaje : MonoBehaviour
{
    public RecogerLlaves recogerLlaves; // Cambia a RecogerLlaves
    public int numeroLlave; // Cambia numeroArma a numeroLlave

    void Start()
    {
        recogerLlaves = GameObject.FindGameObjectWithTag("Player").GetComponent<RecogerLlaves>(); // Cambia RecogerArmas a RecogerLlaves
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (recogerLlaves != null) // Cambia a recogerLlaves
            {
                recogerLlaves.ActivarLlave(numeroLlave); // Cambia a ActivarLlave
                Destroy(gameObject);
            }
            else
            {
                Debug.LogWarning("recogerLlaves no está asignado.");
            }
        }
    }
}
