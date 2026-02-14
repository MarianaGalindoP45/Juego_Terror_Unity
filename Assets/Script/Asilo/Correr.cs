using UnityEngine;

public class Correr : MonoBehaviour
{
    public float walkSpeed = 2.0f; // Velocidad al caminar
    public float runSpeed = 5.0f;  // Velocidad al correr
    private float currentSpeed;    // Velocidad actual basada en el estado

    private Animator animator;     // Referencia al Animator

    void Start()
    {
        // Obtener la referencia al Animator
        animator = GetComponent<Animator>();

        if (animator == null)
        {
            Debug.LogError("El objeto no tiene un componente Animator asignado.");
        }
    }

    void Update()
    {
        // Leer entrada del usuario
        float inputX = Input.GetAxis("Horizontal"); // Movimiento lateral (A/D o flechas izquierda/derecha)
        float inputZ = Input.GetAxis("Vertical");   // Movimiento hacia adelante/atrás (W/S o flechas arriba/abajo)

        // Determinar si está corriendo (presionando barra espaciadora)
        bool isRunning = Input.GetKey(KeyCode.Space);
        currentSpeed = isRunning ? runSpeed : walkSpeed;

        // Calcular la dirección del movimiento
        Vector3 moveDirection = new Vector3(inputX, 0, inputZ).normalized;

        // Actualizar posición del personaje
        if (moveDirection.magnitude > 0)
        {
            transform.position += moveDirection * currentSpeed * Time.deltaTime;

            // Rotar el personaje hacia la dirección del movimiento
            Quaternion targetRotation = Quaternion.LookRotation(moveDirection);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, 10 * Time.deltaTime);
        }

        // Actualizar parámetros del Animator
        if (animator != null)
        {
            animator.SetFloat("VelX", inputX);  // Enviar movimiento lateral
            animator.SetFloat("VelZ", inputZ);  // Enviar movimiento hacia adelante/atrás
            animator.SetBool("isRunning", isRunning); // Indicar si está corriendo
        }
    }
}
