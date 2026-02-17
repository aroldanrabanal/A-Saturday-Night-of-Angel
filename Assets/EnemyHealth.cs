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
        
        // Activa el Trigger "Hurt" en tu Animator
        if (anim != null) anim.SetTrigger("Hurt");
        
        if (currentHealth <= 0)
        {
            Die();
        }
    }
    
    void Die()
    {
        // Activa el Trigger "Die"
        if (anim != null) anim.SetTrigger("Die");
        
        // Desactiva colisiones para que no estorbe al morir
        GetComponent<Collider2D>().enabled = false;
        Destroy(gameObject, 0.5f);
    }
}