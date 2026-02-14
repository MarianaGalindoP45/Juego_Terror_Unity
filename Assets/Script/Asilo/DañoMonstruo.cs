using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DañoMonstruo : MonoBehaviour
{
    public BarraVida BarraVidaMonstruo;  // Referencia a la barra de vida del monstruo
    public float dañoBase = 5.0f;        // Daño base sin arma
    public float distanciaDeAtaque = 3.0f; // Distancia a la que se puede atacar
    private bool puedeAtacar = true;      // Variable que controla el ataque

    private Transform jugador;            // Referencia al jugador
    private RecogerArmas recogerArmas;    // Referencia al script RecogerArmas

    public float dañoCuchillo = 8.0f;     // Daño del cuchillo
    public float dañoMartillo = 10.0f;    // Daño del martillo

    void Start()
    {
        // Asumiendo que el jugador tiene la etiqueta "Player"
        jugador = GameObject.FindGameObjectWithTag("Player").transform;

        // Obtener referencia al script RecogerArmas en el jugador
        recogerArmas = jugador.GetComponent<RecogerArmas>();
        if (recogerArmas == null)
        {
            Debug.LogError("No se encontró el componente RecogerArmas en el jugador.");
        }
    }

    // Update se llama una vez por frame
    void Update()
    {
        // Comprobar la distancia entre el jugador y este objeto
        float distancia = Vector3.Distance(transform.position, jugador.position);

        // Solo permitir atacar si estamos cerca y podemos atacar
        if (distancia <= distanciaDeAtaque && Input.GetKeyDown(KeyCode.Return) && puedeAtacar)
        {
            if (BarraVidaMonstruo != null)
            {
                // Calcula el daño basado en el arma activa
                float dañoFinal = CalcularDaño();

                // Reducir la vida del monstruo usando el método de BarraVida
                BarraVidaMonstruo.vidaActual -= dañoFinal;

                Debug.Log($"Ataque realizado con {dañoFinal} de daño.");

                // Iniciar la corutina para esperar antes de permitir otro ataque
                StartCoroutine(EsperarAntesDePoderAtacar());
            }
            else
            {
                Debug.LogError("¡Referencia a BarraVidaMonstruo no asignada!");
            }
        }
    }

    // Corutina para esperar antes de poder atacar nuevamente
    IEnumerator EsperarAntesDePoderAtacar()
    {
        puedeAtacar = false; // Desactivar la posibilidad de atacar
        yield return new WaitForSeconds(1.0f); // Esperar 1 segundo antes de permitir otro ataque
        puedeAtacar = true; // Volver a permitir atacar
    }

    // Método para calcular el daño según el arma activa
    float CalcularDaño()
    {
        if (recogerArmas != null)
        {
            // Recorrer las armas y verificar cuál está activa
            for (int i = 0; i < recogerArmas.armas.Length; i++)
            {
                if (recogerArmas.armas[i].activeSelf) // Si el arma está activa
                {
                    if (recogerArmas.armas[i].name == "Knife_003") // Identificar el cuchillo
                    {
                        return dañoCuchillo;
                    }
                    else if (recogerArmas.armas[i].name == "Hammer_001") // Identificar el martillo
                    {
                        return dañoMartillo;
                    }
                }
            }
        }

        // Si no hay arma activa, usar el daño base
        return dañoBase;
    }
}
