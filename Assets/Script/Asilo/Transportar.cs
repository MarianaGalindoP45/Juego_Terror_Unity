using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Transportar : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log($"Colisión detectada con: {collision.gameObject.tag}");

        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("¡Colisión detectada con el jugador! Transportando...");
            SceneManager.LoadScene(2);
        }
    }
}
