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
        transform.localScale = new Vector3(direction, 1, 1);
    }

    private void OnTriggerEnter2D(Collider2D hitInfo)
    {
        // 1. Si toca al enemigo, le hace daño
        if (hitInfo.CompareTag("Enemy"))
        {
            SimpleEnemy enemy = hitInfo.GetComponent<SimpleEnemy>();
            if (enemy != null) {
                enemy.TakeDamage(1);
            }
            
            // 2. CREAR LA EXPLOSIÓN
            // Aparece en la posición de la bala y con su misma rotación
            Instantiate(impactEffect, transform.position, transform.rotation);

            // 3. Destruir la bala
            Destroy(gameObject);
        }
        
        // Si quieres que la explosión también salga al chocar con el suelo:
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