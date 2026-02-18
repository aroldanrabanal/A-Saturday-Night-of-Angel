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
        
        if (anim != null) anim.SetTrigger("Hurt");
        
        if (currentHealth <= 0)
        {
            Die();
        }
    }
    
    void Die()
    {
        if (anim != null) anim.SetTrigger("Die");
        
        GetComponent<Collider2D>().enabled = false;
        Destroy(gameObject, 0.5f);
    }
}