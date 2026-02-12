using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public int maxHealth = 3;
    private int currentHealth;
    
    void Start()
    {
        currentHealth = maxHealth;
    }
    
    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        
        // Efecto de daño
        GetComponent<Animator>()?.SetTrigger("Hurt");
        
        // Muerte
        if (currentHealth <= 0)
        {
            Die();
        }
    }
    
    void Die()
    {
        // Animación de muerte + destruir
        GetComponent<Animator>()?.SetTrigger("Die");
        Destroy(gameObject, 0.5f);
    }
}