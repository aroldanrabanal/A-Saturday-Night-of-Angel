using UnityEngine;

public class LifeItem : MonoBehaviour
{
    public int healthAmount = 1;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        PlayerHealth player = collision.GetComponent<PlayerHealth>();

        if (player != null)
        {
            player.AddHealth(healthAmount);
            Destroy(gameObject);
        }
    }
}