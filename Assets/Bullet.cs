using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 15f;
    public GameObject impactEffect; // <--- AQUÍ ARRASTRARÁS LA EXPLOSIÓN
    private Rigidbody2D rb;

    void Awake() {
        rb = GetComponent<Rigidbody2D>();
    }

    public void SetDirection(float direction) {
        rb.linearVelocity = new Vector2(direction * speed, 0);
        transform.localScale = new Vector3(direction, 4, 4);
    }

    private void OnTriggerEnter2D(Collider2D hitInfo)
    {
        // 1. Si toca al enemigo (Bala del Jugador)
        if (hitInfo.CompareTag("Enemy"))
        {
            // Buscamos el script de salud universal
            EnemyHealth enemyHealth = hitInfo.GetComponent<EnemyHealth>();
            
            if (enemyHealth != null) 
            {
                enemyHealth.TakeDamage(1); // Aplica el daño al script universal
            }
            else 
            {
                // Si el enemigo no tiene EnemyHealth, probamos con el viejo SimpleEnemy por si acaso
                SimpleEnemy simple = hitInfo.GetComponent<SimpleEnemy>();
                if (simple != null) simple.TakeDamage(1);
            }

            Instantiate(impactEffect, transform.position, transform.rotation);
            Destroy(gameObject);
        }
        
        // 2. NUEVO: Si toca al Player (Bala del Enemigo)
        if (hitInfo.CompareTag("Player"))
        {
            PlayerHealth player = hitInfo.GetComponent<PlayerHealth>();
            if (player != null) {
                player.TakeDamage(1); // O la cantidad de daño que prefieras
            }
            Instantiate(impactEffect, transform.position, transform.rotation);
            Destroy(gameObject);
        }

        // 3. Si choca con el suelo
        if (hitInfo.CompareTag("Ground"))
        {
            Instantiate(impactEffect, transform.position, transform.rotation);
            Destroy(gameObject);
        }
    }

    void Start() {
        Destroy(gameObject, 3f);
    }
}