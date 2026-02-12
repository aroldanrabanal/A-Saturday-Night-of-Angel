using UnityEngine;

public class EnemyPatrol : MonoBehaviour
{
    [Header("Ajustes de Movimiento")]
    public float speed = 2f;
    public bool movingRight = true;

    [Header("Detección de Suelo")]
    public Transform groundCheck; // Un objeto vacío en los pies del enemigo
    public float detectionDistance = 0.5f;
    public LayerMask groundLayer; // Selecciona la capa de tus plataformas

    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // 1. Mover al enemigo
        float moveStep = movingRight ? speed : -speed;
        rb.linearVelocity = new Vector2(moveStep, rb.linearVelocity.y);
        // Lanzamos el rayo
        RaycastHit2D groundInfo = Physics2D.Raycast(groundCheck.position, Vector2.down, detectionDistance, groundLayer);

        // DEBUG: Mira el rayo en la escena. Si está en VERDE toca suelo, si está en ROJO no.
        if (groundInfo.collider != null) {
            Debug.DrawRay(groundCheck.position, Vector2.down * detectionDistance, Color.green);
        } else {
            Debug.DrawRay(groundCheck.position, Vector2.down * detectionDistance, Color.red);
            Flip(); // Solo giramos si el rayo es rojo
        }
    }

    void Flip()
    {
        movingRight = !movingRight;
        // Girar el sprite
        Vector3 scaler = transform.localScale;
        scaler.x *= -1;
        transform.localScale = scaler;
    }
}