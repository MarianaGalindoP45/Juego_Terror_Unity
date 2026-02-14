using UnityEngine;

public class MonstruoSeguirConAnimacion : MonoBehaviour
{
    public Transform objetivo;        // El jugador
    public float velocidad = 3.0f;    // Velocidad del monstruo
    public float distanciaMinima = 1.5f;  // Distancia mínima para detenerse

    private Animator animator;         // Componente Animator
    private bool puedeSeguir = false;  // Controla si el monstruo puede seguir al jugador

    void Start()
    {
        animator = GetComponent<Animator>();

        // Si no se asigna el objetivo manualmente, busca al jugador por etiqueta
        if (objetivo == null)
        {
            GameObject jugador = GameObject.FindGameObjectWithTag("Player");
            if (jugador != null)
            {
                objetivo = jugador.transform;
                Debug.Log("Jugador encontrado y asignado como objetivo.");
            }
            else
            {
                Debug.LogError("No se encontró un jugador con la etiqueta 'Player'.");
            }
        }
    }

    void Update()
    {
        if (!puedeSeguir || objetivo == null) return;

        float distancia = Vector3.Distance(transform.position, objetivo.position);

        // Verifica si debe moverse o detenerse
        if (distancia > distanciaMinima)
        {
            // Calcular la dirección y movimiento
            Vector3 direccion = (objetivo.position - transform.position).normalized;
            transform.position += direccion * velocidad * Time.deltaTime;

            // Configurar los parámetros VelX y VelY para el Blend Tree
            animator.SetFloat("VelX", direccion.x * 2.0f);  // Ajusta la multiplicación según sea necesario
            animator.SetFloat("VelY", direccion.z * 2.0f);

            // Rotar para mirar al jugador
            transform.LookAt(new Vector3(objetivo.position.x, transform.position.y, objetivo.position.z));
        }
        else
        {
            // Detener el movimiento
            animator.SetFloat("VelX", 0);
            animator.SetFloat("VelY", 0);
        }
    }

    // Detectar si el jugador entra en el área del Sphere Collider
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !puedeSeguir)
        {
            puedeSeguir = true; // Permitir que el monstruo comience a seguir al jugador
            Debug.Log("Jugador entró en el área del trigger. Monstruo comienza a seguir.");
        }
    }

    // Aquí ya no es necesario OnTriggerExit porque no detendremos el seguimiento
}
