using UnityEngine;

public class LifeItem : MonoBehaviour
{
    public int healthAmount = 1;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Comprobamos si el objeto que entró tiene el script PlayerHealth
        PlayerHealth player = collision.GetComponent<PlayerHealth>();

        if (player != null)
        {
            player.AddHealth(healthAmount);
            Destroy(gameObject); // El item desaparece
        }
    }
}