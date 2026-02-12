using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class PlayerHealth : MonoBehaviour
{
    [Header("Estadísticas")]
    public int maxHealth = 3;
    private int currentHealth;

    [Header("UI de Corazones")]
    public GameObject heartPrefab;    
    public Transform heartContainer;  

    [Header("Respawn")]
    public Transform spawnPoint; // Arrastra aquí el objeto SpawnPoint

    [Header("Efectos Visuales")]
    public SpriteRenderer spriteRenderer; 
    public Color hurtColor = Color.red;
    private Color originalColor = Color.white;
    
    [Header("Invencibilidad")]
    public float invincibilityDuration = 1.5f;
    private bool isInvincible = false;

    public GameOverManager gameOverManager;

    void Start()
    {
        currentHealth = maxHealth;
        if (spriteRenderer == null) spriteRenderer = GetComponentInChildren<SpriteRenderer>();
        if (spriteRenderer != null) originalColor = spriteRenderer.color;
        DrawHearts();
    }

    public void DrawHearts()
    {
        foreach (Transform child in heartContainer) { Destroy(child.gameObject); }
        for (int i = 0; i < currentHealth; i++)
        {
            Instantiate(heartPrefab, heartContainer);
        }
    }

    public void TakeDamage(int damage)
    {
        if (isInvincible || currentHealth <= 0) return;

        currentHealth -= damage;
        DrawHearts();

        if (currentHealth <= 0)
        {
            Die();
        }
        else
        {
            StartCoroutine(HurtEffect());
        }
    }

    // NUEVA FUNCIÓN: Se llama cuando cae al vacío
    public void FallRespawn()
    {
        currentHealth--; // Quitar una vida
        DrawHearts();

        if (currentHealth <= 0)
        {
            Die();
        }
        else
        {
            // Mover al jugador al punto de inicio
            transform.position = spawnPoint.position;
            
            // Si usas Rigidbody2D, es bueno resetear la velocidad para que no aparezca cayendo
            Rigidbody2D rb = GetComponent<Rigidbody2D>();
            if(rb != null) rb.linearVelocity = Vector2.zero;

            StartCoroutine(HurtEffect()); // Efecto de parpadeo al reaparecer
        }
    }

    IEnumerator HurtEffect()
    {
        isInvincible = true;
        if (spriteRenderer != null) spriteRenderer.color = hurtColor;
        yield return new WaitForSeconds(0.2f);
        if (spriteRenderer != null) spriteRenderer.color = originalColor;

        float timer = 0;
        while (timer < invincibilityDuration)
        {
            if(spriteRenderer != null) spriteRenderer.enabled = !spriteRenderer.enabled;
            yield return new WaitForSeconds(0.1f);
            timer += 0.1f;
        }
        if(spriteRenderer != null) spriteRenderer.enabled = true;
        isInvincible = false;
    }

    void Die()
    {
        if (gameOverManager != null) gameOverManager.ShowGameOver();
    }
}