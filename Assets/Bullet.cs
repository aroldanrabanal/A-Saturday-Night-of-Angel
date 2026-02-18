using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 15f;
    public GameObject impactEffect;
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
        if (hitInfo.CompareTag("Enemy"))
        {
            EnemyHealth enemyHealth = hitInfo.GetComponent<EnemyHealth>();
            
            if (enemyHealth != null) 
            {
                enemyHealth.TakeDamage(1); 
            }
            else 
            {
                SimpleEnemy simple = hitInfo.GetComponent<SimpleEnemy>();
                if (simple != null) simple.TakeDamage(1);
            }

            Instantiate(impactEffect, transform.position, transform.rotation);
            Destroy(gameObject);
        }
        
        if (hitInfo.CompareTag("Player"))
        {
            PlayerHealth player = hitInfo.GetComponent<PlayerHealth>();
            if (player != null) {
                player.TakeDamage(1);
            }
            Instantiate(impactEffect, transform.position, transform.rotation);
            Destroy(gameObject);
        }

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