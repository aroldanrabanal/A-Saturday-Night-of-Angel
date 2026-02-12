using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    public GameObject bulletPrefab;
    public Transform firePoint;

    void Update() 
    {
        if (Input.GetButtonDown("Fire1")) 
        {
            // Creamos la bala
            GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
            
            // Le pasamos la dirección basada en la escala del jugador
            // Si el Player tiene escala X = 1 va a la derecha, si es -1 va a la izquierda
            Bullet bulletScript = bullet.GetComponent<Bullet>();
            if (bulletScript != null)
            {
                bulletScript.SetDirection(transform.localScale.x);
            }
        }
    }
}