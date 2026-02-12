using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public int maxHealth = 3;
    private int currentHealth;
    private Animator anim;
    
    void Start()
    {
        currentHealth = maxHealth;
        anim = GetComponent<Animator>();
    }
    
    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        
        // Efecto de daño en el Animator
        if (anim != null) anim.SetTrigger("Hurt");
        
        if (currentHealth <= 0)
        {
            Die();
        }
    }
    
    void Die()
    {
        // Animación de muerte
        if (anim != null) anim.SetTrigger("Die");
        
        // Desactivar colisiones para que no moleste al morir
        GetComponent<Collider2D>().enabled = false;
        this.enabled = false; 

        Destroy(gameObject, 0.5f);
    }
}