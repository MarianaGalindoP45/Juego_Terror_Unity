using UnityEngine;

public class MoverseSola : MonoBehaviour
{
    public Transform[] waypoints; // Array de waypoints
    public float speed = 5f;      // Velocidad de movimiento
    public float stopDistance = 0.1f; // Distancia para considerar que ha llegado al waypoint
    public bool loop = true;      // Si el movimiento debe ser cíclico
    public float startDelay = 5f; // Tiempo de retraso antes de empezar

    private int currentWaypointIndex = 0; // Índice del waypoint actual
    private bool isMoving = false;        // Si el personaje está en movimiento
    private float timer = 0f;             // Temporizador para el retraso inicial
    private Animator animator;            // Referencia al Animator

    void Start()
    {
        // Obtén el Animator del personaje
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        // Maneja el retraso inicial
        if (!isMoving)
        {
            timer += Time.deltaTime;
            if (timer < startDelay)
            {
                // Establece los parámetros para la animación de apuntar (Pointing)
                animator.SetFloat("X", 0f); // X = 0
                animator.SetFloat("Y", 0f); // Y = 1 (Posición que apunta a la animación de "Pointing")
                return; // No continúes hasta que pase el retraso
            }

            // Activa el movimiento una vez que pasa el retraso
            isMoving = true;
        }

        if (waypoints.Length == 0) return; // Si no hay waypoints, no hace nada

        // Obtiene el waypoint actual
        Transform targetWaypoint = waypoints[currentWaypointIndex];

        // Calcula la dirección y mueve al personaje
        Vector3 direction = (targetWaypoint.position - transform.position).normalized;
        transform.position += direction * speed * Time.deltaTime;

        // Actualiza el Blend Tree para la animación de correr (Slow Run)
        animator.SetFloat("X", 0f); // X = 1 (Correr hacia el frente)
        animator.SetFloat("Y", 1f); // Y = 1 (Animación de correr)

        // Comprueba si ha llegado al waypoint
        if (Vector3.Distance(transform.position, targetWaypoint.position) < stopDistance)
        {
            // Cambia al siguiente waypoint
            currentWaypointIndex++;

            // Si ha llegado al último waypoint
        if (Vector3.Distance(transform.position, targetWaypoint.position) < stopDistance)
            {
                // Cambia al siguiente waypoint
                currentWaypointIndex++;

                // Si ha llegado al último waypoint
                if (currentWaypointIndex >= waypoints.Length)
                {
                    // Desactiva o destruye al personaje
                    gameObject.SetActive(false); // Para desactivar
                    // Destroy(gameObject); // Alternativamente, elimina el personaje permanentemente
                }
            }
        }
    }
}
