using UnityEngine;

public class EnemyPatrol : MonoBehaviour
{
    [Header("Ajustes de Movimiento")]
    public float speed = 2f;
    public bool movingRight = true;

    [Header("Detección de Suelo")]
    public Transform groundCheck;
    public float detectionDistance = 0.5f;
    public LayerMask groundLayer; 

    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        float moveStep = movingRight ? speed : -speed;
        rb.linearVelocity = new Vector2(moveStep, rb.linearVelocity.y);
        RaycastHit2D groundInfo = Physics2D.Raycast(groundCheck.position, Vector2.down, detectionDistance, groundLayer);

        if (groundInfo.collider != null) {
            Debug.DrawRay(groundCheck.position, Vector2.down * detectionDistance, Color.green);
        } else {
            Debug.DrawRay(groundCheck.position, Vector2.down * detectionDistance, Color.red);
            Flip();
        }
    }

    void Flip()
    {
        movingRight = !movingRight;
        Vector3 scaler = transform.localScale;
        scaler.x *= -1;
        transform.localScale = scaler;
    }
}