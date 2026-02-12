using UnityEngine;

public class EnemyFinal : MonoBehaviour
{
    [Header("Ajustes")]
    public float speed = 2f;
    public LayerMask groundLayer; 

    [Header("Detección")]
    public Transform groundCheck; 
    public float wallCheckDistance = 0.5f;

    [Header("Dirección Inicial")]
    public bool startsLookingRight = false; 

    private Rigidbody2D rb;
    private bool movingRight;

    void Start() {
        rb = GetComponent<Rigidbody2D>();
        movingRight = startsLookingRight;
    }

    void Update() {
        float currentSpeed = movingRight ? speed : -speed;
        rb.linearVelocity = new Vector2(currentSpeed, rb.linearVelocity.y);

        RaycastHit2D groundInfo = Physics2D.Raycast(groundCheck.position, Vector2.down, 1f, groundLayer);
        Vector2 wallDir = movingRight ? Vector2.right : Vector2.left;
        RaycastHit2D wallInfo = Physics2D.Raycast(transform.position, wallDir, wallCheckDistance, groundLayer);

        if (groundInfo.collider == false || wallInfo.collider == true) {
            Flip();
        }
    }

    void Flip() {
        movingRight = !movingRight;
        transform.Rotate(0f, 180f, 0f);
    }

    private void OnCollisionEnter2D(Collision2D collision) {
        if (collision.gameObject.CompareTag("Player")) {
            collision.gameObject.GetComponent<PlayerHealth>()?.TakeDamage(1);
        }
    }
}