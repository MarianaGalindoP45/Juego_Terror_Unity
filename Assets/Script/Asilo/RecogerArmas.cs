using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RecogerArmas : MonoBehaviour
{
    public GameObject[] armas;

    public void ActivarArma(int numero)
    {
        for (int i = 0; i < armas.Length; i++) // Corrige "lenght" a "Length"
        {
            armas[i].SetActive(false);
        }
        armas[numero].SetActive(true); // Usa corchetes en lugar de paréntesis
    }
}
