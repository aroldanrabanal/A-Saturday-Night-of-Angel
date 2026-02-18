using UnityEngine;

public class SimpleEnemy : MonoBehaviour
{
    public float speed = 2f;
    public int health = 3;
    public float wallCheckDistance = 0.5f;
    public LayerMask wallLayer; 
    
    private Rigidbody2D rb;
    private bool movingRight = true;

    void Start() {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update() {
        rb.linearVelocity = new Vector2(movingRight ? speed : -speed, rb.linearVelocity.y);

        RaycastHit2D wallInfo = Physics2D.Raycast(transform.position, movingRight ? Vector2.right : Vector2.left, wallCheckDistance, wallLayer);
        
        if (wallInfo.collider == true) {
            Flip();
        }
    }

    void Flip() {
        movingRight = !movingRight;
        transform.localScale = new Vector3(movingRight ? 1 : -1, 1, 1);
    }

    public void TakeDamage(int damage) {
        health -= damage;
        Debug.Log("Enemigo herido. Vida restante: " + health);
        if (health <= 0) Die();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && gameObject.CompareTag("Enemy"))
        {
            PlayerHealth playerHealth = collision.gameObject.GetComponent<PlayerHealth>();
            if (playerHealth != null)
            {
                playerHealth.TakeDamage(1);
            }
        }
    }
    void Die() {
        Destroy(gameObject);
    }
}