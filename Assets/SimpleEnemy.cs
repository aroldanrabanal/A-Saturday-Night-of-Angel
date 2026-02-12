using UnityEngine;

public class SimpleEnemy : MonoBehaviour
{
    public float speed = 2f;
    public int health = 3;
    public float wallCheckDistance = 0.5f;
    public LayerMask wallLayer; // Selecciona "Ground" en el inspector
    
    private Rigidbody2D rb;
    private bool movingRight = true;

    void Start() {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update() {
        // Moverse horizontalmente
        rb.linearVelocity = new Vector2(movingRight ? speed : -speed, rb.linearVelocity.y);

        // Detectar si hay una pared o se acaba el suelo delante
        RaycastHit2D wallInfo = Physics2D.Raycast(transform.position, movingRight ? Vector2.right : Vector2.left, wallCheckDistance, wallLayer);
        
        // Si choca con algo, gira
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
        // Solo hacemos daño si el objeto tiene el TAG Player
        // Y nos aseguramos de que ESTE objeto (el enemigo) sea realmente un enemigo
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
        // Aquí podrías instanciar un efecto de explosión del pack de assets
        Destroy(gameObject);
    }
}