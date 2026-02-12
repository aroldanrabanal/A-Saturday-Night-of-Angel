using UnityEngine;

public class DeathZone : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Comprobamos si lo que cayó es el Player
        if (collision.CompareTag("Player"))
        {
            // Llamamos a la función de respawn del script de vida
            PlayerHealth playerHealth = collision.GetComponent<PlayerHealth>();
            if (playerHealth != null)
            {
                playerHealth.FallRespawn();
            }
        }
    }
}