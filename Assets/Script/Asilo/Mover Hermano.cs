using System;
using UnityEngine;

public class MoverHermano : MonoBehaviour
{
    public float velocidadMovimiento = 5.0f;  // Velocidad de caminar
    public float velocidadRotacion = 200.0f; // Velocidad de rotación
    public float velocidadCarrera = 10.0f;   // Velocidad cuando corre
    private Animator anim;
    private Rigidbody rb;
    private float x, z;

    public bool estoyAtacando;
    public bool avanzar;
    public float impulsogolpe = 10f;

    void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>(); // Asignar el Rigidbody al iniciar
    }

    void FixedUpdate()
    {
        if (avanzar)
        {
            rb.velocity = transform.forward * impulsogolpe;
        }
    }

    void Update()
    {
        x = Input.GetAxis("Horizontal");
        z = Input.GetAxis("Vertical");

        // Verificar si la barra espaciadora está presionada para correr
        bool estaCorriendo = Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift);

        // Determinar la velocidad según si está corriendo o no
        float velocidadActual = estaCorriendo ? velocidadCarrera : velocidadMovimiento;

        if (!estoyAtacando)
        {
            // Movimiento y rotación
            transform.Rotate(0, x * Time.deltaTime * velocidadRotacion, 0);
            transform.Translate(0, 0, z * Time.deltaTime * velocidadActual);
        }

        // Configurar los parámetros del Animator
        anim.SetFloat("VelX", x);
        anim.SetFloat("VelZ", z);

        // Activar animación de golpe si presionas Enter
        if (Input.GetKeyDown(KeyCode.Return) && !estoyAtacando)
        {
            anim.SetTrigger("golpe");
            estoyAtacando = true;
        }

        // Actualizar la animación de correr
        if (estaCorriendo && z > 0)  // Si la barra espaciadora está presionada y se mueve hacia adelante
        {
            anim.SetBool("isRunning", true); // Activar la animación de correr
        }
        else
        {
            anim.SetBool("isRunning", false); // Desactivar la animación de correr
        }
    }

    public void DejarGolpear()
    {
        estoyAtacando = false;
    }

    public void Avanzar()
    {
        avanzar = true;
    }

    public void DejoAvanzar()
    {
        avanzar = false;
    }
}
