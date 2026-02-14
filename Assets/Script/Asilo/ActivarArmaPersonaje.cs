using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivarArmaPersonaje : MonoBehaviour
{
    public RecogerArmas recogerArmas;
    public int numeroArma;

    void Start()  // Cambia "start" a "Start" (con mayúscula)
    {
        recogerArmas = GameObject.FindGameObjectWithTag("Player").GetComponent<RecogerArmas>();
    }

    void Update() {}  // Cambia "update" a "Update" (con mayúscula)

    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (recogerArmas != null)
            {
                recogerArmas.ActivarArma(numeroArma);
                Destroy(gameObject);
            }
            else
            {
                Debug.LogWarning("recogerArmas no está asignado.");
            }
        }
    }
}
